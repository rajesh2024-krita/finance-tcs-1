
import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent),
    canActivate: [authGuard]
  },
  {
    path: 'societies',
    loadComponent: () => import('./features/societies/society-list/society-list.component').then(m => m.SocietyListComponent),
    canActivate: [authGuard]
  },
  {
    path: 'users',
    loadComponent: () => import('./features/users/user-list/user-list.component').then(m => m.UserListComponent),
    canActivate: [authGuard]
  },
  {
    path: 'members',
    loadComponent: () => import('./features/members/member-list/member-list.component').then(m => m.MemberListComponent),
    canActivate: [authGuard]
  },
  {
    path: '**',
    redirectTo: '/dashboard'
  }
];
