import { Injectable } from '@angular/core';
import { Http , Response/*, Headers, RequestOptions*/ } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Salad } from '../models/salad';

@Injectable()
export class SaladsService {

  constructor(private http: Http) { }

  private readonly saladsUrl: string = "http://localhost:5000/api/salads";

  getSalads() {
    return this.http.get(this.saladsUrl)
      .map((res:Response) => res.json() as Salad[])
  }
}
