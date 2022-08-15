import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { MatWalletViewDataSource, MatWalletViewItem } from './mat-wallet-view-datasource';

@Component({
  selector: 'app-mat-wallet-view',
  templateUrl: './mat-wallet-view.component.html',
  styleUrls: ['./mat-wallet-view.component.css']
})
export class MatWalletViewComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<MatWalletViewItem>;
  dataSource: MatWalletViewDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  constructor() {
    this.dataSource = new MatWalletViewDataSource();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
