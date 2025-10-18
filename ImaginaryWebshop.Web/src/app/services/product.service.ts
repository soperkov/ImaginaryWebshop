import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ProductCreateDto, ProductDetailsDto, ProductUpdateDto } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private base = `${environment.apiBaseUrl}/product`;

  constructor(private http:HttpClient) {}

  createProduct(product: ProductCreateDto): Observable<string> {
    return this.http.post<string>(`${this.base}`, product);
  }

  updateProduct(productId: string, product: ProductUpdateDto): Observable<void> {
    return this.http.put<void>(`${this.base}/${productId}`, product);
  }

  getProductDetails(productId: string): Observable<ProductDetailsDto> {
    return this.http.get<ProductDetailsDto>(`${this.base}/${productId}`);
  }

  getAllProducts(): Observable<ProductDetailsDto[]> {
    return this.http.get<ProductDetailsDto[]>(`${this.base}`);
  }
}
