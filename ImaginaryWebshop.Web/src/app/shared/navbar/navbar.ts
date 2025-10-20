import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from '../../services/cart.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar {
  itemNumber = 0;
  private subscription?: Subscription;

  constructor(private router: Router, private cs: CartService) {}

  ngOnInit(): void {
    this.subscription = this.cs.items$.subscribe(() => {
      this.itemNumber = this.cs.totalItems();
    });
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  logout() {
    localStorage.removeItem('userId');
    localStorage.removeItem('cart_items');
    localStorage.removeItem('cart_stockMap');
    this.router.navigateByUrl('/login');
  }
}
