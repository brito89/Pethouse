import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BreedSize } from '../model/breedsize.type';
import { Pet } from '../model/pet.type';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor() { }

  http = inject(HttpClient);

  getBreedSizesFromAPI()
  {
    const url = `http://localhost:8080/api/BreedSizes`;
    return this.http.get<Array<BreedSize>>(url);
  }

  getPetsFromAPI()
  {
    const url = `http://localhost:8080/api/Pets`
    return this.http.get<Array<Pet>>(url);
  }
}
