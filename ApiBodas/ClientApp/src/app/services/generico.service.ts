import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class GenericoService {

  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router: Router) { }

// ***************************************************************************************
//  GET 
// ***************************************************************************************
GetRegistros(strApi:string)
{
  const url = URL_SERVICIOS + strApi;

  return this.http.get(url).pipe(
    map((resp:any) => {
    
      this.totalRegistros = resp.total;
      //return resp.lugarCena;
      return resp;
    
    })
    
    );
}

GetFile(strApi:string)
{
  const url = URL_SERVICIOS + strApi;

  let headerss = new HttpHeaders({ 'Authorization': 'Bearer ' + 'token' });
   headerss.append("Accept", "vnd.ms-excel, application/json, text/plain, */*");  
      // headerss.append("Access-Control-Allow-Origin", '*');  
      // headerss.append("App-Version", '1.0');  


return this.http.get(url,{ headers: headerss,  responseType:'blob'}).pipe(
  map((resp:any) => {

      return resp;
  })
);

}


GetRegistrosHeaders(strApi:string, headerss:HttpHeaders)
{
  const url = URL_SERVICIOS + strApi;

  return this.http.get(url,{headers: headerss}).pipe(
    map((resp:any) => {
    
      this.totalRegistros = resp.total;
      //return resp.lugarCena;
      return resp;
    
    })
    
    );
}





// ***************************************************************************************
//  POST 
// ***************************************************************************************
CrearRegisto(itemNuevo:any,strApi:string )
{ 
  const url = URL_SERVICIOS + strApi;

  const headerss = new HttpHeaders({'Content-Type':'application/json'});

// const body = JSON.parse(lugar);
 return this.http.post(url, itemNuevo, {headers: headerss} ).pipe(

    map((resp:any ) => {
      return resp;
    })

  );
}


// ***************************************************************************************
//  PUT 
// ***************************************************************************************
Actualizar(itemEditado:any,strApi:string)
{
  const url = URL_SERVICIOS +  strApi;
  const headerss = new HttpHeaders({'Content-Type':'application/json'});

  return this.http.put(url, itemEditado, {headers: headerss}).pipe(
      map((resp:any) => {

        return resp;

      })

  );

}



// ***************************************************************************************
//  DELETE 
// ***************************************************************************************
Borrar(strApi:string)
{
  const url = URL_SERVICIOS + strApi;
//  const headerss = new HttpHeaders({'Content-Type':'application/json'});

return this.http.delete(url).pipe(
  map((resp:any) =>  {
    //return true;
    return resp;
  })

);

}




}
