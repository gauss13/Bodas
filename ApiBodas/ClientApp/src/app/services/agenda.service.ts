import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  totalRegistros: number = 0;


  constructor(public http: HttpClient, public router: Router) { }

// ***************************************************************************************
//  GET Fechas por Mes 
// ***************************************************************************************
GetFechasPorMes(an:number, mes:number)
{
  const url = URL_SERVICIOS + '/api/agenda/fechas/'+an+'/'+mes;

  return this.http.get(url).pipe(
    map((resp:any) => {
     
      if(resp.ok == true)
      this.totalRegistros = resp.total;
   
      return resp;
    
    })
    
    );



}

// ***************************************************************************************
//   
// ***************************************************************************************


}
