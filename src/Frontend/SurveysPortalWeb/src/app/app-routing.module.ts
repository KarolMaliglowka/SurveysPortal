import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import {AppLayoutComponent} from "./layout/app.layout.component";
import {UsersListComponent} from "./users/users-list/users-list.component";
import {UserDetailsComponent} from "./users/user-details/user-details.component";
import {
    StandardQuestionsListComponent
} from "./surveys/standard/standard-questions-list/standard-questions-list.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', component: AppLayoutComponent,
                children: [
                    {path: 'users-list', component: UsersListComponent},
                    {path: 'user-details', component: UserDetailsComponent},
                    {path: 'standard-question-list', component: StandardQuestionsListComponent},
                ]
            },
            //{path: 'notfound', component: NotfoundComponent},
            {path: '**', redirectTo: '/notfound'},
        ], {scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload'})
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
