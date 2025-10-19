import { Component } from '@angular/core';
import { CartItem } from '../../models/cart.model';
import { CartService } from '../../services/cart.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { OrderService } from '../../services/order.service';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-cart',
  standalone: false,
  templateUrl: './cart.html',
  styleUrl: './cart.css'
})
export class Cart {
  items: CartItem[] = [];
  private subscription?: Subscription;

  constructor(private cart: CartService, private os: OrderService, private router: Router) {}

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
    const userId = localStorage.getItem('userId');
    if (!userId) {
      alert('You must be logged in to place an order.');
      this.router.navigateByUrl('/login');
      return;
    }

    const order = {
    userId,
    items: this.items.map(it => ({
      productId: it.productId,
      quantity: it.quantity,
    })),
  };

    this.os.createOrder(order).subscribe({
      next: (orderId: string) => {
        this.cart.clear();
        this.router.navigateByUrl(`/orders/${orderId}`);
      },
      error: (err) => {
      console.error(err);
      alert('Could not place the order. Please try again.');
    }
    })
  }

  goToProducts() {
    this.router.navigateByUrl('/products');
  }

  imgSrc(u?: string | null): string {
    if (!u) return 'assets/placeholder.png';
    if (/^https?:\/\//i.test(u)) return u;
    const base = new URL(environment.apiBaseUrl, window.location.origin);
    return `${base.origin}${u.startsWith('/') ? u : '/' + u}`;
  }
}
