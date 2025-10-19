import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Cart } from './pages/cart/cart';
import { Products } from './pages/products/products';
import { ProductDetails } from './pages/product-details/product-details';
import { Orders } from './pages/orders/orders';
import { OrderDetails } from './pages/order-details/order-details';
import { WarehouseList } from './pages/warehouse-list/warehouse-list';
import { WarehouseDetails } from './pages/warehouse-details/warehouse-details';
import { WarehouseForm } from './pages/warehouse-form/warehouse-form';
import { ProductForm } from './pages/product-form/product-form';
import { Login } from './pages/login/login';

@NgModule({
  declarations: [
    App,
    Cart,
    Products,
    ProductDetails,
    Orders,
    OrderDetails,
    WarehouseList,
    WarehouseDetails,
    WarehouseForm,
    ProductForm,
    Login
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
