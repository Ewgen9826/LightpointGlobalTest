import { Injectable } from "@angular/core";
import { ItemsApi } from "../api/items.api";
import { ItemsState } from "../state/items.state";
import { Observable } from "rxjs";
import { Item } from "../models/item";

@Injectable()
export class ItemsFacade {
  constructor(private itemsApi: ItemsApi, private itemsState: ItemsState) {}

  get isLoading$(): Observable<boolean> {
    return this.itemsState.loading$;
  }

  getItems(): Observable<Item[]> {
    return this.itemsState.items$;
  }

  getSingle(id: number): Observable<Item> {
    return this.itemsApi.get(id);
  }

  loadItems(shopId: number): void {
    this.itemsState.setLoading(true);
    this.itemsApi.getAll(shopId).subscribe(
      (items: Item[]) => {
        this.itemsState.setItems(items);
      },
      error => {
        console.log(error.message);
        this.itemsState.setLoading(false);
      },
      () => this.itemsState.setLoading(false)
    );
  }

  add(item: Item): void {
    this.itemsState.setLoading(true);
    this.itemsState.add(item);

    this.itemsApi.create(item).subscribe(
      (addItem: Item) => {
        console.log(addItem);
        this.itemsState.setResponseStatus(true);
        this.itemsState.update(addItem);
      },
      error => {
        this.itemsState.setResponseStatus(false);
        this.itemsState.remove(item);
      },
      () => this.itemsState.setLoading(false)
    );
  }

  update(updateItem: Item) {
    this.itemsState.setLoading(true);
    this.itemsApi.update(updateItem).subscribe(
      () => {
        this.itemsState.update(updateItem);
        this.itemsState.setResponseStatus(true);
      },
      error => {
        this.itemsState.setResponseStatus(false);
        console.log(error);
      },
      () => {
        this.itemsState.setLoading(false);
      }
    );
  }

  remove(removeItem: Item) {
    this.itemsState.setLoading(true);
    this.itemsApi.delete(removeItem.id).subscribe(
      () => {
        this.itemsState.remove(removeItem);
        this.itemsState.setResponseStatus(true);
      },
      error => {
        this.itemsState.add(removeItem);
        this.itemsState.setResponseStatus(false);
      },
      () => this.itemsState.setLoading(false)
    );
  }

  get responseStatus$(): Observable<boolean> {
    return this.itemsState.responseStatus$;
  }
}
