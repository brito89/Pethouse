import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';

export const routes: Routes = [
    { path: '', component: HomeComponent }, // Default route for Home
    { path: 'admin', component: DashboardComponent } // Route for Admin

];
