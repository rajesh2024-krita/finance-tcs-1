
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Society, SocietyRequest, SocietyApprovalStatus, ApiResponse } from '../models/society.models';

@Injectable({
  providedIn: 'root'
})
export class SocietyService {
  private apiUrl = 'http://localhost:5000/api/society';

  constructor(private http: HttpClient) {}

  getSociety(): Observable<ApiResponse<Society>> {
    return this.http.get<ApiResponse<Society>>(this.apiUrl);
  }

  createSociety(society: SocietyRequest): Observable<ApiResponse<Society>> {
    return this.http.post<ApiResponse<Society>>(this.apiUrl, society);
  }

  updateSociety(society: SocietyRequest): Observable<ApiResponse<any>> {
    return this.http.put<ApiResponse<any>>(this.apiUrl, society);
  }

  approveChanges(): Observable<ApiResponse<any>> {
    return this.http.post<ApiResponse<any>>(`${this.apiUrl}/approve-changes`, {});
  }

  getApprovalStatus(): Observable<ApiResponse<SocietyApprovalStatus>> {
    return this.http.get<ApiResponse<SocietyApprovalStatus>>(`${this.apiUrl}/approval-status`);
  }

  getPendingChanges(): Observable<ApiResponse<any>> {
    return this.http.get<ApiResponse<any>>(`${this.apiUrl}/pending-changes`);
  }
}
