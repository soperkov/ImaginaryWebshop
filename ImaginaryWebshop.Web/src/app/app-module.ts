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
import { WarehouseList } from './components/warehouse-list/warehouse-list';
import { WarehouseDetails } from './components/warehouse-details/warehouse-details';
import { WarehouseForm } from './components/warehouse-form/warehouse-form';
import { ProductForm } from './components/product-form/product-form';

@NgModule({
  declarations: [
    App,
    Home,
    Cart,
    Products,
    ProductDetails,
    Orders,
    OrderDetails,
    WarehouseList,
    WarehouseDetails,
    WarehouseForm,
    ProductForm
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
