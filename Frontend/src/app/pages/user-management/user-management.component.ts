import { Component } from '@angular/core';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent {
  mode: 'create' | 'edit' = 'create';

  onModeChanged(mode: 'create' | 'edit') {
    this.mode = mode;
  }
}
