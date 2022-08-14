import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { SessionStorage, SessionStorageService } from 'angular-web-storage';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  username : FormControl = new FormControl('', [
    Validators.required
  ]);

  mode : string = 'login';
  modes : any = {
    login: 'Log In',
    register: 'Register'
  }
  loginFailed : boolean = false;
  registerFailed : boolean = false;
  errorMsg : string = ''
  loginHandler : Function = () => {
    this.email.markAsTouched();
    if(this.email.invalid) {
      return;
    }
    let user : User = {
      name : this.email.value
    };
    if(this.mode == 'login') {
      this.api.login(user).subscribe((res) => {
        if(!res) {
          this.loginFailed = true;
        }
        this.auth.setCurrentUser(res as User);
        this.router.navigateByUrl('/main');
      })
    }
    else {
      this.api.register(user).subscribe({next: (res) => {
        this.auth.setCurrentUser(res as User);
        this.router.navigateByUrl('/main');
      }, error: (err) => {
        if(err.status === 409) {
          this.registerFailed = true;
          this.errorMsg = err.error;
        }
      }})
    }
  }

  switchMode(mode : string) : void {
    this.mode = mode;
    this.username.reset();
    this.loginFailed = false;
    this.registerFailed = false;
  }

  ngOnInit(): void {
    if(this.auth.isAuthenticated())
    {
      this.router.navigate(['main']);
    }
  }
  
  constructor(private http: HttpClient, session: SessionStorageService) {

  }



}
