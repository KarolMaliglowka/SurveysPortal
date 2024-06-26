import {Component, OnChanges, OnInit, ViewChild} from '@angular/core';
import {Question} from "../models/question";
import {TableModule} from "primeng/table";
import {NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault} from "@angular/common";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {InputTextModule} from "primeng/inputtext";
import {TooltipModule} from "primeng/tooltip";
import {RippleModule} from "primeng/ripple";
import {StandardQuestionsService} from "../standard-questions.service";
import {TableStructure} from "../../../shared/models/table-structure";
import {ToastModule} from "primeng/toast";
import {ToolbarModule} from "primeng/toolbar";
import {FileUploadModule} from "primeng/fileupload";
import {RouterLink} from "@angular/router";
import {StandardQuestionDetailsComponent} from '../standard-question-details/standard-question-details.component'

@Component({
    selector: 'app-standard-questions-list',
    standalone: true,
    imports: [
        TableModule,
        NgSwitch,
        ConfirmDialogModule,
        ConfirmPopupModule,
        InputTextModule,
        TooltipModule,
        RippleModule,
        NgSwitchCase,
        NgSwitchDefault,
        NgForOf,
        ToastModule,
        ToolbarModule,
        FileUploadModule,
        RouterLink,
        StandardQuestionDetailsComponent
    ],
    templateUrl: './standard-questions-list.component.html',
    styleUrl: './standard-questions-list.component.scss'
})
export class StandardQuestionsListComponent implements OnInit {

    tableColumns: TableStructure<Question>[] = [];
    standardQuestions: Question[] = [];
    standardQuestion!: Question;
    submitted: boolean = false;

    @ViewChild('standardQuestionDialog') standardQuestionDialog: StandardQuestionDetailsComponent;

    constructor(
        public standardQuestionsService: StandardQuestionsService
    ) {
    }

    ngOnInit(): void {
        this.tableColumns = [
            {field: 'question', header: 'Question'},
            {field: 'required', header: 'Required'},
        ];

        this.getAllQuestions();
    }

    openNew() {
        this.standardQuestionDialog.question = {};
        this.submitted = false;
        this.standardQuestionDialog.isVisible = true;
    }

    getAllQuestions() {
        this.standardQuestionsService
            .GetAllStandardQuestions()
            .then((value) => {
                this.standardQuestions = value as unknown as Question[];
            });
    }
}
