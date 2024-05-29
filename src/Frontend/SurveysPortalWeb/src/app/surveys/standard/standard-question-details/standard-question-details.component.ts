import { Component } from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {InputTextModule} from "primeng/inputtext";
import {FormBuilder, FormsModule, Validators} from "@angular/forms";
import {Question} from "../models/question";
import {RippleModule} from "primeng/ripple";
import {InputTextareaModule} from "primeng/inputtextarea";
import {NgIf} from "@angular/common";
import {CheckboxModule} from "primeng/checkbox";

@Component({
  selector: 'app-standard-question-details',
  standalone: true,
    imports: [
        DialogModule,
        ConfirmDialogModule,
        InputTextModule,
        FormsModule,
        RippleModule,
        InputTextareaModule,
        NgIf,
        CheckboxModule
    ],
  templateUrl: './standard-question-details.component.html',
  styleUrl: './standard-question-details.component.scss'
})
export class StandardQuestionDetailsComponent {
    standardQuestionDialog: boolean;
    question: Question;
    submitted: boolean;
    mode: string;

    questionForm: any;

    constructor(private formBuilder: FormBuilder) {}

    ngOnInit(): void {
        this.questionForm = this.formBuilder.group({
            question: ['', Validators.required],
            required: [true]
        })
    }
}
