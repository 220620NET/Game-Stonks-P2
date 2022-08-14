import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AngularWebStorageModule } from 'angular-web-storage';
//import { LoginComponent } from './login/login.component';
import { SessionStorageService } from 'angular-web-storage';
import { DashBoardComponent } from './dash-board/dash-board.component';
@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    //LoginComponent,
    DashBoardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularWebStorageModule,
    //SessionStorageService
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
