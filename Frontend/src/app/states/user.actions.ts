import { createAction, props } from '@ngrx/store';
import { User } from '../models/user.model';

export const init = createAction('[User Component] Init');

export const loadUser = createAction(
  '[User Component] One User',
  props<{ id: number }>()
);
export const loadUserSuccess = createAction(
  '[User Component] List Success',
  props<{ result: User }>()
);
export const loadUserFailure = createAction(
  '[User Component] List Failure',
  props<{ error: string }>()
);

export const loadUsers = createAction('[User Component] List');

export const loadUsersSuccess = createAction(
  '[User Component] List Success',
  props<{ users: User[] }>()
);
export const loadUsersFailure = createAction(
  '[User Component] List Failure',
  props<{ error: string }>()
);

export const deleteUser = createAction(
  '[User Component] Delete',
  props<{ id: number }>()
);
export const deleteUserSuccess = createAction(
  '[User Component] Delete Success',
  props<{ result: boolean }>()
);
export const deleteUserFailure = createAction(
  '[User Component] Delete Failure',
  props<{ error: string }>()
);

export const createUser = createAction(
  '[User Component] Create',
  props<{ user: User }>()
);
export const createUserSuccess = createAction(
  '[User Component] Create Success',
  props<{ user: boolean }>()
);
export const createUserFailure = createAction(
  '[User Component] Create Failure',
  props<{ error: string }>()
);

export const editUser = createAction(
  '[User Component] Edit',
  props<{ user: User }>()
);
export const editUserSuccess = createAction(
  '[User Component] Edit Success',
  props<{ user: boolean }>()
);
export const editUserFailure = createAction(
  '[User Component] Edit Failure',
  props<{ error: string }>()
);

export const populateForm = createAction(
  '[User] Populate Form',
  props<{ user: User }>()
);
