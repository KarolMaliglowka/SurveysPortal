import { NgModule } from '@angular/core';
import {
    LocationStrategy, NgClass,
    NgForOf, NgIf,
    NgSwitch,
    NgSwitchCase, NgSwitchDefault,
    PathLocationStrategy
} from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import {ButtonModule} from "primeng/button";
import {TableModule} from "primeng/table";
import {InputTextModule} from "primeng/inputtext";
import {TooltipModule} from "primeng/tooltip";
import {RippleModule} from "primeng/ripple";
import {MenuModule} from "primeng/menu";
import {StyleClassModule} from "primeng/styleclass";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {UsersListComponent} from "./users/users-list/users-list.component";
import {ApiService} from "./services/api.service";
import {ConfirmationService} from "primeng/api";
import {
    StandardQuestionsListComponent
} from "./surveys/standard/standard-questions-list/standard-questions-list.component";
import {StandardSurveysListComponent} from "./surveys/standard/standard-surveys-list/standard-surveys-list.component";

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        AppRoutingModule,
        AppLayoutModule,
        ButtonModule,
        TableModule,
        InputTextModule,
        TooltipModule,
        RippleModule,
        MenuModule,
        NgSwitch,
        NgSwitchCase,
        NgForOf,
        NgSwitchDefault,
        StyleClassModule,
        NgClass,
        NgIf,
        ConfirmPopupModule,
        ConfirmDialogModule,
        UsersListComponent,
        InputTextModule,
        StandardQuestionsListComponent,
        StandardSurveysListComponent

    ],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        ApiService, ConfirmationService
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
