import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante
//import { LugarCeremonia } from '../models/lugarceremonia.model';

@Injectable({
  providedIn: 'root'
})
export class BackupService {

 // lugarCeremonia:LugarCeremonia;
  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router: Router) { }

 // ***************************************************************************************
  //  GET - Lugares Backup
  // ***************************************************************************************
  GetLugaresBackup() {
 
    const url = URL_SERVICIOS + '/api/BackUp';
  
  
  return this.http.get(url).pipe(
  map((resp:any) => {
   
    this.totalRegistros = resp.total;
    //return resp.lugarCena;
    return resp;
  
  })
  
  );
  
    
}


}
