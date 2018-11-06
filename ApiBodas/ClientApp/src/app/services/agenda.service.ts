import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante
import { Agenda } from '../models/agenda.model';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  totalRegistros: number = 0;


  constructor(public http: HttpClient, public router: Router) { }

// ***************************************************************************************
//  GET Fechas por Mes 
// ***************************************************************************************
GetFechasPorMes(an:number, mes:number, idh:number)
{
  const url = URL_SERVICIOS + '/api/agenda/fechas/'+ idh +'/' + an +'/'+ mes;

  return this.http.get(url).pipe(
    map((resp:any) => {
     
      if(resp.ok == true)
      this.totalRegistros = resp.total;
   
      return resp;
    
    })
    
    );
}

// ***************************************************************************************
//   POST - CREAR
// ***************************************************************************************
CrearAgenda(item: Agenda)
{
  const url= URL_SERVICIOS + "/api/Agenda";

  const headersj = new HttpHeaders({'Content-Type':'application/json'});

  return this.http.post(url,item,{headers: headersj}).pipe(

    map( (resp:any) => {

      return resp;
    })
  );

}

// ***************************************************************************************
//  POST ACTUALIZAR 
// ***************************************************************************************
ActualizarAgenda(item: Agenda, id:number)
{
  const url= URL_SERVICIOS + "/api/Agenda/" +id;

  const headersj = new HttpHeaders({'Content-Type':'application/json'});

  return this.http.put(url,item,{headers: headersj}).pipe(

    map( (resp:any) => {
      return resp;
    })
  );

}

// ======================================================
// GET AGENDA by ID
// ======================================================
GetAgendaById(id:number)
{
  const url= URL_SERVICIOS + "/api/Agenda/"+id;
  const headersj = new HttpHeaders({'Content-Type':'application/json'});

  return this.http.get(url).pipe(
    map((resp:any) => {

      return resp;

    })
  );
}


StringOrEmpty(value:string)
{
  return !(typeof value === "string" && value.length > 0);
}


// ***************************************************************************************
//  PUT - CAMBIAR ESTATUS 
// ***************************************************************************************
PutCambiarEstatus(id:number, ide:number)
{
  const url= URL_SERVICIOS + '/api/Agenda/estatus/'+id + '/'+ide;
  const headersj = new HttpHeaders({'Content-Type':'application/json'});


  return this.http.put(url,null).pipe(
    map((resp:any) => {
      return resp;
    })
  );

}



}
