import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";
import {UsersListComponent} from "./users/users-list/users-list.component";
import {UserDetailsComponent} from "./users/user-details/user-details.component";

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'list', component: UsersListComponent },
  { path: 'details', component: UserDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
