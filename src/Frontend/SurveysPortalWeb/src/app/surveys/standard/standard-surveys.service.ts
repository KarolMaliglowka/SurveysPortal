import {Injectable} from '@angular/core';
import {ApiService} from '../../services/api.service';
import {firstValueFrom} from 'rxjs';
import {ApiRequestData} from "../../domain/api.request.data";

@Injectable({
    providedIn: 'root'
})
export class StandardSurveysService {
    private url = 'standardSurvey';

    constructor(private httpService: ApiService) {
    }

    GetAllStandardSurveys() {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/all`
        };
        return firstValueFrom(this.httpService.get(apiRequest));
    }

    GetStandardSurveyById(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/getSurveyById/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }

    DeleteStandardSurvey(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/deleteSurvey/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }

    UpdateStandardSurvey(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/updateSurvey/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }

    CreateStandardSurvey(survey: any) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/updateSurvey}`,
            RequestBody: survey
        };
        return firstValueFrom(this.httpService.post(apiRequest));
    }
}
