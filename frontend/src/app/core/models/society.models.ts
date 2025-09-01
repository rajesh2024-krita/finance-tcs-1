
export interface Society {
  id: number;
  societyName: string;
  address?: string;
  city?: string;
  phone?: string;
  fax?: string;
  email?: string;
  website?: string;
  registrationNumber?: string;
  tabs: string;
  isPendingApproval: boolean;
  createdAt: string;
  updatedAt: string;
}

export interface SocietyRequest {
  societyName: string;
  address?: string;
  city?: string;
  phone?: string;
  fax?: string;
  email?: string;
  website?: string;
  registrationNumber?: string;
  tabs?: any;
}

export interface SocietyApprovalStatus {
  hasPendingChanges: boolean;
  changeRequestId?: string;
  totalUsers: number;
  approvedCount: number;
  pendingCount: number;
  approvedUsers: UserApproval[];
  pendingUsers: UserApproval[];
  allUsers: UserApproval[];
  pendingChanges?: string;
}

export interface UserApproval {
  userId: number;
  username: string;
  name?: string;
  email?: string;
  phone?: string;
  edpNo?: string;
  hasApproved: boolean;
  approvedAt?: string;
  status: string;
}
