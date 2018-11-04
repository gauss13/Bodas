import {Injectable} from '@angular/core';


@Injectable()
export class Globalx {

 public tituloModulo = "Uno inicial"; 
 public hotelSelected = "Seleccionar Hotel";
 public hotelIdSelected:number=0;
 public hotelSeleccionado: boolean = false;

constructor()
  {
    var d = new Date();
      console.log('Se crea el objeto globalx' + d.getDate());
  }
}
