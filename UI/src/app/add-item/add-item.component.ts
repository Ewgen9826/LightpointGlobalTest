import { Component, OnInit } from "@angular/core";
import { ItemActionEnum } from "../core/enums/item-action.enum";
import { Observable } from "rxjs";
import { ItemsFacade } from "../core/facade/items.facade";
import { Item } from "./../core/models/item";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-add-item",
  templateUrl: "./add-item.component.html"
})
export class AddItemComponent implements OnInit {
  itemAction = ItemActionEnum.Add;

  shopId: number;

  loading$: Observable<boolean>;

  constructor(
    private itemsFacade: ItemsFacade,
    private router: Router,
    private routeActive: ActivatedRoute
  ) {
    this.loading$ = this.itemsFacade.isLoading$;
  }

  ngOnInit() {
    this.routeActive.paramMap.subscribe(params => {
      this.shopId = +params.get("id");
    });
  }

  add(item: Item) {
    item.shopId = this.shopId;
    this.itemsFacade.add(item);

    this.itemsFacade.responseStatus$.subscribe(resutl => {
      if (resutl) {
        this.router.navigateByUrl(`/shops/${this.shopId}/items`);
      }
    });
  }
}
