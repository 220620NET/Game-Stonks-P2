import { Component, OnInit } from '@angular/core';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private local: LocalStorageService, private session: SessionStorageService) { }
  fname: string = '';
  lname: string = '';
  user: any = null;
  get() {
    this.user = this.session.get(this.user)
  }
  
  ngOnInit(): void {
  }

}
