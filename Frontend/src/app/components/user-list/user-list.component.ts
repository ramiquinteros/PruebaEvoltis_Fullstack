import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as UserActions from '../../states/user.actions';
import * as UserSelectors from '../../states/user.selectors';
import { User } from 'src/app/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
})
export class UserListComponent {
  users$: Observable<User[]> = this.store.select(UserSelectors.selectUsers);
  loading$: Observable<boolean> = this.store.select(
    UserSelectors.selectLoading
  );
  error$: Observable<string | null> = this.store.select(
    UserSelectors.selectError
  );

  constructor(private store: Store, private router: Router) {}

  ngOnInit(): void {
    this.store.dispatch(UserActions.init());
    this.store.dispatch(UserActions.loadUsers());
  }

  onEdit(id: number): void {
    this.router.navigate(['user/edit', id]);
  }

  onDelete(id: number): void {
    this.store.dispatch(UserActions.deleteUser({ id }));
  }
}
