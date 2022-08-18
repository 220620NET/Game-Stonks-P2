import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface User {
  userId: number;
  email: string;
  password: string;
}
export interface User {
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  constructor(private http: HttpClient) { }

  newUser!: User;

}
