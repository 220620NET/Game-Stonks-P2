import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { SessionStorageService } from 'angular-web-storage';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  password: FormControl = new FormControl('');
  email: FormControl = new FormControl('');

  registerHandler = () => {
    //register people!!!
    console.log(this.password.value, this.email.value)
    this.http.post('https://gamestonks.azurewebsites.net/register',{
      'password': this.password.value,
      'email': this.email.value
    }).subscribe((res: any) => {
      console.log('successful register!', res)
      this.session.set('currentUser', res);
  });
  }
  constructor(private http: HttpClient, private session: SessionStorageService) { }

  ngOnInit(): void {
  }

}
