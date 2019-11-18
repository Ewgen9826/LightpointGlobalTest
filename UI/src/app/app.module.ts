import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import {
  MatTableModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatProgressSpinnerModule,
  MatIconModule
} from "@angular/material";

import { ShopsComponent } from "./shops/shops.component";
import { ItemsComponent } from "./items/items.component";
import { HttpClientModule } from "@angular/common/http";
import { ShopsState } from "./core/state/shops.state";
import { ItemsState } from "./core/state/items.state";
import { ShopsApi } from "./core/api/shops.api";
import { ItemsApi } from "./core/api/items.api";
import { ShopsFacade } from "./core/facade/shops.facade";
import { ItemsFacade } from "./core/facade/items.facade";
import { ItemDetailsComponent } from "./item-details/item-details.component";
import { FormsModule } from "@angular/forms";
import { AddItemComponent } from "./add-item/add-item.component";
import { UpdateItemComponent } from "./update-item/update-item.component";
import { ItemsResolver } from "./core/resolvers/item.resolver";

@NgModule({
  declarations: [
    AppComponent,
    ShopsComponent,
    ItemsComponent,
    ItemDetailsComponent,
    AddItemComponent,
    UpdateItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatIconModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ShopsState,
    ItemsState,
    ShopsApi,
    ItemsApi,
    ShopsFacade,
    ItemsFacade,
    ItemsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
