
import { HttpClient } from '@angular/common/http';
import { Injectable , OnInit} from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { User, UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})

export class AuthService {

  newUserId: number = 10000;

  constructor(private local: LocalStorageService, private userService: UserService) {
  }

  public isAuthenticated() : boolean {
    if(this.local.get('currentUser')) return true;
    return false;
  }

  public getCurrentUser() : User {
    return this.local.get('currentUser'); 
  }

  public setCurrentUser(user: User): void {
    if(!user) return;
    this.local.set('currentUser', user);
  }

  public clearCurrentUser() : void {
    this.local.remove('currentUser');
  }
}