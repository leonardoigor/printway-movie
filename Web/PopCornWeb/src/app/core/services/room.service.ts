import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Env } from 'src/app/settings/env';

@Injectable({
  providedIn: 'root',
})
export class RoomService {
  constructor(private readonly httpClient: HttpClient) {}

  getAll() {
    const url = `${Env.API_URL}/Room`;

    return this.httpClient.get(url, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      },
      responseType: 'json',
    });
  }
}
