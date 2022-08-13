import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AngularWebStorageModule } from 'angular-web-storage';
import { SessionStorageService } from 'angular-web-storage';
import { AppComponent } from './app.component';
import { WalletViewComponent } from './wallet-view/wallet-view.component';

@NgModule({
  declarations: [
    AppComponent,
    WalletViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularWebStorageModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
