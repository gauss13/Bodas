import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/service.index';
declare var $: any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  titulo = 'inicial';
  constructor(public _usuarioService: UsuarioService) { }

  ngOnInit() {

    $(document).ready(function() {

    
      $(".dropdown-trigger").dropdown();


      $('.sidenav').sidenav();

  });

  }

}
