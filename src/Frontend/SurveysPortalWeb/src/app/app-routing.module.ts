import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import {AppLayoutComponent} from "./layout/app.layout.component";
import {UsersListComponent} from "./users/users-list/users-list.component";
import {UserDetailsComponent} from "./users/user-details/user-details.component";
import {
    StandardQuestionsListComponent
} from "./surveys/standard/standard-questions-list/standard-questions-list.component";
import {
    StandardQuestionDetailsComponent
} from "./surveys/standard/standard-question-details/standard-question-details.component";
import {StandardSurveysListComponent} from "./surveys/standard/standard-surveys-list/standard-surveys-list.component";
import {
    StandardSurveyDetailsComponent
} from "./surveys/standard/standard-survey-details/standard-survey-details.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', component: AppLayoutComponent,
                children: [
                    {path: 'users-list', component: UsersListComponent},
                    {path: 'user-details', component: UserDetailsComponent},
                    {path: 'standard-questions-list', component: StandardQuestionsListComponent},
                    {path: 'standard-question-add', component: StandardQuestionDetailsComponent},
                    {path: 'standard-surveys-list', component: StandardSurveysListComponent},
                    {path: 'standard-surveys-add', component: StandardSurveyDetailsComponent}
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
