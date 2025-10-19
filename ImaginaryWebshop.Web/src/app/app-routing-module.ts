import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Cart } from './pages/cart/cart';
import { Login } from './pages/login/login';
import { OrderDetails } from './pages/order-details/order-details';
import { Orders } from './pages/orders/orders';
import { ProductForm } from './pages/product-form/product-form';
import { Products } from './pages/products/products';

const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'cart', component: Cart },
  { path: 'orders/:id', component: OrderDetails },
  { path: 'orders', component: Orders },
  { path: 'product-form', component: ProductForm },
  { path: 'products', component: Products },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
