import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {InputTextModule} from "primeng/inputtext";
import {FormControl, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule} from "@angular/forms";
import {Question} from "../models/question";
import {RippleModule} from "primeng/ripple";
import {InputTextareaModule} from "primeng/inputtextarea";
import {NgIf} from "@angular/common";
import {CheckboxModule} from "primeng/checkbox";
import {StandardQuestionsService} from "../standard-questions.service";
import {InputSwitchModule} from "primeng/inputswitch";

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
        ReactiveFormsModule,
        InputSwitchModule
    ],
    templateUrl: './standard-question-details.component.html',
    styleUrl: './standard-question-details.component.scss'
})
export class StandardQuestionDetailsComponent {
    questionForm = new FormGroup({
        question: new FormControl<string>(''),
        required: new FormControl<boolean>(false)
    })
    @Output() isVisibleChange: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() success: EventEmitter<boolean> = new EventEmitter<boolean>();
    @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

    question: Question;
    visible: boolean = false;
    @Input() isVisible = false;

    constructor(public standardQuestionsService: StandardQuestionsService) {
    }

    ngOnInit(): void {

    }

    hideDialog() {
        this.isVisibleChange.emit(false);
        this.formDirective?.resetForm();
        this.questionForm.reset();
        this.isVisible = false;
    }

    submitForm(_event: any) {
        if (this.questionForm.invalid) {
            return;
        }
        console.log(this.questionForm.value);
        this.standardQuestionsService
                .CreateStandardQuestion(this.questionForm.value)
                .then(r => console.log(r));
        this.success.emit(true);
        this.hideDialog();
    }
}
