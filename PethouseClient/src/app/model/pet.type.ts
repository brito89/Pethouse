import { BreedSize } from "./breedsize.type"

export type Pet  = {
    id: number,
    name: string,
    dateOfBirth: Date,
    breedName: string,
    isMedicated: boolean,
    notes: string,
    breedSize: BreedSize
}