import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Pet } from '../../model/pet.type';
import { ApiService } from '../../services/api.service';
import { Owner } from '../../model/owner.type';
import { PetsComponent } from '../modal/pets/pets.component';

@Component({
  selector: 'app-dashboard',
  imports: [PetsComponent, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: [],
})
export class DashboardComponent implements OnInit {
  constructor(private service: ApiService) {}

  owners = signal<Array<Owner>>([]);
  selectedPets: Array<Pet> = [];

  isModalVisible = false;

  openModal(owner: Owner) {
    this.selectedPets = owner.pets;
    this.isModalVisible = true;
  }

  closeModal() {
    this.isModalVisible = false;
  }

  ngOnInit(): void {
    this.service.getOwners().subscribe((o) => {
      this.owners.set(o);
    });
  }
}
