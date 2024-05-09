import { Component } from '@angular/core';
import {ButtonModule} from "primeng/button";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {FileUploadModule} from "primeng/fileupload";
import {NgForOf, NgSwitch, NgSwitchCase} from "@angular/common";
import {RippleModule} from "primeng/ripple";
import {SharedModule} from "primeng/api";
import {TableModule} from "primeng/table";
import {ToolbarModule} from "primeng/toolbar";
import {TooltipModule} from "primeng/tooltip";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-standard-surveys-list',
  standalone: true,
    imports: [
        ButtonModule,
        ConfirmDialogModule,
        ConfirmPopupModule,
        FileUploadModule,
        NgForOf,
        NgSwitchCase,
        RippleModule,
        SharedModule,
        TableModule,
        ToolbarModule,
        TooltipModule,
        RouterLink,
        NgSwitch
    ],
  templateUrl: './standard-surveys-list.component.html',
  styleUrl: './standard-surveys-list.component.scss'
})
export class StandardSurveysListComponent {

}
