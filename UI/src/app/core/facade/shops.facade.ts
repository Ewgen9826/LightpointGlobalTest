import { Injectable } from "@angular/core";
import { ShopsApi } from "../api/shops.api";
import { ShopsState } from "../state/shops.state";
import { Observable } from "rxjs";
import { Shop } from "../models/shop";

@Injectable()
export class ShopsFacade {
  constructor(private shopsApi: ShopsApi, private shopsState: ShopsState) {}

  get isLoading$(): Observable<boolean> {
    return this.shopsState.loading$;
  }

  getShops(): Observable<Shop[]> {
    return this.shopsState.shops$;
  }

  loadShops(): void {
    this.shopsState.setLoading(true);
    this.shopsApi.getAll().subscribe(
      (shops: Shop[]) => {
        this.shopsState.setShops(shops);
      },
      error => {
        console.log(error.message);
        this.shopsState.setLoading(false);
      },
      () => this.shopsState.setLoading(false)
    );
  }

  get responseStatus$(): Observable<boolean> {
    return this.shopsState.responseStatus$;
  }
}
