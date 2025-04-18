import { FormGroupState } from "ngrx-forms";
import { User } from "../models/user.model";

export interface UserState {
    users: User[];
    selectedUser: User | null;
    loading: boolean;
    error: string | null,
    createUserForm: FormGroupState<User>
}