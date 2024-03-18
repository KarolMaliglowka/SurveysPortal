import {Injectable} from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {ApiRequestData} from "../domain/api.request.data";
import {environment} from "../../environments/environment";
import {catchError, Observable, retry, throwError} from "rxjs";

@Injectable()
export class ApiService {
  protected headers = new HttpHeaders({'Content-Type': 'application/json'});
  protected baseUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = environment.baseUrl;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  public get(data: ApiRequestData): Observable<Response> {
    return this.httpClient.get<Response>(`${this.baseUrl}/${data.Url}`, {
      headers: this.headers
    }).pipe(catchError(this.handleError));
  }

  public post(data: ApiRequestData): Observable<Response> {
    return this.httpClient.post<Response>(`${this.baseUrl}/${data.Url}`, data.RequestBody, {
      headers: this.headers
    }).pipe(catchError(this.handleError));
  }

  public delete(data: ApiRequestData): Observable<Response> {
    return this.httpClient.delete<Response>(`${this.baseUrl}/${data.Url}`, {
      headers: this.headers
    }).pipe(catchError(this.handleError));
  }

  public put(data: ApiRequestData): Observable<Response> {
    return this.httpClient.put<Response>(`${this.baseUrl}/${data.Url}`, data.RequestBody, {
      headers: this.headers
    }).pipe(catchError(this.handleError));
  }

  public patch(data: ApiRequestData): Observable<Response> {
    return this.httpClient.patch<Response>(`${this.baseUrl}/${data.Url}`, data.RequestBody, {
      headers: this.headers,
      params: data.Params
    }).pipe(retry(3),
      catchError(this.handleError));
  }
}
