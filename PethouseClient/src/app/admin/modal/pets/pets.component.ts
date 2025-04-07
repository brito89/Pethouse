import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Pet } from '../../../model/pet.type';

@Component({
  selector: 'app-pets',
  imports: [CommonModule],
  templateUrl: './pets.component.html',
  styleUrl: './pets.component.css',
})
export class PetsComponent {
  @Input() isVisible: boolean = false;
  @Input() pets: Array<Pet> = [];
  @Output() close = new EventEmitter<void>();

  calculatePetAge(dateOfBirth: Date): number {
    if (!(dateOfBirth instanceof Date)) {
      dateOfBirth = new Date(dateOfBirth); // Convert to a Date object
    }
    const currentYear = new Date().getFullYear();
    return currentYear - dateOfBirth.getFullYear();
  }

  closeModal() {
    this.close.emit();
  }
}
