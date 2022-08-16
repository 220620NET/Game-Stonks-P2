import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent{

  constructor(public router: Router) { }

  content : string = 'CryptoCurrency';
  switchContent(content: string) : void {
    this.content = content;
  }
}
