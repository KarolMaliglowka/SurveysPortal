import {Component, OnInit} from '@angular/core';
import {UsersService} from "../users.service";
import {UserListDto} from "../models/UserDto";
import {BehaviorSubject} from "rxjs";
import {ConfirmationService} from "primeng/api";

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  usersList: UserListDto[] = [];
  tableColumns: TableColumn<UserListDto>[] = [];
  users: UserListDto[] = [];
  isLoading$ = new BehaviorSubject(false);

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
