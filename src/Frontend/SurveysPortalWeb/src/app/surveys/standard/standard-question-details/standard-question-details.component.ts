import {Component, Input} from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {InputTextModule} from "primeng/inputtext";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {Question} from "../models/question";
import {RippleModule} from "primeng/ripple";
import {InputTextareaModule} from "primeng/inputtextarea";
import {NgIf} from "@angular/common";
import {CheckboxModule} from "primeng/checkbox";
import {StandardQuestionsService} from "../standard-questions.service";

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
        CheckboxModule,
        ReactiveFormsModule
    ],
    templateUrl: './standard-question-details.component.html',
    styleUrl: './standard-question-details.component.scss'
})
export class StandardQuestionDetailsComponent {
    question: Question;
    visible: boolean = false;
    @Input() isVisible = false;

    constructor(public standardQuestionsService: StandardQuestionsService) {
    }

    ngOnInit(): void {

    }

    submitForm(): void {
        console.log('Form data:', this.question.question);
        this.question.required = true;
        this.standardQuestionsService.CreateStandardQuestion(this.question).then(r => console.log(r));
        this.isVisible = false;
    }

    hideDialog() {
        this.isVisible = false;
    }
}
