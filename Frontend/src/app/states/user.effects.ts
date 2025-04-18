import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { UserService } from '../services/user.service';
import { catchError, concatMap, map, mergeMap, of, tap } from 'rxjs';
import * as UserActions from './user.actions';
import { SetValueAction } from 'ngrx-forms';
import { FORM_ID } from '../states/user.reducer';

@Injectable()
export class UserEffects {
  private actions$ = inject(Actions);
  private userService = inject(UserService);

  loadUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.loadUsers),
      concatMap(() =>
        this.userService.getAll().pipe(
          map((result) =>
            UserActions.loadUsersSuccess({ users: result.response })
          ),
          catchError((error) =>
            of(UserActions.loadUsersFailure({ error: error.message }))
          )
        )
      )
    );
  });

  loadUser$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.loadUser),
      concatMap(({ id }) =>
        this.userService.getById(id).pipe(
          mergeMap((result) => {
            const user = result.response;
            return [
              new SetValueAction(FORM_ID, user), 
              UserActions.populateForm({ user }), 
            ];
          }),
          catchError((error) =>
            of(UserActions.loadUserFailure({ error: error.message }))
          )
        )
      )
    );
  });

  createUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.createUser),
      concatMap(({ user }) =>
        this.userService.create(user).pipe(
          mergeMap((result) => [
            UserActions.createUserSuccess({ user: result.response }),
            UserActions.loadUsers(),
          ]),
          catchError((error) =>
            of(UserActions.createUserFailure({ error: error.message }))
          )
        )
      )
    );
  });

  deleteUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.deleteUser),
      concatMap(({ id }) =>
        this.userService.delete(id).pipe(
          mergeMap((result) => [
            UserActions.deleteUserSuccess({ result: result.response }),
            UserActions.loadUsers(),
          ]),
          catchError((error) =>
            of(UserActions.deleteUserFailure({ error: error.message }))
          )
        )
      )
    );
  });

  editUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.editUser),
      concatMap(({ user }) =>
        this.userService.update(user).pipe(
          mergeMap((result) => [
            UserActions.editUserSuccess({ user: result.response }),
            UserActions.loadUsers(),
          ]),
          catchError((error) =>
            of(UserActions.editUserFailure({ error: error.message }))
          )
        )
      )
    );
  });
}
