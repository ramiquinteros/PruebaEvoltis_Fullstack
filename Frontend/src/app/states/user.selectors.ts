import { createFeatureSelector, createSelector } from '@ngrx/store';
import { UserState } from './user.state';

export const selectUserState = createFeatureSelector<UserState>('user');

export const selectUsers = createSelector(
  selectUserState,
  (state: UserState) => state.users
);
export const selectSelectedUser = createSelector(
  selectUserState,
  (state: UserState) => state.selectedUser
);
export const selectCreateForm = createSelector(
  selectUserState,
  (state: UserState) => state.createUserForm
);


export const selectLoading = createSelector(
  selectUserState,
  (state: UserState) => state.loading
);
export const selectError = createSelector(
  selectUserState,
  (state: UserState) => state.error
);
