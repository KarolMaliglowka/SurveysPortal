import { Component } from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {FormsModule} from "@angular/forms";
import {NgIf} from "@angular/common";
import {InputTextModule} from "primeng/inputtext";
import {InputTextareaModule} from "primeng/inputtextarea";
import {DropdownModule} from "primeng/dropdown";
import {TagModule} from "primeng/tag";
import {RadioButtonModule} from "primeng/radiobutton";
import {PaginatorModule} from "primeng/paginator";
import {ButtonModule} from "primeng/button";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {RippleModule} from "primeng/ripple";

@Component({
  selector: 'app-user-details',
  standalone: true,
    imports: [
        DialogModule,
        FormsModule,
        NgIf,
        InputTextModule,
        InputTextareaModule,
        DropdownModule,
        TagModule,
        RadioButtonModule,
        PaginatorModule,
        ButtonModule,
        ConfirmDialogModule,
        RippleModule
    ],
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.scss'
})
export class UserDetailsComponent {

}
