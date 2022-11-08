import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Env } from 'src/app/settings/env';
import { SessionModel } from '../models/session-model';
import { ResponseModel } from '../models/response-model';

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  delete(id: string) {
    return this.httpClient.delete<ResponseModel<SessionModel>>(
      `${Env.API_URL}/Session/${id}`
    );
  }
  update(SessionId: string, value: any) {
    return this.httpClient.put<ResponseModel<SessionModel>>(
      `${Env.API_URL}/Session/`,
      { ...value, id: SessionId }
    );
  }
  create(value: any) {
    return this.httpClient.post<ResponseModel<SessionModel>>(
      `${Env.API_URL}/Session`,
      value
    );
  }
  getById(SessionId: string) {
    return this.httpClient.get<ResponseModel<SessionModel>>(
      `${Env.API_URL}/Session/${SessionId}`
    );
  }
  getAll() {
    const url = `${Env.API_URL}/Session`;

    return this.httpClient.get<ResponseModel<SessionModel[]>>(url);
  }

  constructor(private readonly httpClient: HttpClient) {}
}
