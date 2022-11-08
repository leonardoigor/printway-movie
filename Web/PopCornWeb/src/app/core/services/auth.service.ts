import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Env } from 'src/app/settings/env';
import { LoginResponseModel } from '../models/login-response-model';
import { ResponseModel } from '../models/response-model';
import { TokenModel } from '../models/token-model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private readonly httpclient: HttpClient) {}

  login(email: string, password: string) {
    const url = `${Env.API_URL}/login?email=${email}&password=${password}`;
    return this.httpclient.get<ResponseModel<LoginResponseModel>>(url);
  }
  storeUserToken(token: TokenModel) {
    localStorage.setItem('token', JSON.stringify(token));
  }
  logout() {
    localStorage.removeItem('token');
  }
  get token(): TokenModel | null {
    let dataJson = localStorage.getItem('token');
    if (dataJson) {
      return JSON.parse(dataJson);
    }
    return null;
  }
}
