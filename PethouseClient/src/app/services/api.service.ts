import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pet } from '../model/pet.type';
import { Owner } from '../model/owner.type';

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

  getOwners()
  {
    const url = `http://localhost:8080/api/Owners`
    return this.http.get<Array<Owner>>(url);
  }

}
