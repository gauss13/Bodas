import { Component, OnInit } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {

    $(document).ready(function() {

    
      $(".dropdown-trigger").dropdown();


      $('.sidenav').sidenav();

  });

  }

}
