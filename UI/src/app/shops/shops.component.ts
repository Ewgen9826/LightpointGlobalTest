import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Shop } from "../core/models/shop";
import { ShopsFacade } from "../core/facade/shops.facade";

@Component({
  selector: "app-shops",
  templateUrl: "./shops.component.html",
  styleUrls: ["./shops.component.css"]
})
export class ShopsComponent implements OnInit {
  shops: Observable<Shop[]>;

  displayedColumns: string[] = ["name", "address", "workingHours", "items"];

  constructor(private shopFacade: ShopsFacade) {
    this.shops = this.shopFacade.getShops();
  }

  ngOnInit() {
    this.shopFacade.loadShops();
  }
}
