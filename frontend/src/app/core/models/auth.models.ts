
export interface LoginRequest {
  username: string;
  password: string;
}

export interface RegisterRequest {
  username: string;
  password: string;
  email: string;
  phone?: string;
  EDPNo?: string;
  Name?: string;
  AddressOffice?: string;
  AddressResidential?: string;
  Designation?: string;
  PhoneOffice?: string;
  PhoneResidential?: string;
  Mobile?: string;
}

export interface LoginResponse {
  token: string;
  username: string;
  email: string;
  phone?: string;
  roles: string;
  details?: any;
  expiresAt: string;
}

export interface User {
  id: number;
  username: string;
  email: string;
  phone?: string;
  roles: string;
  EDPNo?: string;
  Name?: string;
  AddressOffice?: string;
  AddressResidential?: string;
  Designation?: string;
  PhoneOffice?: string;
  PhoneResidential?: string;
  Mobile?: string;
  createdAt: string;
  updatedAt: string;
}

export interface ApiResponse<T> {
  success: boolean;
  message?: string;
  data?: T;
  errors: string[];
}
