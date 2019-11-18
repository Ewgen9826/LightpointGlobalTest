import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ShopsComponent } from "./shops/shops.component";
import { ItemsComponent } from "./items/items.component";
import { AddItemComponent } from "./add-item/add-item.component";
import { UpdateItemComponent } from "./update-item/update-item.component";
import { ItemsResolver } from "./core/resolvers/item.resolver";

const routes: Routes = [
  {
    path: "",
    redirectTo: "/shops",
    pathMatch: "full"
  },
  {
    path: "shops",
    component: ShopsComponent
  },
  {
    path: "shops/:id/items",
    component: ItemsComponent
  },
  {
    path: "shops/:id/items/add",
    component: AddItemComponent
  },
  {
    path: "shops/:shopId/items/:itemId/update",
    component: UpdateItemComponent,
    resolve: {
      item: ItemsResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
