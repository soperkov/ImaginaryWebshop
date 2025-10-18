import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Home } from './components/home/home';
import { Cart } from './components/cart/cart';
import { Products } from './components/products/products';
import { ProductDetails } from './components/product-details/product-details';
import { Orders } from './components/orders/orders';
import { OrderDetails } from './components/order-details/order-details';

@NgModule({
  declarations: [
    App,
    Home,
    Cart,
    Products,
    ProductDetails,
    Orders,
    OrderDetails
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
