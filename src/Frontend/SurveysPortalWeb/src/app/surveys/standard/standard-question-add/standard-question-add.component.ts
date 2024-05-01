import { Component } from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";

@Component({
  selector: 'app-standard-question-add',
  standalone: true,
    imports: [
        DialogModule,
        ConfirmDialogModule
    ],
  templateUrl: './standard-question-add.component.html',
  styleUrl: './standard-question-add.component.scss'
})
export class StandardQuestionAddComponent {
    standardQuestionDialog: boolean;

}
