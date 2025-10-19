import { Injectable } from '@angular/core';
import { CartItem } from '../models/cart.model';
import { BehaviorSubject } from 'rxjs';

const CART_ITEMS_KEY = 'cart_items';
const CART_STOCK_KEY = 'cart_stockMap';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private items = new Map<string, CartItem>;
  private stockMap: Record<string, number> = {};

  private itemsSubject = new BehaviorSubject<CartItem[]>([]);
  readonly items$ = this.itemsSubject.asObservable();

  constructor() {
    try {
      const savedItems = JSON.parse(localStorage.getItem(CART_ITEMS_KEY) || '[]') as CartItem[];
      for (const it of savedItems) {
        if (it?.productId) this.items.set(it.productId, it);
      }
      const savedStock = JSON.parse(localStorage.getItem(CART_STOCK_KEY) || '{}') as Record<string, number>;
      if (savedStock && typeof savedStock === 'object') this.stockMap = savedStock;
    } catch { }

    this.emit();
  }

  private emit() {
    const list = Array.from(this.items.values());
    this.itemsSubject.next(list);
    localStorage.setItem(CART_ITEMS_KEY, JSON.stringify(list));
    localStorage.setItem(CART_STOCK_KEY, JSON.stringify(this.stockMap));
  }

  setStockMap(map: Record<string, number>) {
    this.stockMap = { ...map };
    this.emit();
  }

  getItems(): CartItem[] {
    return Array.from(this.items.values());
  }

  getQuantity(productId: string): number {
    return this.items.get(productId)?.quantity ?? 0;
  }
 
  add(item: Omit<CartItem, 'quantity'>, qty: number) {
    const max = this.stockMap[item.productId] ?? 0;
    if (max <= 0) return;

    const current = this.items.get(item.productId)?.quantity ?? 0;
    const nextQty = Math.min(current + qty, max);

    this.items.set(item.productId, {
      ...item,
      quantity: nextQty,
    });
    this.emit();
  }

  setQuantity(productId: string, qty: number) {
    const max = this.stockMap[productId] ?? 0;
    if (max <= 0 || qty <= 0) {
      this.items.delete(productId);
      this.emit();
      return;
    }
    this.items.set(productId, {
      ...(this.items.get(productId) as CartItem),
      quantity: Math.min(qty, max),
    });
    this.emit();
  }

  remove(productId: string) {
    this.items.delete(productId);
    this.emit();
  }

  clear() {
    this.items.clear();
    this.emit();
  }

  total(): number {
    return this.getItems().reduce((sum, it) => sum + it.price * it.quantity, 0);
  }
}
