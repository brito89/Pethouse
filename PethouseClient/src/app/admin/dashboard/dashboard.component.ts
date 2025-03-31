import { Component, inject, OnInit, signal } from '@angular/core';
import { Pet } from '../../model/pet.type';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: []
})
export class DashboardComponent implements OnInit {
  
  service = inject(DashboardService);
  petItems = signal<Array<Pet>>([]);

  ngOnInit(): void {
    this.service.getPetsFromAPI().subscribe((pet) => {
      this.petItems.set(pet);
    });
  }

}
