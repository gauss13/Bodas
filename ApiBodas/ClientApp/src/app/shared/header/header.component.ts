import { Component, OnInit } from '@angular/core';
import { UsuarioService, HotelService } from 'src/app/services/service.index';
import { Globalx } from 'src/app/config/global';
import { Hotel } from 'src/app/models/hotel.model';

 declare var $: any;
//import * as $ from 'jquery';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  titulo = 'inicial';
  gbl: any;
  hoteles: any;

  constructor(public _usuarioService: UsuarioService, 
    private _gbl: Globalx,
    private _servicioHotel: HotelService) { 

      this.GetHotelStorage();
    }

  ngOnInit() {
  
  this.gbl = this._gbl;
  
  this.getHoteles();

  $(document).ready(function() {
    
      $(".dropdown-trigger").dropdown();
      $('.sidenav').sidenav();
      $('.modal').modal();  // modal de seleccionar el hotel

  });

  }

  fnSelect(item:any)
  {
    console.log(item.nombre);
    this._gbl.hotelSelected = item.nombre;
    this._gbl.hotelSeleccionado = true;
   this.SetHotelStorage(item);

  }

  getHoteles()
  {
    this._servicioHotel.GetHoteles().subscribe(  (resp:any) => {
      this.hoteles = resp;
      });
  }

  // ======================================================
// Set Selected Hotel Storage
// ======================================================
SetHotelStorage(hotel:Hotel)
{  

  localStorage.setItem('selectedHotel', JSON.stringify(hotel));
  
}
// ======================================================
// Get Hotel Storage
// ======================================================
GetHotelStorage()
{

  if( localStorage.getItem('selectedHotel'))  {  
    var hs = JSON.parse( localStorage.getItem('selectedHotel'));   

    this._gbl.hotelSelected = hs.nombre;
    this._gbl.hotelIdSelected = hs.id;
    this._gbl.hotelSeleccionado = true; 


  } else {
    this._gbl.hotelIdSelected = 0;
    this._gbl.hotelSeleccionado = false;    
    this._gbl.hotelSelected= "Seleccionar Hotel";
  }

  
}


}
