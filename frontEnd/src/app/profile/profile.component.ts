import { Component, OnInit } from '@angular/core';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';
import { Profile, ProfileService } from '../profile.service';
import { DashBoardComponent } from '../dash-board/dash-board.component';
import { FormControl } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ApplicationConfig } from '@angular/platform-browser';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private local: LocalStorageService, private session: SessionStorageService,private api:ProfileService,private myForm : FormBuilder) { }
  
  profileForm = this.myForm.group({
    FirstName: '',
    LastName: '',
  });

  
  fname: string = "John";
  lname: string = "Doe";
  currentUser: any = null;
  email: string = this.currentUser.Email;

  imageId: number = 1;
  images: string[] =["../../assets/person-outline.svg","../../assets/sid.png",];
  vis: boolean = false;
  submitProfile(): void {
    this.api.UpdateProfile({
      ProfileId: 0,
      UserIdFk: this.currentUser.UserId,
      FirstName: this.profileForm.value.FirstName!,
      LastName: this.profileForm.value.LastName!
    });
  }
  changeImage() {
    let id: number = Number((<HTMLSelectElement>document.getElementById('imgId')).value);
    this.session.set('imgId', id);
    this.imageId = id;
    this.vis = false;
  }
  show() {
    this.vis = true;
  }
  getUser() {
    this.currentUser = this.session.get(this.currentUser)
  }
  GetProfile() : void {
    if (this.currentUser.UserId){
      this.api.GetProfileByUserId(this.currentUser.UserId).subscribe((res) => {
        this.fname = res.FirstName;
        this.lname = res.LastName
      })
    }
  }
  ngOnInit(): void {
    this.getUser();
    this.GetProfile();
  }

}
