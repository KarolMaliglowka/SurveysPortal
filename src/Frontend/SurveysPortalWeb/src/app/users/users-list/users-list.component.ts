import {Component, OnInit} from '@angular/core';
import {UsersService} from "../users.service";
import {UserListDto} from "../models/UserDto";
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

    usersList: UserListDto[] = [];
    tableColumns: TableColumn<UserListDto>[] = [];
    users: UserListDto[] = [];
    isLoading$ = new BehaviorSubject(false);
    sizes!: any[];

    selectedSize: any = '';
    constructor(
        public usersService: UsersService,
        private confirmationService: ConfirmationService,
    ) { }
    ngOnInit(): void {
        this.tableColumns = [
            {field: 'displayName', header: 'Display name'},
            {field: 'firstName', header: 'First name'},
            {field: 'lastName', header: 'Last name'},
            {field: 'email', header: 'Email'},
            {field: 'isActive', header: 'Active'}
        ];

        this.usersService.GetAllUsers().then((value) => {
            this.users = value as unknown as UserListDto[];
            this.sizes = [
                { name: 'Small', class: 'p-datatable-sm' },
                { name: 'Normal', class: '' },
                { name: 'Large',  class: 'p-datatable-lg' }
            ];


        });
    }

    activateUser(user: UserListDto, event: Event) {
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

    deactivateUser(user: UserListDto, event: Event) {
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

export type TableColumn<T> = {
    field: keyof T,
    header: string,
    order?: number
};
