import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { UserApiServiceService } from '../service/user-api-service.service';
import { User } from '../service/user.service';
import { transaction, TransactionService } from '../transaction.service';


@Component({
  selector: 'app-transaction-table',
  templateUrl: './transaction-table.component.html',
  styleUrls: ['./transaction-table.component.css']
})
export class TransactionTableComponent implements OnInit {

  transactions: transaction[] = [];

  fdsf: number = 1;
  columnsToDisplay: string[] = ['transactionId', 'walletIdFk', 'currencyIdFk', 'transactionType', 'transactionValue', 'transactionTime'];

  constructor(private transactionService: TransactionService, private auth: AuthService, private api: UserApiServiceService) { 
    this.transactionService.GetTransactionbyWalletId(this.fdsf) //HERE!
      .subscribe(transaction => this.transactions = transaction);
  }

  ngOnInit(): void {
  }

}
