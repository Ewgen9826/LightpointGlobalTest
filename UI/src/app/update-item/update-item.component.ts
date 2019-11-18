import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs";
import { Item } from "../core/models/item";
import { map } from "rxjs/operators";
import { ItemActionEnum } from "../core/enums/item-action.enum";
import { ItemsFacade } from "../core/facade/items.facade";

@Component({
  selector: "app-update-item",
  templateUrl: "./update-item.component.html"
})
export class UpdateItemComponent implements OnInit {
  itemAction = ItemActionEnum.Update;
  item$: Observable<Item>;
  loading$: Observable<boolean>;
  shopId: number;

  constructor(
    private activateRouter: ActivatedRoute,
    private router: Router,
    private itemsFacade: ItemsFacade
  ) {
    this.item$ = this.activateRouter.data.pipe(map(data => data.item));
    this.loading$ = this.itemsFacade.isLoading$;

    this.activateRouter.paramMap.subscribe(params => {
      this.shopId = +params.get("id");
    });
  }

  ngOnInit() {}

  update(item: Item) {
    this.itemsFacade.update(item);

    this.itemsFacade.responseStatus$.subscribe(result => {
      if (result) {
        console.log(item);
        this.router.navigateByUrl(`/shops/${item.shopId}/items`);
      }
    });
  }
}
