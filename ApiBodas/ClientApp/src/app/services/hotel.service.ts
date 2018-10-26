import { Injectable } from '@angular/core';
import { Hotel } from '../models/hotel.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  //hotel: Hotel;
  totalRegistros: number = 0;

  constructor(public http: HttpClient, public router:Router) { }


// ***************************************************************************************
//  Get Hoteles 
// ***************************************************************************************

GetHoteles()
{
  const url = URL_SERVICIOS + '/api/Hotel';

  return this.http.get(url).pipe(
map( (resp:any) => {

  this.totalRegistros = resp.total;


  return resp.hotel;

})


  );
}


}
