import { Component, OnInit } from '@angular/core';
import { DivisaService, GenericoService  } from 'src/app/services/service.index';
import { HotelService } from 'src/app/services/hotel.service';
import { Hotel } from 'src/app/models/hotel.model';
import { Globalx } from 'src/app/config/global';
import { Router } from '@angular/router';
import { uriServicio, uriDepartamento, uriCategoria, uriDepartamentoServicio } from 'src/app/config/config';
import { uriPaquete } from '../../../config/config';

declare var $: any;
declare var M: any;

@Component({
  selector: 'app-paquete',
  templateUrl: './paquete.component.html',
  styles: []
})
export class PaqueteComponent implements OnInit {

  registros:any[] = [];// array vacio de catagorias
  totalRegistros : number =0;
  divisas:any[] = [];
  categorias:any[] = [];
  cargando: boolean = true;  

  constructor( private _gbl: Globalx,
    private router:Router,
    private _servicioGenerico: GenericoService,) { }

  ngOnInit() {

    // HOTEL SELECCIONADO
    if(!this._gbl.hotelSeleccionado)
    {
      this.router.navigate(['/dashboard']);
    }

    this._gbl.tituloModulo ="Paquetes";

       // READY JQUERY
       $(document).ready(function(){
        
     
      });

      this.GetPaquetes();

  }
  // ***************************************************************************************
  //  GET Paquetes 
  // ***************************************************************************************
GetPaquetes()
{
  const url = uriPaquete + this._gbl.hotelIdSelected;

this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

    if(resp.ok === true)
    {
       this.registros = resp.paquete;
       this.totalRegistros = resp.total;  
    }

});

this.cargando=false;
}


}
