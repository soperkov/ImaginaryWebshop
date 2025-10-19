import { Component } from '@angular/core';
import { CartItem } from '../../models/cart.model';
import { CartService } from '../../services/cart.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cart',
  standalone: false,
  templateUrl: './cart.html',
  styleUrl: './cart.css'
})
export class Cart {
  items: CartItem[] = [];
  private subscription?: Subscription;

  constructor(private cart: CartService, private router: Router) {}

  ngOnInit(): void {
    this.subscription = this.cart.items$.subscribe(list => {
      this.items = list;
    });
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  refresh(): void {
    this.items = this.cart.getItems();
  }

  increase(item: CartItem) {
    this.cart.setQuantity(item.productId, item.quantity + 1);
    this.refresh();
  }

  decrease(item: CartItem) {
    this.cart.setQuantity(item.productId, item.quantity - 1);
    this.refresh();
  }

  remove(item: CartItem) {
    this.cart.remove(item.productId);
    this.refresh();
  }

  clear() {
    this.cart.clear();
    this.refresh();
  }

  total(): number {
    return this.cart.total();
  }

  checkout() {
    
  }

  goToProducts() {
  this.router.navigateByUrl('/products');
}
}
