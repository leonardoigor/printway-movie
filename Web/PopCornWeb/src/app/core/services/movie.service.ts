import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Env } from 'src/app/settings/env';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  constructor(private readonly httpClient: HttpClient) {}

  create(value: any) {
    const url = `${Env.API_URL}/Movie`;
    return this.httpClient.post(url, value, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }
  update(MovieId: any, value: any) {
    const url = `${Env.API_URL}/Movie/`;
    return this.httpClient.put(url, value, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }
  getById(MovieId: any) {
    const url = `${Env.API_URL}/Movie/${MovieId}`;
    return this.httpClient.get(url, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }

  getAll() {
    const url = `${Env.API_URL}/Movie`;
    return this.httpClient.get(url, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }
  remove(id: string) {
    const url = `${Env.API_URL}/Movie?Id=${id}`;
    return this.httpClient.delete(url, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }
}
