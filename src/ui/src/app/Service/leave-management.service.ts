import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { IAddNewLeaveType } from '../Interface/add-new-leave-type-interface';
import { ILeaveBalanceList } from '../Interface/leave-balance-list-interface';
import { ILeaveRequestHistory, ILeaveRequestHistoryResponse } from '../Interface/leave-request-history';
import { IGetLeaveTypeIdAndname } from '../Interface/get-leave-type-interface';
import { ILeaveUpdate, IUpdateLeaveSetting } from '../Interface/update-leave-setting';
import { Observable } from 'rxjs';
import { IEditLeaveType } from '../Interface/edit-leave-type'




@Injectable({
  providedIn: 'root'
})

export class LeaveManagementService {

  constructor() { }
  private http = inject(HttpClient);
  getLeaveBalance(id: number) {
    return this.http.get<Array<ILeaveBalanceList>>(`https://localhost:7015/api/leave-balance?EmployeeId=${id}`);
  }

  getLeaveRequestHistory(id: number, pageNumber: number, pageSize: number): Observable<ILeaveRequestHistoryResponse> {
    return this.http.get<ILeaveRequestHistoryResponse>(`https://localhost:7015/api/leave-request?EmployeeId=${id}&PageNumber=${pageNumber}&PageSize=${pageSize}`); 
  }

  addNewLeaveType(newType: FormGroup<IAddNewLeaveType>) {
    return this.http.post<boolean>("https://localhost:7015/api/leave-type", newType.value)
  }

  getLeaveSetting() {
    return this.http.get<ILeaveUpdate>("https://localhost:7015/api/leave-setting")
  }

  updateLeaveSettings(updateLeaveSettings: FormGroup<IUpdateLeaveSetting>) {
    return this.http.put<boolean>("https://localhost:7015/api/leave-setting", updateLeaveSettings.value)
  }

  getLeaveTypeIdAndName() {
    return this.http.get<Array<IGetLeaveTypeIdAndname>>("https://localhost:7015/api/leave-type")
  }

  editLeaveType(editLeaveType: FormGroup<IEditLeaveType>) {
    return this.http.put('https://localhost:7015/api/leave-type', editLeaveType.value);
  }

  updateLeaveBalance() {
    return this.http.put<boolean>('https://localhost:7015/api/leave-balance', null);
  }
}