import { Component, OnInit } from '@angular/core';
import { Globalx } from '../../config/global';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: []
})
export class DashboardComponent implements OnInit {

  constructor(private glb:Globalx) { }

  ngOnInit() {

    this.glb.tituloModulo ="Dashboard";
  }

}
