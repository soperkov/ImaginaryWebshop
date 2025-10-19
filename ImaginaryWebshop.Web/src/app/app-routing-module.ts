import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Cart } from './pages/cart/cart';
import { Home } from './pages/home/home';
import { Login } from './pages/login/login';
import { OrderDetails } from './pages/order-details/order-details';
import { Orders } from './pages/orders/orders';
import { ProductDetails } from './pages/product-details/product-details';
import { ProductForm } from './pages/product-form/product-form';
import { Products } from './pages/products/products';
import { WarehouseDetails } from './pages/warehouse-details/warehouse-details';
import { WarehouseForm } from './pages/warehouse-form/warehouse-form';
import { WarehouseList } from './pages/warehouse-list/warehouse-list';

const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'home', component: Home },
  { path: 'cart', component: Cart },
  { path: 'orders/:id', component: OrderDetails },
  { path: 'orders', component: Orders },
  { path: 'products/:id', component: ProductDetails },
  { path: 'product-form', component: ProductForm },
  { path: 'products', component: Products },
  { path: 'warehouse/:id', component: WarehouseDetails },
  { path: 'warehouse-form', component: WarehouseForm },
  { path: 'warehouse-list', component: WarehouseList },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
