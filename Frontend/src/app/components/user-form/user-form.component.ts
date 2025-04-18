import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as UserSelectors from '../../states/user.selectors';
import * as UserActions from '../../states/user.actions';
import { FormGroupState } from 'ngrx-forms';
import { User } from 'src/app/models/user.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  loading$: Observable<boolean> = this.store.select(
    UserSelectors.selectLoading
  );
  error$: Observable<string | null> = this.store.select(
    UserSelectors.selectError
  );
  createUser$: Observable<FormGroupState<User>> = this.store.select(
    UserSelectors.selectCreateForm
  );
  @Output() modeChanged = new EventEmitter<'create' | 'edit'>();

  user: User = {
    id: null!,
    name: '',
    last_name: '',
    email: '',
  };

  constructor(
    private store: Store,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');
    const mode = userId ? 'edit' : 'create';
    this.modeChanged.emit(mode);
    
    if (userId) {
      this.store.dispatch(UserActions.loadUser({ id: +userId }));
    }

    this.createUser$.subscribe((userform) => {
      this.user = userform.value;
    });
  }

  OnSubmit() {
    if (this.user.id) {
      console.log(this.user);
      this.store.dispatch(UserActions.editUser({ user: this.user }));
    } else {
      this.store.dispatch(UserActions.createUser({ user: this.user }));
    }
    this.router.navigate(['']);
  }
}
