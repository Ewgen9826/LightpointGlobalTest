import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "./../../../environments/environment";
import { Observable } from "rxjs";
import { Item } from "../models/item";
import { map } from "rxjs/operators";

@Injectable()
export class ItemsApi {
  private readonly url = environment.API_URL + "/items";

  constructor(private http: HttpClient) {}

  getAll(shopId: number): Observable<Item[]> {
    return this.http
      .get<Item[]>(`${this.url}?shopId=${shopId}`)
      .pipe(map((data: any) => data.body));
  }

  get(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.url}/${id}`);
  }

  create(item: Item): Observable<Item> {
    return this.http.post<Item>(this.url, item);
  }

  update(item: Item): Observable<any> {
    return this.http.put(`${this.url}/${item.id}`, item);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}
