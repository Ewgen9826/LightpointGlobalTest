import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { Shop } from "../models/shop";

@Injectable()
export class ShopsState {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private shopsSubject = new BehaviorSubject<Shop[]>(null);
  private responseStatusSubject = new Subject<boolean>();

  get shops$(): Observable<Shop[]> {
    return this.shopsSubject.asObservable();
  }
  get loading$(): Observable<boolean> {
    return this.loadingSubject.asObservable();
  }
  get responseStatus$(): Observable<boolean> {
    return this.responseStatusSubject.asObservable();
  }

  setShops(shops: Shop[]) {
    this.shopsSubject.next(shops);
  }
  setLoading(state: boolean) {
    this.loadingSubject.next(state);
  }
  setResponseStatus(state: boolean) {
    this.responseStatusSubject.next(state);
  }

  add(shop: Shop) {
    const currentValue = this.shopsSubject.getValue();
    this.shopsSubject.next([...currentValue, shop]);
  }

  update(updateShop: Shop) {
    const products = this.shopsSubject.getValue();
    const updateProductIndex = products.findIndex(p => p.id === updateShop.id);
    products[updateProductIndex] = updateShop;
    this.shopsSubject.next([...products]);
  }

  remove(removeShop: Shop) {
    const currentValue = this.shopsSubject.getValue();
    this.shopsSubject.next(currentValue.filter(p => p !== removeShop));
  }
}
