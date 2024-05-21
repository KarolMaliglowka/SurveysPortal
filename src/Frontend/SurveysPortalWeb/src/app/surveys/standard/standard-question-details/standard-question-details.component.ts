import { Component } from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";

@Component({
  selector: 'app-standard-question-details',
  standalone: true,
    imports: [
        DialogModule,
        ConfirmDialogModule
    ],
  templateUrl: './standard-question-details.component.html',
  styleUrl: './standard-question-details.component.scss'
})
export class StandardQuestionDetailsComponent {
    standardQuestionDialog: boolean;

}
