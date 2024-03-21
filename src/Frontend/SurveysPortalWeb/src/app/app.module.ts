import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {UsersListComponent} from './users/users-list/users-list.component';
import {UserDetailsComponent} from './users/user-details/user-details.component';
import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {FormsModule} from "@angular/forms";
import {RippleModule} from "primeng/ripple";
import {TableModule} from "primeng/table";
import {MenuModule} from "primeng/menu";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ApiService} from "./services/api.service";
import {HttpClientModule} from "@angular/common/http";
import {ConfirmationService} from "primeng/api";
import {SelectButtonModule} from "primeng/selectbutton";

@NgModule({
  declarations: [
    AppComponent,
    UsersListComponent,
    UserDetailsComponent
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        ButtonModule,
        InputTextModule,
        FormsModule,
        RippleModule,
        TableModule,
        MenuModule,
        ConfirmPopupModule,
        ConfirmDialogModule,
        HttpClientModule,
        SelectButtonModule
    ],
  providers: [
    ApiService,
    ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
