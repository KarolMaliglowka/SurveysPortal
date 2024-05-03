import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }
                ]
            },
            {
                label: 'Basic surveys',
                items: [
                    { label: 'Questions', icon: 'pi pi-fw pi-question', routerLink: ['/'] },
                    { label: 'Surveys', icon: 'pi pi-fw pi-check-square', routerLink: ['/']},
                ]
            },
            {
                label: 'Standard surveys',
                items: [
                    { label: 'Questions', icon: 'pi pi-fw pi-question', routerLink: ['/standard-question-list'] },
                    { label: 'Surveys', icon: 'pi pi-fw pi-check-square',  routerLink: ['/'] },
                ]
            },
            {
                label: 'Managements',
                items: [
                    { label: 'Users', icon: 'pi pi-fw pi-users', routerLink: ['/users-list'] },
                ]
            },
            {
                label: 'Settings',
                items: [
                    { label: 'Settings', icon: 'pi pi-fw pi-gear', routerLink: ['/users-list'] },
                ]
            },
        ];
    }
}
