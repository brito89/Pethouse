import { Component, inject, OnInit, signal } from '@angular/core';
import { Pet } from '../../model/pet.type';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: []
})
export class DashboardComponent implements OnInit {
  
  constructor(private service: ApiService) { }

  petItems = signal<Array<Pet>>([]);

  ngOnInit(): void {
    this.service.getPets().subscribe((pet) => {
      this.petItems.set(pet);
    });
  }

}
