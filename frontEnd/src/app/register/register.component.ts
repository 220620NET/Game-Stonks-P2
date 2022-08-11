import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username: FormControl = new FormControl('');
  password: FormControl = new FormControl('');
  email: FormControl = new FormControl('');

  registerHandler = () => {
    //register people!!!
    console.log(this.username.value, this.password.value, this.email.value)
  }
  constructor() { }

  ngOnInit(): void {
  }

}
