
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SocietyService } from '../../../core/services/society.service';
import { AuthService } from '../../../core/services/auth.service';
import { Society, SocietyRequest } from '../../../core/models/society.models';

@Component({
  selector: 'app-society-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
      <div class="px-4 py-6 sm:px-0">
        <div class="flex justify-between items-center mb-6">
          <h1 class="text-3xl font-bold text-gray-900">Society Management</h1>
          <button 
            *ngIf="!society && isAdmin"
            (click)="showCreateForm = true"
            class="btn btn-primary">
            Create Society
          </button>
        </div>

        <div *ngIf="errorMessage" class="alert alert-error mb-6">
          {{ errorMessage }}
        </div>

        <div *ngIf="successMessage" class="alert alert-success mb-6">
          {{ successMessage }}
        </div>

        <!-- Society Information -->
        <div *ngIf="society" class="card mb-6">
          <h2 class="text-xl font-semibold text-gray-900 mb-4">Society Information</h2>
          
          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label class="form-label">Society Name</label>
              <p class="text-gray-900">{{ society.societyName }}</p>
            </div>
            <div>
              <label class="form-label">City</label>
              <p class="text-gray-900">{{ society.city || 'Not specified' }}</p>
            </div>
            <div>
              <label class="form-label">Phone</label>
              <p class="text-gray-900">{{ society.phone || 'Not specified' }}</p>
            </div>
            <div>
              <label class="form-label">Email</label>
              <p class="text-gray-900">{{ society.email || 'Not specified' }}</p>
            </div>
            <div class="md:col-span-2">
              <label class="form-label">Address</label>
              <p class="text-gray-900">{{ society.address || 'Not specified' }}</p>
            </div>
          </div>

          <div *ngIf="isAdmin" class="mt-6 flex space-x-4">
            <button (click)="showEditForm = true" class="btn btn-primary">
              Edit Society
            </button>
            <button (click)="loadApprovalStatus()" class="btn btn-secondary">
              View Approval Status
            </button>
          </div>
        </div>

        <!-- No Society Message -->
        <div *ngIf="!society && !showCreateForm" class="card text-center">
          <h2 class="text-xl font-semibold text-gray-900 mb-4">No Society Configuration Found</h2>
          <p class="text-gray-600 mb-4">No society has been configured in the system yet.</p>
          <button 
            *ngIf="isAdmin"
            (click)="showCreateForm = true"
            class="btn btn-primary">
            Create Society
          </button>
        </div>

        <!-- Create/Edit Form -->
        <div *ngIf="showCreateForm || showEditForm" class="card">
          <h2 class="text-xl font-semibold text-gray-900 mb-4">
            {{ showCreateForm ? 'Create Society' : 'Edit Society' }}
          </h2>
          
          <form [formGroup]="societyForm" (ngSubmit)="onSubmit()">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label for="societyName" class="form-label">Society Name *</label>
                <input
                  id="societyName"
                  type="text"
                  formControlName="societyName"
                  class="form-input"
                  placeholder="Enter society name"
                />
                <div *ngIf="societyForm.get('societyName')?.invalid && societyForm.get('societyName')?.touched" 
                     class="text-red-600 text-sm mt-1">
                  Society name is required
                </div>
              </div>
              
              <div>
                <label for="city" class="form-label">City</label>
                <input
                  id="city"
                  type="text"
                  formControlName="city"
                  class="form-input"
                  placeholder="Enter city"
                />
              </div>
              
              <div>
                <label for="phone" class="form-label">Phone</label>
                <input
                  id="phone"
                  type="text"
                  formControlName="phone"
                  class="form-input"
                  placeholder="Enter phone number"
                />
              </div>
              
              <div>
                <label for="email" class="form-label">Email</label>
                <input
                  id="email"
                  type="email"
                  formControlName="email"
                  class="form-input"
                  placeholder="Enter email address"
                />
              </div>
              
              <div class="md:col-span-2">
                <label for="address" class="form-label">Address</label>
                <textarea
                  id="address"
                  formControlName="address"
                  rows="3"
                  class="form-input"
                  placeholder="Enter full address">
                </textarea>
              </div>
              
              <div>
                <label for="website" class="form-label">Website</label>
                <input
                  id="website"
                  type="url"
                  formControlName="website"
                  class="form-input"
                  placeholder="Enter website URL"
                />
              </div>
              
              <div>
                <label for="registrationNumber" class="form-label">Registration Number</label>
                <input
                  id="registrationNumber"
                  type="text"
                  formControlName="registrationNumber"
                  class="form-input"
                  placeholder="Enter registration number"
                />
              </div>
            </div>

            <div class="mt-6 flex space-x-4">
              <button
                type="submit"
                [disabled]="societyForm.invalid || isLoading"
                class="btn btn-primary">
                <span *ngIf="isLoading">{{ showCreateForm ? 'Creating...' : 'Updating...' }}</span>
                <span *ngIf="!isLoading">{{ showCreateForm ? 'Create Society' : 'Update Society' }}</span>
              </button>
              <button
                type="button"
                (click)="cancelForm()"
                class="btn btn-secondary">
                Cancel
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  `
})
export class SocietyListComponent implements OnInit {
  society: Society | null = null;
  societyForm: FormGroup;
  showCreateForm = false;
  showEditForm = false;
  isLoading = false;
  errorMessage = '';
  successMessage = '';
  isAdmin = false;

  constructor(
    private fb: FormBuilder,
    private societyService: SocietyService,
    private authService: AuthService
  ) {
    this.societyForm = this.fb.group({
      societyName: ['', Validators.required],
      address: [''],
      city: [''],
      phone: [''],
      email: ['', Validators.email],
      website: [''],
      registrationNumber: ['']
    });

    this.isAdmin = this.authService.hasRole('admin');
  }

  ngOnInit() {
    this.loadSociety();
  }

  loadSociety() {
    this.societyService.getSociety().subscribe({
      next: (response) => {
        if (response.success && response.data?.id) {
          this.society = response.data;
        }
      },
      error: (error) => {
        console.error('Error loading society:', error);
      }
    });
  }

  onSubmit() {
    if (this.societyForm.valid) {
      this.isLoading = true;
      this.errorMessage = '';
      this.successMessage = '';

      const societyData: SocietyRequest = {
        ...this.societyForm.value,
        tabs: {
          interest: {
            dividend: 8.5,
            od: 12.0,
            cd: 6.0,
            loan: 10.0,
            emergencyLoan: 15.0,
            las: 7.0
          },
          limit: {
            share: 100000,
            loan: 500000,
            emergencyLoan: 50000
          }
        }
      };

      const operation = this.showCreateForm 
        ? this.societyService.createSociety(societyData)
        : this.societyService.updateSociety(societyData);

      operation.subscribe({
        next: (response) => {
          this.isLoading = false;
          if (response.success) {
            this.successMessage = response.message || 'Operation completed successfully';
            this.cancelForm();
            this.loadSociety();
          } else {
            this.errorMessage = response.message || 'Operation failed';
          }
        },
        error: (error) => {
          this.isLoading = false;
          this.errorMessage = error.error?.message || 'An error occurred';
        }
      });
    }
  }

  cancelForm() {
    this.showCreateForm = false;
    this.showEditForm = false;
    this.societyForm.reset();
  }

  loadApprovalStatus() {
    // Implement approval status loading
    this.successMessage = 'Approval status feature will be implemented';
  }
}
