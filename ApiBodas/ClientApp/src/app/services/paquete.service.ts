import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class PaqueteService {


  //lugarCeremonia:LugarCeremonia;
  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router: Router) { }


// ***************************************************************************************
//  GET Paquetes 
// ***************************************************************************************
GetPaquetes(idh:number)
{
  const url = URL_SERVICIOS + '/api/Paquete/'+idh;
  
  
  return this.http.get(url).pipe(
  map((resp:any) => {
   
    this.totalRegistros = resp.total;
    // return resp.lugarCena;
    return resp;
  
  })
  
  );
}



}
