import {Injectable} from '@angular/core';
import {ApiService} from '../services/api.service';
import {firstValueFrom} from 'rxjs';
import {ApiRequestData} from "../domain/api.request.data";

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private url = 'users';

  constructor(private httpService: ApiService) {
  }

  GetAllUsers() {
    let apiRequest = <ApiRequestData>{
      Url: `${this.url}/all`
    };
    return firstValueFrom(this.httpService.get(apiRequest));
  }

  activateUser(id: string) {
    let apiRequest = <ApiRequestData>{
      Url: `${this.url}/activate/${id}`,
      RequestBody: id
    };
    return firstValueFrom(this.httpService.put(apiRequest));
  }

  deactivateUser(id: string) {
    let apiRequest = <ApiRequestData>{
      Url: `${this.url}/deactivate/${id}`,
      RequestBody: id
    };
    return firstValueFrom(this.httpService.put(apiRequest));
  }
}
