import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "./../../../environments/environment";
import { Observable, from } from "rxjs";
import { map } from "rxjs/operators";
import { Shop } from "../models/shop";

@Injectable()
export class ShopsApi {
  private readonly url = environment.API_URL + "/shops";

  constructor(private http: HttpClient) {}

  getAll(): Observable<Shop[]> {
    return this.http.get<Shop[]>(this.url).pipe(map((data: any) => data.body));
  }
}
