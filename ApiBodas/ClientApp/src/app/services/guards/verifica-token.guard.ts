import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UsuarioService } from '../usuario.service';

@Injectable({
  providedIn: 'root'
})
export class VerificaTokenGuard implements CanActivate {

constructor(public _usuarioService: UsuarioService, public router: Router){

}

  canActivate(): boolean {
    
    const token = this._usuarioService.token;

    var array = token.split('.');
 

    const payload = JSON.parse( atob(token.split('.')[1]));

    // console.log(payload.exp);

    const expirado = this.expirado(payload.exp);
    // console.log('verifica', expirado);

if(expirado)
{
  this.router.navigate(['/login']);
  return false;
}

return true;

  }

// ***************************************************************************************
//   
// ***************************************************************************************
  expirado( fechaExp: number) {
    // obtenemos la hora del sistema y lo convertimos a segundos dividiendolo entre 1000
    let ahora = new Date().getTime() / 1000;

    if( fechaExp < ahora) {
      return true;
    } else {
      return false;
    }
  }

}
