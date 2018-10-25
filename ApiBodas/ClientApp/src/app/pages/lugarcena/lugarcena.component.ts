import { Component, OnInit } from '@angular/core';
import { LugarCena } from '../../models/lugarcena.model';
import { LugarcenaService } from 'src/app/services/service.index';

@Component({
  selector: 'app-lugarcena',
  templateUrl: './lugarcena.component.html',
  styles: []
})
export class LugarcenaComponent implements OnInit {

//Definicion de variables
lugares:LugarCena[] = [];// array vacio

totalRegistros : number =0;


  constructor(public _servicio: LugarcenaService) { }

  ngOnInit() {
    this.cargarLugares();
  }

// ***************************************************************************************
//  Cargar los lugares de cena 
// ***************************************************************************************

cargarLugares() {

  console.log('carga inicial');

  this._servicio.GetLugaresCena().subscribe( (resp:any) => {

    console.log(resp);

this.totalRegistros = this._servicio.totalLugaresCena;
this.lugares = resp;

  });
}



}
