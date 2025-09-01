
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Sign in to Fintcs
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            Finance Management System
          </p>
        </div>
        
        <form class="mt-8 space-y-6" [formGroup]="loginForm" (ngSubmit)="onSubmit()">
          <div *ngIf="errorMessage" class="alert alert-error">
            {{ errorMessage }}
          </div>
          
          <div class="space-y-4">
            <div>
              <label for="username" class="form-label">Username</label>
              <input
                id="username"
                name="username"
                type="text"
                formControlName="username"
                class="form-input"
                placeholder="Enter username"
              />
              <div *ngIf="loginForm.get('username')?.invalid && loginForm.get('username')?.touched" 
                   class="text-red-600 text-sm mt-1">
                Username is required
              </div>
            </div>
            
            <div>
              <label for="password" class="form-label">Password</label>
              <input
                id="password"
                name="password"
                type="password"
                formControlName="password"
                class="form-input"
                placeholder="Enter password"
              />
              <div *ngIf="loginForm.get('password')?.invalid && loginForm.get('password')?.touched" 
                   class="text-red-600 text-sm mt-1">
                Password is required
              </div>
            </div>
          </div>

          <div>
            <button
              type="submit"
              [disabled]="loginForm.invalid || isLoading"
              class="w-full btn btn-primary"
            >
              <span *ngIf="isLoading">Signing in...</span>
              <span *ngIf="!isLoading">Sign in</span>
            </button>
          </div>
        </form>
        
        <div class="mt-6 text-center text-sm text-gray-600">
          <p>Default admin credentials:</p>
          <p>Username: <code class="bg-gray-100 px-1 rounded">admin</code></p>
          <p>Password: <code class="bg-gray-100 px-1 rounded">admin</code></p>
        </div>
      </div>
    </div>
  `
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading = false;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.isLoading = true;
      this.errorMessage = '';

      this.authService.login(this.loginForm.value).subscribe({
        next: (response) => {
          this.isLoading = false;
          if (response.success) {
            this.router.navigate(['/dashboard']);
          } else {
            this.errorMessage = response.message || 'Login failed';
          }
        },
        error: (error) => {
          this.isLoading = false;
          this.errorMessage = error.error?.message || 'An error occurred during login';
        }
      });
    }
  }
}
