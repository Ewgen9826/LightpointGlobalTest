import {
  Resolve,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from "@angular/router";
import { ItemsFacade } from "../facade/items.facade";
import { Observable } from "rxjs";
import { catchError } from "rxjs/operators";
import { Item } from "../models/item";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class ItemsResolver implements Resolve<boolean | Item> {
  constructor(private itemsFacade: ItemsFacade, private router: Router) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | Item> {
    return this.itemsFacade
      .getSingle(route.params.itemId)
      .pipe(catchError(err => this.router.navigateByUrl("/home")));
  }
}
