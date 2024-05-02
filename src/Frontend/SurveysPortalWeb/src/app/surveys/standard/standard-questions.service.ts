import {Injectable} from '@angular/core';
import {ApiService} from '../../services/api.service';
import {firstValueFrom} from 'rxjs';
import {ApiRequestData} from "../../domain/api.request.data";

@Injectable({
    providedIn: 'root'
})
export class StandardQuestionsService {
    private url = 'standardQuestion';

    constructor(private httpService: ApiService) {
    }

    GetAllStandardQuestions() {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/all`
        };
        console.log('trestdsgsdfsdfds')
        return firstValueFrom(this.httpService.get(apiRequest));
    }

    GetStandardQuestionById(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/getQuestionById/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }

    DeleteStandardQuestion(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/deleteQuestion/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }

    UpdateStandardQuestion(id: string) {
        let apiRequest = <ApiRequestData>{
            Url: `${this.url}/updateQuestion/${id}`,
            RequestBody: id
        };
        return firstValueFrom(this.httpService.put(apiRequest));
    }
}
