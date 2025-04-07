import { Pet } from "./pet.type"


export type Owner  = {
    id: string,
    name: string,
    email: string,
    phoneNumber: string,
    address: string,
    emergencyContactName: string,
    emergencyContactPhone: string,
    emergencyContactRelationship: string,
    pets: Array<Pet>
}