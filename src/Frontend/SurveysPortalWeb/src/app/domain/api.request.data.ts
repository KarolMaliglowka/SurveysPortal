import {HttpHeaders, HttpParams} from "@angular/common/http";

export interface ApiRequestData {
  Url: string;
  RequestBody: any;
  Params: HttpParams;
  Headers: HttpHeaders;
}
