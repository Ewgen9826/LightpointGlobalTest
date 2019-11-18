import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { Item } from "../core/models/item";
import { ItemsFacade } from "../core/facade/items.facade";
import { switchMap } from "rxjs/operators";

@Component({
  selector: "app-items",
  templateUrl: "./items.component.html",
  styleUrls: ["./items.component.css"]
})
export class ItemsComponent implements OnInit {
  items: Observable<Item[]>;
  shopId: number;
  displayedColumns: string[] = ["name", "description", "action"];

  constructor(private itemsFacade: ItemsFacade, private route: ActivatedRoute) {
    this.items = itemsFacade.getItems();
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.shopId = +params.get("id");
      this.itemsFacade.loadItems(this.shopId);
    });
  }

  remove(item: Item) {
    this.itemsFacade.remove(item);
  }
}
