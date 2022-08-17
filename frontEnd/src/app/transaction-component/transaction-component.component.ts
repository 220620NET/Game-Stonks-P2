import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { transaction, TransactionService } from '../transaction.service';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';

@Component({
  selector: 'app-transaction-component',
  templateUrl: './transaction-component.component.html',
  styleUrls: ['./transaction-component.component.css']
})
export class TransactionComponentComponent implements OnInit {
  constructor(private api:TransactionService, private local: LocalStorageService, private session: SessionStorageService) { }
  ngOnInit(): void {
    
  }

  newTrans:transaction = 
  {
    transactionId: 0,
    walletIdFk: 0,
    currencyIdFk: 0,
    transactionType: "",
    transactionValue: 0,
    transactionTime: new Date
  }

  currentUser:any = "";
  walletId:number = 1;
  type:string = "";
  amount:number = 0;
  
  buyCrypto(buy:string)
  {
    if(this.currentUser.UserId)
    {
      this.api.CreateTransaction(this.newTrans);
    }
  }

  sellCrypto(sell:string)
  {
    if(this.currentUser.UserId)
    {
      this.api.CreateTransaction(this.newTrans);
    }
  }

  currencyData:any

  apicall() {
    
    // let fiatelem = document.getElementById('fiat');
    // let fiatInput = fiatelem.value;
    // let cryptoelem = document.getElementById('crypto');
    // let cryptotInput = cryptoelem.value;
    if(document)
    {
      fetch('https://api.coinbase.com/v2/prices/BTC-USD/spot')
    .then((response) => response.json()).then((resBody) => {
      console.log(resBody)
        this.currencyData = resBody;
        // <HTMLSelectElement>document.querySelector('#result-fiat').innerText = resBody.data.currency;
        //<HTMLSelectElement>document.querySelector('#result-crypt').innerText = resBody.data.base;
        //<HTMLSelectElement>document.querySelector('#result-amount').innerText = resBody.data.amount;
      });
    }
  
  

  }
}