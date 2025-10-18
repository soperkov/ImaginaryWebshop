import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { WarehouseCreateDto, WarehouseDetailsDto, WarehouseUpdateDto } from '../models/warehouse.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  private base = `${environment.apiBaseUrl}/warehouse`;

  constructor(private http:HttpClient) {}

  createWarehouseItem(item: WarehouseCreateDto): Observable<string> {
    return this.http.post<string>(`${this.base}`, item);
  }

  updateWarehouseItem(itemId: string, item: WarehouseUpdateDto): Observable<void> {
    return this.http.put<void>(`${this.base}/${itemId}`, item);
  }

  getWarehouseItemDetails(itemId: string): Observable<WarehouseDetailsDto> {
    return this.http.get<WarehouseDetailsDto>(`${this.base}/${itemId}`);
  }

  getAll(): Observable<WarehouseDetailsDto[]> {
    return this.http.get<WarehouseDetailsDto[]>(`${this.base}`);
  }
}
