
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, Router } from '@angular/router';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  template: `
    <div class="min-h-screen bg-gray-50">
      <nav *ngIf="authService.isLoggedIn()" class="bg-white shadow-sm border-b">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div class="flex justify-between h-16">
            <div class="flex items-center">
              <h1 class="text-xl font-semibold text-gray-900">Fintcs</h1>
              <div class="ml-10 flex items-center space-x-4">
                <a routerLink="/dashboard" class="text-gray-600 hover:text-gray-900 px-3 py-2 rounded-md text-sm font-medium">Dashboard</a>
                <a routerLink="/societies" class="text-gray-600 hover:text-gray-900 px-3 py-2 rounded-md text-sm font-medium">Society</a>
                <a routerLink="/users" class="text-gray-600 hover:text-gray-900 px-3 py-2 rounded-md text-sm font-medium">Users</a>
                <a routerLink="/members" class="text-gray-600 hover:text-gray-900 px-3 py-2 rounded-md text-sm font-medium">Members</a>
              </div>
            </div>
            <div class="flex items-center">
              <span class="text-sm text-gray-600 mr-4">{{ authService.getCurrentUser()?.username }}</span>
              <button (click)="logout()" class="btn btn-secondary text-sm">Logout</button>
            </div>
          </div>
        </div>
      </nav>
      
      <main>
        <router-outlet></router-outlet>
      </main>
    </div>
  `
})
export class AppComponent {
  constructor(
    public authService: AuthService,
    private router: Router
  ) {}

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
