import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserFormComponent } from './components/user-form/user-form.component';
import { HomeComponent } from './pages/home/home.component';
import { UserManagementComponent } from './pages/user-management/user-management.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path:'user/create', component: UserManagementComponent },
  { path: 'user/edit/:id', component: UserManagementComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
