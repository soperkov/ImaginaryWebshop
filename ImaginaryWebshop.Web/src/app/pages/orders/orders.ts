import { Component } from '@angular/core';
import { OrderDetailsDto } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  standalone: false,
  templateUrl: './orders.html',
  styleUrl: './orders.css'
})
export class Orders {
  orders: OrderDetailsDto[] = [];
  errorMessage= '';
  
  constructor(private os: OrderService, private router: Router) {}

  ngOnInit(): void {
    const userId = localStorage.getItem('userId');
    if (!userId) {
      this.errorMessage = 'You must be logged in to view your orders!';
      this.router.navigateByUrl('/login');
      return;
    }
    this.os.getAllOrders(userId).subscribe({
      next: (res) => {
        this.orders = [ ...res ].sort(
          (a, b) => new Date(b.orderDate).getTime() - new Date(a.orderDate).getTime()
        );
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to load orders.';
      }
    })
  }

  open(order: OrderDetailsDto) {
    this.router.navigateByUrl(`/orders/${order.id}`);
  }

  goToProducts() {
    this.router.navigateByUrl('/products');
  }

  trackById(_: number, o: OrderDetailsDto) {
    return o.id;
  }
}
