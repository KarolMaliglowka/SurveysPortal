import {Component, OnInit} from '@angular/core';
import {UsersService} from "../users.service";
import {User} from "../models/user";
import {BehaviorSubject} from "rxjs";
import {ConfirmationService} from "primeng/api";
import {TableModule} from "primeng/table";
import {NgClass, NgForOf, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault} from "@angular/common";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {MenuModule} from "primeng/menu";
import {RippleModule} from "primeng/ripple";
import {StyleClassModule} from "primeng/styleclass";
import {InputTextModule} from "primeng/inputtext";
import {TableStructure} from "../../shared/models/table-structure";

@Component({
    selector: 'app-users-list',
    standalone: true,
    templateUrl: './users-list.component.html',
    imports: [
        TableModule,
        NgSwitchDefault,
        NgSwitchDefault,
        NgSwitchDefault,
        NgSwitchCase,
        NgForOf,
        NgSwitchCase,
        NgSwitchCase,
        NgSwitchCase,
        NgForOf,
        NgForOf,
        NgSwitchCase,
        NgSwitch,
        NgIf,
        NgClass,
        ConfirmDialogModule,
        ConfirmPopupModule,
        MenuModule,
        MenuModule,
        RippleModule,
        RippleModule,
        RippleModule,
        RippleModule,
        RippleModule,
        StyleClassModule,
        InputTextModule
    ],
    styleUrl: './users-list.component.scss'
})
export class UsersListComponent implements OnInit {

    tableColumns: TableStructure<User>[] = [];
    users: User[] = [];
    isLoading$ = new BehaviorSubject(false);

    constructor(
        public usersService: UsersService,
        private confirmationService: ConfirmationService,
    ) {
    }

    ngOnInit(): void {
        this.tableColumns = [
            {field: 'displayName', header: 'Display name'},
            {field: 'firstName', header: 'First name'},
            {field: 'lastName', header: 'Last name'},
            {field: 'email', header: 'Email'},
            {field: 'isActive', header: 'Active'}
        ];

        this.usersService.GetAllUsers().then((value) => {
            this.users = value as unknown as User[];
        });
    }

    activateUser(user: User, event: Event) {
        this.isLoading$.next(true);
        this.confirmationService.confirm({
            message: 'Are you sure you want to activate selected user?',
            header: 'Confirm',
            key: 'ConfirmPopup',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.usersService.activateUser(user.userId)
                    .then(() => {
                        user.isActive = true;
                        this.refreshIfCurrentUserModified();
                        this.isLoading$.next(false);
                    });
            },
            reject: () => {
                this.refreshIfCurrentUserModified();
                this.isLoading$.next(false);
            }
        });
    }

    deactivateUser(user: User, event: Event) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to deactivate selected user?',
            header: 'Confirm',
            key: 'ConfirmPopup',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.usersService.deactivateUser(user.userId)
                    .then(() => {
                        user.isActive = false;
                        this.refreshIfCurrentUserModified();
                    });
            }
        });
    }

    refreshIfCurrentUserModified() {
        window.location.reload();
    }
}
