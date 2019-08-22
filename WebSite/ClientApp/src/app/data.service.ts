import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {
  baseUrl: string = "http://localhost:58829";

  constructor(private httpClient: HttpClient) { }

  getUsers() {
    return this.httpClient.get(this.baseUrl + '/api/user');
  }

}
