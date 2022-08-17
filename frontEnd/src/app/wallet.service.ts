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

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  constructor(private http: HttpClient) { }

  GetWallets(): Observable<wallet[]> {
    return this.http.get<wallet[]>(this.apiUrl + "wallet");
  }

  GetWalletsById(id: number): Observable<wallet[]> {
    return this.http.get<wallet[]>(this.apiUrl + "wallet/" + id) as Observable<wallet[]>;

  }

  UpdateWalletBalance(amount: number): boolean {
    
    return false;
  }

}
