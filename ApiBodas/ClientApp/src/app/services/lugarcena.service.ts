import { Injectable } from '@angular/core';
import { LugarCena } from '../models/lugarcena.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class LugarcenaService {

  lugarCena:LugarCena;
  totalLugaresCena: number = 0;

  constructor( public http: HttpClient, public router: Router) { }


  // ***************************************************************************************
  //  GET - Lugares Cena 
  // ***************************************************************************************
GetLugaresCena() {
 
  const url = URL_SERVICIOS + '/api/LugarCena';


return this.http.get(url).pipe(
map((resp:any) => {

  this.totalLugaresCena = resp.total;
  return resp.lugarCena;

})

);

  
}











} // <- clase
