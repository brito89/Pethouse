import { Routes } from '@angular/router';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { HomeLayoutComponent } from './home/home-layout/home-layout.component';

export const routes: Routes = [
  { path: '', component: HomeLayoutComponent }, // Default route for Home
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      { path: '', redirectTo: 'dash', pathMatch: 'full' },
      { path: 'dash', component: DashboardComponent },
    ],
  }, // Route for Admin
];
