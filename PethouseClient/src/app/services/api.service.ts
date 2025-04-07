import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pet } from '../model/pet.type';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getPets()
  {
    const url = `http://localhost:8080/api/Pets`
    return this.http.get<Array<Pet>>(url);
  }
}
