import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class HoraService {

  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router:Router) { }



// ***************************************************************************************
//  GET HORAS 
// ***************************************************************************************
GetHoras()
{
  const url = URL_SERVICIOS + '/api/horas';
  

  return this.http.get(url).pipe(
map( (resp:any) => {

  this.totalRegistros = resp.total;


  return resp.horas;

})


  );
}



}
