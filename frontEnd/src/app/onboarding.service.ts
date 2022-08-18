import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
import { AuthService } from './service/auth.service';
import { WalletService, wallet } from './wallet.service';
import { User, UserService } from './service/user.service';



@Injectable({
  providedIn: 'root'
})
export class OnboardingService {

  constructor(private http: HttpClient, private walletService: WalletService, private authService: AuthService, private userService: UserService) { }

  user: User = this.authService.getCurrentUser()

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  WalletCreateOnboarding(): boolean {
    
    let wallets: {
      walletId: number,
      userIdFk: number,
      currencyIdFk: number,
      amountCurrency: number }[] = [
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 1, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 2, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 3, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 4, "amountCurrency": 5000 }, //STARTING NUMBER
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 5, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 6, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 7, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 8, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 9, "amountCurrency": 0 },
        {walletId: 0, "userIdFk": this.user.userId, "currencyIdFk": 10, "amountCurrency": 0 },
    ];
    
    for (let i: number = 0; i < 10; i++) {
      this.http.post<wallet>(this.apiUrl + "create/wallet/", wallets[i])
    }
    return true;
  }
}
