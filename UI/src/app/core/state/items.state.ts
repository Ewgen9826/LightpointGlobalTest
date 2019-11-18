import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { Item } from "../models/item";

@Injectable()
export class ItemsState {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private itemsSubject = new BehaviorSubject<Item[]>(null);
  private responseStatusSubject = new Subject<boolean>();

  get items$(): Observable<Item[]> {
    return this.itemsSubject.asObservable();
  }
  get loading$(): Observable<boolean> {
    return this.loadingSubject.asObservable();
  }
  get responseStatus$(): Observable<boolean> {
    return this.responseStatusSubject.asObservable();
  }

  setItems(items: Item[]) {
    this.itemsSubject.next(items);
  }
  setLoading(state: boolean) {
    this.loadingSubject.next(state);
  }
  setResponseStatus(state: boolean) {
    this.responseStatusSubject.next(state);
  }

  add(item: Item) {
    const currentValue = this.itemsSubject.getValue();
    this.itemsSubject.next([...currentValue, item]);
  }

  update(updateItem: Item) {
    const items = this.itemsSubject.getValue();
    if (!items) return;
    const updateProductIndex = items.findIndex(p => p.id === updateItem.id);
    items[updateProductIndex] = updateItem;
    this.itemsSubject.next([...items]);
  }

  remove(removeItem: Item) {
    const currentValue = this.itemsSubject.getValue();
    this.itemsSubject.next(currentValue.filter(p => p !== removeItem));
  }
}
