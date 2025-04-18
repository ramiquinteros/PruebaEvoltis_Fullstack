import { createReducer, on } from '@ngrx/store';
import { UserState } from './user.state';
import * as UserActions from './user.actions';
import { createFormGroupState, onNgrxForms, SetValueAction } from 'ngrx-forms';
import { User } from '../models/user.model';

export const FORM_ID = 'createUserForm';

const userFormState = createFormGroupState<User>(FORM_ID, {
  id: null!,
  name: '',
  last_name: '',
  email: '',
});

const initialState: UserState = {
  users: [],
  selectedUser: null,
  loading: false,
  error: null,
  createUserForm: userFormState,
};

export const userReducer = createReducer(
  initialState,

  onNgrxForms(),

  on(UserActions.init, (state) => ({
    ...initialState,
    loading: false,
    error: null,
    selectedUser: null,
  })),
  on(UserActions.loadUsers, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(UserActions.loadUsersSuccess, (state, { users }) => ({
    ...state,
    users,
    loading: false,
  })),
  on(UserActions.loadUsersFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  })),
  on(UserActions.createUser, (state) => ({
    ...state,
    error: null,
    loading: true,
    selectedUser: null,
    users: [],
  })),
  on(UserActions.createUserSuccess, (state) => ({
    ...state,
    error: null,
    loading: false,
    selectedUser: null,
    users: [],
  })),
  on(UserActions.createUserFailure, (state, { error }) => ({
    ...state,
    error: error,
    loading: false,
    selectedUser: null,
    users: [],
  })),
  on(UserActions.populateForm, (state, { user }) => {
    return {
      ...state,
      selectedUser: user,
    };
  })
);
