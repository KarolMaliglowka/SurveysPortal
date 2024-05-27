import {Component, OnInit} from '@angular/core';
import {ButtonModule} from "primeng/button";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {FileUploadModule} from "primeng/fileupload";
import {NgForOf, NgSwitch, NgSwitchCase, NgSwitchDefault} from "@angular/common";
import {RippleModule} from "primeng/ripple";
import {ConfirmationService, SharedModule} from "primeng/api";
import {TableModule} from "primeng/table";
import {ToolbarModule} from "primeng/toolbar";
import {TooltipModule} from "primeng/tooltip";
import {RouterLink} from "@angular/router";
import {TableStructure} from "../../../shared/models/table-structure";
import {BehaviorSubject} from "rxjs";
import {StandardSurveysService} from "../standard-surveys.service";
import {Survey} from "../models/survey";

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
        NgSwitch,
        NgSwitchDefault
    ],
    templateUrl: './standard-surveys-list.component.html',
    styleUrl: './standard-surveys-list.component.scss'
})
export class StandardSurveysListComponent implements OnInit {

    tableColumns: TableStructure<Survey>[] = [];
    standardSurveys: Survey[] = [];
    isLoading$ = new BehaviorSubject(false);
    standardSurvey: Survey;

    constructor(
        public standardSurveysService: StandardSurveysService
    ) {
    }

    ngOnInit(): void {
        this.tableColumns = [
            {field: 'name', header: 'Survey name'},
            {field: 'description', header: 'Description'},
            {field: 'introduction', header: 'Introduction'}
        ];

        this.standardSurveysService
            .GetAllStandardSurveys()
            .then((value) => {
                this.standardSurveys = value as unknown as Survey[];
            });
    }
}
