import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante
//import { LugarCeremonia } from '../models/lugarceremonia.model';


@Injectable({
  providedIn: 'root'
})
export class DivisaService {

  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router: Router) { }

 // ***************************************************************************************
  //  GET - Divisas
  // ***************************************************************************************
  GetDivisas() {
 
    const url = URL_SERVICIOS + '/api/Divisa';
  
  
  return this.http.get(url).pipe(
  map((resp:any) => {
   
    this.totalRegistros = resp.total;
    //return resp.lugarCena;
    return resp;
  
  })
  
  );
  
    
}


}
