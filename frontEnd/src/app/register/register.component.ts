import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username = new FormControl('');
  password = new FormControl('');
  email = new FormControl('');

  registerHandler = function(){
    //register people!!!
  }
  constructor() { }

  ngOnInit(): void {
  }

}
