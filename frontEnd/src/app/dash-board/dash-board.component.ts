import { Component } from '@angular/core';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent{

  constructor() { }

  contents: any = {
    'CryptoCurrency' : 'CryptoCurrency',
    'Leaderboard' : 'Leaderboard',
    'Wallet' : 'Wallet'
  }
  content : string = 'CryptoCurrency';
  switchContent(content: string) : void {
    this.content = content;
  }
}
