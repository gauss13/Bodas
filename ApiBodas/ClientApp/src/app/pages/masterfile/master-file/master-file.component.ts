import { Component, OnInit } from '@angular/core';

declare var $: any;
declare var M: any;

@Component({
  selector: 'app-master-file',
  templateUrl: './master-file.component.html',
  styles: []
})
export class MasterFileComponent implements OnInit {

//Variables
strNombrePareja:string ='PerezLuche';
strHotel:string = 'SADOS CARACOL';
strFechaBoda:string='11/12/2018';
strReunionCoordinador:string ='TBC';
strBooking:string='SC977HSI';
strContacto:string='ludo@perez.com';
strPaquete:string='Emerald Breeze';
strTotal:number=10;


  constructor() { }

  ngOnInit() {


     // READY JQUERY
     $(document).ready(function(){ 

      $('.scrollspy').scrollSpy();

    });

  }

// **************************************** GET DATAS ***********************************************

// **************************************** GET agenda ***********************************************

// **************************************** GET servicios ***********************************************

// **************************************** GET divisas ***********************************************




activarscroll()
{
  $('.scrollspy').scrollSpy();
}




}
