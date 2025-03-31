import { Component, inject, OnInit, signal } from '@angular/core';
import { HomeService } from '../services/home.service';
import { BreedSize } from '../model/breedsize.type';
import { Pet } from '../model/pet.type';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [HomeService]
})
export class HomeComponent {

}
