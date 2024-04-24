import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {UsersService} from "../../../users/users.service";
import {ConfirmationService} from "primeng/api";
import {TableColumn} from "../../../users/users-list/users-list.component";
import {Question} from "../models/question";
import {TableModule} from "primeng/table";
import {NgSwitch} from "@angular/common";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";

@Component({
  selector: 'app-standard-questions-list',
  standalone: true,
    imports: [
        TableModule,
        NgSwitch,
        ConfirmDialogModule,
        ConfirmPopupModule
    ],
  templateUrl: './standard-questions-list.component.html',
  styleUrl: './standard-questions-list.component.scss'
})
export class StandardQuestionsListComponent implements OnInit {

    tableColumns: TableColumn<Question>[] = [];
    standardQuestions: Question[] = [];
    isLoading$ = new BehaviorSubject(false);

    constructor(
        public usersService: UsersService,
        private confirmationService: ConfirmationService,
    ) { }
    ngOnInit(): void {
        this.tableColumns = [
            {field: 'text', header: 'question'},
            {field: 'required', header: 'Required'},
        ];

        this.usersService.GetAllUsers().then((value) => {
            this.standardQuestions = value as unknown as Question[];
        });
    }
}
