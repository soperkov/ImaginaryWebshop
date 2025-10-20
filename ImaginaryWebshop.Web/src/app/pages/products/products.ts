import { Component } from '@angular/core';
import { ProductDetailsDto } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { WarehouseService } from '../../services/warehouse.service';
import { CartService } from '../../services/cart.service';
import { WarehouseDetailsDto } from '../../models/warehouse.model';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './products.html',
  styleUrl: './products.css'
})
export class Products {
  products: ProductDetailsDto[] = [];
  errorMessage = '';
  quantities: { [key: string ] : number } = {};
  stockMap: { [key: string ] : number } = {};
  alertMessage: string | null = null;

  constructor(private ps: ProductService, private ws: WarehouseService, private cart: CartService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
      this.ws.getAll().subscribe({
    next: (warehouseItems) => {
      warehouseItems.forEach((w: WarehouseDetailsDto) => {
        const productId = w.productId;
        const qty = w.stockQuantity ?? 0;
        if (productId) this.stockMap[productId] = qty;
      });

      this.ps.getAllProducts().subscribe({
        next: (res) => {
          this.products = res;
          this.products.forEach(p => {
            const stock = this.stockOf(p);
            this.cart.setStockMap(this.stockMap);
            this.quantities[p.id] = stock > 0 ? 1 : 0;
          });
        },
        error: (err) => {
          console.error(err);
          this.errorMessage = 'Failed to load products.';
        }
      });
    },
    error: (err) => {
      console.error(err);
      this.errorMessage = 'Failed to load warehouse stock.';
    }
  });
  }

  stockOf(p: ProductDetailsDto): number {
    return this.stockMap[p.id] ?? 0;
  }

  canIncrease(p: ProductDetailsDto): boolean {
    const stock = this.stockOf(p);
    return stock > 0 && this.quantities[p.id] < stock;
  }

  canDecrease(p: ProductDetailsDto): boolean {
    const stock = this.stockOf(p);
    return stock > 0 && this.quantities[p.id] > 1;
  }

  increase(p: ProductDetailsDto): void {
    if (this.canIncrease(p)) this.quantities[p.id]++;
  }

  decrease(p: ProductDetailsDto): void {
    if (this.canDecrease(p)) this.quantities[p.id]--;
  }

  outOfStock(p: ProductDetailsDto): boolean {
    return this.stockOf(p) === 0;
  }

  atMax(p: ProductDetailsDto): boolean {
    return this.quantities[p.id] >= this.stockOf(p);
  }

  addToCart(p: ProductDetailsDto): void {
    if (this.outOfStock(p)) return;
    const qty = this.quantities[p.id] ?? 0;
    this.cart.add(
      {
        productId: p.id,
        name: p.name,
        price: p.price,
        pictureUrl: (p as any).pictureUrl ?? (p as any).picture ?? null
      },
      qty
    )
    this.alertMessage = `${p.name} added to cart!`;
    setTimeout(() => (this.alertMessage = null), 3000);
  }

  imgSrc(u?: string | null): string {
    if (!u) return '';
    if (/^https?:\/\//i.test(u)) return u;

    const base = new URL(environment.apiBaseUrl, window.location.origin);
    const origin = base.origin; 
    return `${origin}${u.startsWith('/') ? u : '/' + u}`;
  }

  trackById(_: number, item: ProductDetailsDto) {
    return item.id;
  }
}
