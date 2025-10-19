import { Component } from '@angular/core';
import { OrderDetailsDto, ProductOrderDetailsDto } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { UserDetailsDto } from '../../models/user.model';

@Component({
  selector: 'app-order-details',
  standalone: false,
  templateUrl: './order-details.html',
  styleUrl: './order-details.css'
})
export class OrderDetails {
  order?: OrderDetailsDto;
  user?: UserDetailsDto;
  username = '';
  errorMessage = '';

  constructor(private os: OrderService, private us: UserService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    const userId = localStorage.getItem('userId') ?? '';
    const orderId = this.route.snapshot.paramMap.get('id') ?? '';

    if (!userId) {
      this.errorMessage = 'You must be logged in to view an order.';
      this.router.navigateByUrl('/login');
      return;
    }

    if (!orderId) {
      this.errorMessage = 'This order does not exist.';
      this.router.navigateByUrl('/orders');
      return;
    }

    this.us.getDetails(userId).subscribe({
      next: (u: UserDetailsDto) => this.username = u.username,
      error: () => this.username = 'Unknown'
    });

    this.os.getOrderDetails(userId, orderId).subscribe({
      next: (data) => {
        this.order = data;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Failed to load order details.';
      }
    })
  }

  itemTotal(it: ProductOrderDetailsDto): number {
    return it.price * it.quantity;
  }

  goToProducts() {
    this.router.navigateByUrl('/products');
  }

  goToOrders() {
    this.router.navigateByUrl('/orders');
  }
}
