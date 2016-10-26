import { Component, OnInit } from '@angular/core';

import { SaladsService } from '../shared/services/salads.service';
import { Salad } from '../shared/models/salad';

@Component({
  moduleId: module.id,
  selector: 'salads',
  templateUrl: 'salads.component.html',
  styleUrls: [ './salads.component.css' ],
})
export class SaladsComponent implements OnInit {
  constructor(private saladsService: SaladsService) { }

  public salads: Salad[];
  public showAddNewSalad: boolean = true;//false;

  public toggleShowNewSalad(show?: boolean) : void {
    if (show === undefined) {
      this.showAddNewSalad = !this.showAddNewSalad;
    } else {
      this.showAddNewSalad = show;
    }
  }

  ngOnInit() {
    this.saladsService
      .getSalads()
      .subscribe(
        salads => this.salads = salads,
        err => {
          console.log(err)
        }
      );
  }
}
