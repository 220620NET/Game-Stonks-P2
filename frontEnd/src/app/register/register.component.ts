import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { SessionStorageService } from 'angular-web-storage';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  password: FormControl = new FormControl('');
  email: FormControl = new FormControl('');
  modes: any = {
    'login' : 'Log In',
    'register' : 'Register'
  }
  mode : string = 'register';

  registerHandler: Function = () => {
    //register people!!!
    console.log(this.password.value, this.email.value)
    this.http.post('https://gamestonks.azurewebsites.net/register',{
      'email': this.email.value,
      'password': this.password.value
    }).subscribe((res: any) => {
      console.log('successful register!', res)
      this.session.set('currentUser', res);
  });
  }
  loginHandler: Function = () => {
    //login people!!!
    console.log(this.password.value, this.email.value)
    this.http.post('https://gamestonks.azurewebsites.net/login',{
      'email': this.email.value,
      'password': this.password.value
    }).subscribe((res: any) => {
      console.log('successful login!', res)
      this.session.set('currentUser', res);
  });
  }
  switchMode(mode: string) : void {
    this.mode = mode;
  }
  constructor(private http: HttpClient, private session: SessionStorageService) { }


}
