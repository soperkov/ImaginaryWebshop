import { Component, Input } from '@angular/core';
import { ProductDetailsDto } from '../../models/product.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { WarehouseService } from '../../services/warehouse.service';
import { Router } from '@angular/router';
import { of, switchMap, map, catchError } from 'rxjs';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-product-form',
  standalone: false,
  templateUrl: './product-form.html',
  styleUrl: './product-form.css'
})
export class ProductForm {
  @Input() mode: 'create' | 'edit' = 'create';
  @Input() product?: ProductDetailsDto | null;

  form!: FormGroup;
  errorMessage = '';
  pictureUrl: string | null = null;
  selectedFile: File | null = null;

  constructor(private fb: FormBuilder, private ps: ProductService,
    private ws: WarehouseService, private router: Router) {}

  ngOnInit(): void {
    this.form = this.fb.nonNullable.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      category: ['', Validators.required],
      stockQuantity: [0, [Validators.required, Validators.min(0)]],
      position: ['', Validators.required],
      pictureUrl: ['']
    })

    if (this.mode === 'edit' && this.product) {
      this.form.patchValue({
        name: this.product.name ?? '',
        description: this.product.description ?? '',
        price: this.product.price ?? 0,
        category: this.product.category ?? '',
        pictureUrl: this.product.pictureUrl ?? '',
      });
      this.pictureUrl = this.product.pictureUrl || null;
    }
  }

    onFilePicked(event: Event) {
    const input = event.target as HTMLInputElement;
    const f = input.files && input.files[0] ? input.files[0] : null;
    this.selectedFile = f;
    if (!f) {
      this.pictureUrl = this.form.get('pictureUrl')?.value || null;
      return;
    }
    const reader = new FileReader();
    reader.onload = () => (this.pictureUrl = reader.result as string);
    reader.readAsDataURL(f);
  }

  removeImage() {
    this.selectedFile = null;
    this.pictureUrl = null;
    this.form.get('pictureUrl')?.setValue('');
  }

  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.errorMessage = '';

    const v = this.form.getRawValue();
    const name = v.name as string;
    const description = v.description as string;
    const price = Number(v.price);
    const category = v.category as string;
    const stockQuantity = Number(v.stockQuantity);
    const position = v.position as string;
    const existingUrl = (v.pictureUrl as string) || '';

    if (this.mode === 'create') {
      const upload$ = this.selectedFile
        ? this.ps.uploadImage(this.selectedFile)
        : of<string>(existingUrl);

      upload$
        .pipe(
          switchMap((url) =>
            this.ps.createProduct({
              name,
              description,
              price,
              category,
              pictureUrl: url || '',
            })
          ),
          switchMap((productId: string) =>
            this.ws
              .createWarehouseItem({
                productId,
                stockQuantity,
                position,
              })
              .pipe(map(() => productId))
          ),
          catchError((err) => {
            console.error(err);
            this.errorMessage = 'Failed to create product.';
            return of(null);
          })
        )
        .subscribe((productId) => {
          if (!productId) return;
          this.router.navigateByUrl('/products');
        });
    } else {
      if (!this.product?.id) {
        this.errorMessage = 'Missing product id.';
        return;
      }

      const productId = this.product.id;

      const upload$ = this.selectedFile
        ? this.ps.uploadImage(this.selectedFile, productId)
        : of<string>(existingUrl || this.product.pictureUrl || '');

      upload$
        .pipe(
          switchMap((url) =>
            this.ps.updateProduct(productId, {
              name,
              description,
              price,
              category,
              pictureUrl: url || '',
            })
          ),
          switchMap(() =>
            this.ws.getAll().pipe(
              map((items) => items.find((w) => w.productId === productId) || null)
            )
          ),
          switchMap((found) => {
            if (found) {
              return this.ws.updateWarehouseItem(found.id, {
                stockQuantity,
                position,
              });
            } else {
              return this.ws.createWarehouseItem({
                productId,
                stockQuantity,
                position,
              });
            }
          }),
          catchError((err) => {
            console.error(err);
            this.errorMessage = 'Failed to save changes.';
            return of(null);
          })
        )
        .subscribe((ok) => {
          if (ok === null) return;
          this.router.navigateByUrl('/products');
        });
      }
    }

  goToProducts() {
    this.router.navigateByUrl('/products');
  }
}