import { Component, OnInit } from '@angular/core';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';
import { Profile, ProfileService } from '../profile.service';
import { DashBoardComponent } from '../dash-board/dash-board.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private local: LocalStorageService, private session: SessionStorageService,private api:ProfileService) { }
  
  currentProfile : Profile = {
    ProfileId: NaN,
    UserIdFk: NaN,
    FirstName: '',
    LastName: ''
  };

  // fname: string = this.currentProfile.FirstName;
  // lname: string = this.currentProfile.LastName;
  // currentUser: any = null;
  // email: string = this.currentUser.Email;

  imageId: number = 1;
  images: string[] =["../../assets/person-outline.svg","../../assets/sid.png",];
  vis: boolean = false;
  changeImage() {
    let id: number = Number((<HTMLSelectElement>document.getElementById('imgId')).value);
    this.session.set('imgId', id);
    this.imageId = id;
    this.vis = false;
  }
  show() {
    this.vis = true;
  }
  // getUser() {
  //   this.currentUser = this.session.get(this.currentUser)
  // }
  // GetProfile() : void {
  //   if (this.currentUser.UserId){
  //     this.api.GetProfileByUserId(this.currentUser.UserId).subscribe((res) => {
  //       this.currentProfile = res;
  //     })
  //   }
  // }
  ngOnInit(): void {
    // this.getUser();
    // this.GetProfile();
  }

}
