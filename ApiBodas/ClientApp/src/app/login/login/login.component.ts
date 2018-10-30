import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Usuario } from 'src/app/models/usuario.model';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/service.index';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username:string;
reacuerdame: boolean = false;


  constructor(public router: Router, public _usuarioService: UsuarioService) { }

  ngOnInit() {

    this.username = localStorage.getItem('username') || '';
    if(this.username.length > 0){
      this.reacuerdame = true;
    }
  }


 ingresar(forma: NgForm)
  {


    if(!forma.valid){ return;}

    const usuario = new Usuario(0, forma.value.usuariox, forma.value.passx,'x','x');

this._usuarioService.login(usuario, true).subscribe( resp => {
  this.router.navigate(['/dashboard']);
});


}


}
