import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {ConfirmationService} from "primeng/api";
import {TableColumn} from "../../../users/users-list/users-list.component";
import {Question} from "../models/question";
import {TableModule} from "primeng/table";
import {NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault} from "@angular/common";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {InputTextModule} from "primeng/inputtext";
import {TooltipModule} from "primeng/tooltip";
import {RippleModule} from "primeng/ripple";
import {StandardQuestionsService} from "../standard-questions.service";

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
        NgForOf
    ],
  templateUrl: './standard-questions-list.component.html',
  styleUrl: './standard-questions-list.component.scss'
})
export class StandardQuestionsListComponent implements OnInit {

    tableColumns: TableColumn<Question>[] = [];
    standardQuestions: Question[] = [];
    isLoading$ = new BehaviorSubject(false);

    constructor(
        public standardQuestionsService: StandardQuestionsService,
        private confirmationService: ConfirmationService,
    ) { }
    ngOnInit(): void {
        this.tableColumns = [
            {field: 'text', header: 'Question'},
            {field: 'required', header: 'Required'},
        ];

        this.standardQuestionsService.GetAllStandardQuestions().then((value) => {
            this.standardQuestions = value as unknown as Question[];
            console.log(this.standardQuestions);
        });
    }
}
