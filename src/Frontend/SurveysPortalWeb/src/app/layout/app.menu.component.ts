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
                label: 'Managements',
                items: [
                    { label: 'Users', icon: 'pi pi-fw pi-users', routerLink: ['/users-list'] },
                ]
            },
            // {
            //     label: 'Basic surveys',
            //     items: [
            //         { label: 'Questions', icon: 'pi pi-fw pi-question', routerLink: ['/blocks'], badge: 'NEW' },
            //         { label: 'Surveys', icon: 'pi pi-fw pi-check-square', url: ['https://www.primefaces.org/primeblocks-ng'], target: '_blank' },
            //     ]
            // },
            {
                label: 'Standard surveys',
                items: [
                    { label: 'Questions', icon: 'pi pi-fw pi-question', routerLink: ['/standard-question-list'] },
                    { label: 'Surveys', icon: 'pi pi-fw pi-check-square', url: ['https://www.primefaces.org/primeblocks-ng'], target: '_blank' },
                ]
            },
            // {
            //     label: 'Get Started',
            //     items: [
            //         {
            //             label: 'Documentation', icon: 'pi pi-fw pi-book', routerLink: ['/documentation']
            //         }
            //     ]
            // }
        ];
    }
}
