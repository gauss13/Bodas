import { Injectable } from '@angular/core';
import { Usuario } from '../models/usuario.model';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';

import { map,  catchError } from 'rxjs/operators'; // version 6 en adelante

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

usuario: Usuario;
token: string;


  constructor(public http: HttpClient, public router: Router ) { 
 // lo ejecutamos cada ves que el servicio de inicializa
 this.cargarStorage();

  }

// ***************************************************************************************
//   LOGIN
// ***************************************************************************************
  login(usuario: Usuario, recordar: boolean = false)
  {
    if(recordar) {
        localStorage.setItem('username', usuario.username);        
    }
    else {
      localStorage.removeItem('username');
    }


const url = URL_SERVICIOS + '/login';

const headerss = new HttpHeaders({'Content-Type':'application/json'});


let objUsuario = {UserName : usuario.username, Password: usuario.password, Nombre: usuario.nombre, Role : { Nombre: "admin"} }

return this.http.post(url, objUsuario,{headers: headerss}).pipe(
  map( (resp:any) => {

   
    this.guardarStorage(resp.id, resp.token, resp.usuario);

    return true;

  })
);




  }

// ***************************************************************************************
//  LOGOUT 
// ***************************************************************************************
logout() {
  this.usuario = null;
  this.token = '';


  localStorage.removeItem('token');
  localStorage.removeItem('usuario');
  localStorage.removeItem('menu');
  this.router.navigate(['/login']);
}




// ***************************************************************************************
//   ESTA LOGUEADO
// ***************************************************************************************
estaLogueado() {

  console.log(this.token);
  console.log(this.token.length);

  return (this.token.length > 5 ) ? true : false;
}

// ***************************************************************************************
//   
// ***************************************************************************************
guardarStorage(id: string, token: string, usuario: Usuario) {

  localStorage.setItem('idb', id);
  localStorage.setItem('tokenb', token);
  localStorage.setItem('usuariob', JSON.stringify(usuario));

  this.usuario = usuario;
  this.token = token;

}
// ***************************************************************************************
//  CARGAR DATOS DEL STORAGE 
// ***************************************************************************************
cargarStorage() {
  if( localStorage.getItem('token'))  {
    this.token = localStorage.getItem('token');
    this.usuario = JSON.parse( localStorage.getItem('usuario'));   
  } else {
    this.token = '';
    this.usuario = null;    
  }
}





}
