import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante
import { LugarCeremonia } from '../models/lugarceremonia.model';

@Injectable({
  providedIn: 'root'
})
export class LugarceremoniaService {

  lugarCeremonia:LugarCeremonia;
  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router: Router) { }


  // ***************************************************************************************
  //  GET - Lugares Cena 
  // ***************************************************************************************
  GetLugaresCena() {
 
    const url = URL_SERVICIOS + '/api/LugarCeremonia';
  
  
  return this.http.get(url).pipe(
  map((resp:any) => {
   
    this.totalRegistros = resp.total;
    //return resp.lugarCena;
    return resp;
  
  })
  
  );
  
    
}


}
