import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MenuCardsService {

  baseUrl="https://localhost:7134/api/cards";

  constructor(private http: HttpClient) { }

  getAllCards(){

  }
}
