import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Cart } from './pages/cart/cart';
import { Products } from './pages/products/products';
import { Orders } from './pages/orders/orders';
import { OrderDetails } from './pages/order-details/order-details';
import { ProductForm } from './pages/product-form/product-form';
import { Login } from './pages/login/login';
import { Navbar } from './shared/navbar/navbar';

@NgModule({
  declarations: [
    App,
    Cart,
    Products,
    Orders,
    OrderDetails,
    ProductForm,
    Login,
    Navbar
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
