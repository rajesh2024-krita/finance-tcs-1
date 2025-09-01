
export interface Member {
  id: number;
  memNo: string;
  name: string;
  fhName?: string;
  officeAddress?: string;
  city?: string;
  phoneOffice?: string;
  branch?: string;
  phoneRes?: string;
  mobile?: string;
  designation?: string;
  residenceAddress?: string;
  dob?: string;
  dojSociety?: string;
  email?: string;
  dojOrg?: string;
  dor?: string;
  nominee?: string;
  nomineeRelation?: string;
  bankingDetails: string;
  isPendingApproval: boolean;
  createdAt: string;
  updatedAt: string;
}

export interface MemberRequest {
  name: string;
  fhName?: string;
  officeAddress?: string;
  city?: string;
  phoneOffice?: string;
  branch?: string;
  phoneRes?: string;
  mobile?: string;
  designation?: string;
  residenceAddress?: string;
  dob?: string;
  dojSociety?: string;
  email?: string;
  dojOrg?: string;
  dor?: string;
  nominee?: string;
  nomineeRelation?: string;
  bankingDetails?: BankingDetails;
}

export interface BankingDetails {
  bankName?: string;
  accountNumber?: string;
  ifscCode?: string;
  branch?: string;
}
