import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { OrderCreateDto, OrderDetailsDto, ProductOrderDetailsDto } from '../models/order.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private base = `${environment.apiBaseUrl}/order`;

  constructor(private http:HttpClient) {}

  createOrder(order:OrderCreateDto): Observable<string> {
    return this.http.post<string>(`${this.base}`, order);
  }

  getAllOrders(userId: string): Observable<OrderDetailsDto[]> {
    return this.http.get<OrderDetailsDto[]>(`${this.base}`, {
      params: {userId}
    })
  }

  getOrderDetails(userId: string, orderId: string): Observable<OrderDetailsDto> {
    return this.http.get<OrderDetailsDto>(`${this.base}/${orderId}`, {
      params: {userId}
    })
  }

  getOrderItem(userId: string, productId: string, orderId: string): Observable<ProductOrderDetailsDto>{
    return this.http.get<ProductOrderDetailsDto>(`${this.base}/${orderId}/items/${productId}`, {
      params: {userId}
    })
  }
}
