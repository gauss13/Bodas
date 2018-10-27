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
  totalRegistros: number = 0;

  constructor( public http: HttpClient, public router: Router) { }


  // ***************************************************************************************
  //  GET - Lugares Cena 
  // ***************************************************************************************
GetLugaresCena() {
 
  const url = URL_SERVICIOS + '/api/LugarCena';


return this.http.get(url).pipe(
map((resp:any) => {

  this.totalRegistros = resp.total;
  //return resp.lugarCena;
  return resp;

})

);

  
}

// ***************************************************************************************
//  POST - Guardar Lugar Cena 
// ***************************************************************************************

Crear(lugar:LugarCena)
{
  
  const url = URL_SERVICIOS + '/api/LugarCena';

 return this.http.post(url, lugar ).pipe(

    map((resp:any ) => {

return resp.lugarCena;

    })

  );
}








} // <- clase
