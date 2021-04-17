import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JobModel } from '../models/job.model';
import { ApiResponseModel } from '../models/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private httpClient: HttpClient) { }

  public GetJobs(): Observable<ApiResponseModel> {
    return this.httpClient.get<ApiResponseModel>('http://localhost:63235/job');
  }

  public GetJob(jobId: number): Observable<ApiResponseModel> {
    return this.httpClient.get<ApiResponseModel>(`http://localhost:63235/job/${jobId}`);
  }

  public CreateJob(job: JobModel): Promise<object> {
    return this.httpClient.post('http://localhost:63235/job', job).toPromise();
  }
}
