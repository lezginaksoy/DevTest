import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponseModel } from '../models/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class EngineerService {

  constructor(private httpClient: HttpClient) { }

  
  public GetEngineers(): Observable<ApiResponseModel> {
    return this.httpClient.get<ApiResponseModel>('http://localhost:63235/engineer');
  }

}
