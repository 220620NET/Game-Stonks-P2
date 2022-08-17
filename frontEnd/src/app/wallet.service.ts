import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface wallet {
  walletId: number;
  userIdFk: number;
  currencyIdFk: number;
  amountCurrency: number;
}

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  apiUrl = 'https://gamestonks.azurewebsites.net/wallet'

  constructor(private http: HttpClient) { }

  GetWallets(): Observable<wallet[]> {
    return this.http.get<wallet[]>(this.apiUrl);
  }

}
