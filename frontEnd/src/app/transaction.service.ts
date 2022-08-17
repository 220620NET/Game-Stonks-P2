import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface transaction {
  transactionId: number;
  walletIdFk: number;
  currencyIdFk: number;
  transactionType: string;
  transactionValue: number;
  transactionTime: Date;
}

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  apiUrl = 'https://gamestonks.azurewebsites.net/transaction'

  constructor(private http: HttpClient) { }

  GetTransaction(): Observable<transaction[]> {
    return this.http.get<transaction[]>(this.apiUrl);
  }
}
