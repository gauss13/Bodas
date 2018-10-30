import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UsuarioService } from '../usuario.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuardGuard implements CanActivate {

constructor(public _usuarioService: UsuarioService, public router: Router) {

}

  canActivate(): boolean {

    if( this._usuarioService.estaLogueado()){
      console.log('paso el guard login');
      return true;
    }
    else{
      console.log('bloqueado por guard login');
      this.router.navigate(['/login']);
      return false;
    }  


  }
}
