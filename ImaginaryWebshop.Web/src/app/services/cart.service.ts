import { Injectable } from '@angular/core';
import { CartItem } from '../models/cart.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private items: CartItem[] = [];

  getItems() {
    return [...this.items];
  }

  add(item: CartItem){
    const existing = this.items.find(i => i.productId == item.productId);
    if (existing) {
      existing.quantity += item.quantity;
    }
    else {
      this.items.push({...item});
    }
  }

  update(productId: string, quantity: number){
    const item = this.items.find(i => i.productId == productId);
    if (item){
      item.quantity = quantity;
    }
  }

  remove(productId:string){
    this.items = this.items.filter(i => i.productId !== productId);
  }

  clear(){
    this.items = [];
  }
}
