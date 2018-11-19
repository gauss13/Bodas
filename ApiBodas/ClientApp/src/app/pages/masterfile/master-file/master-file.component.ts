import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Globalx } from 'src/app/config/global';
import { GenericoService } from 'src/app/services/service.index';
import { uriMasterFile, uriMasterFileContenido, uriAgenda, alertError } from 'src/app/config/config';


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
strTotalPersonas:number=10;
iniciarMaster:boolean = false;

agenda:any;
master:any;
paquete:any;
servicios:any;

idAgenda:number = 0;

  constructor(     public _gbl:Globalx,
                   public activeRoute: ActivatedRoute,
                   private _router:Router,
                   private _servicioGenerico: GenericoService) {


//Active Route
activeRoute.params.subscribe(
  params =>  {

    const texto = params['ida'];
    
    if(!isNaN(texto))
    {
      this.iniciarMaster = true;
      this.idAgenda = texto;
    }
    else
    {
      this.idAgenda = 0;
      console.log('no es un digito');
      var ruta = '/agenda/ini';
      this._router.navigate([ruta]); 
    }
  }
);

   }

  ngOnInit() {


     // READY JQUERY
     $(document).ready(function(){ 

      $('.scrollspy').scrollSpy();
      $('.sidenav').sidenav({edge:'right' });

    });

    if(this.iniciarMaster)
    {
      console.log('iniciar carga');
      //cargar datos del master
      this.getAgenda();
    }

  }

// **************************************** GET DATAS ***********************************************

// **************************************** Master y Content ***********************************************

getMasterContent(mfid:number)
{
  const url = uriMasterFileContenido+'contenido/' + mfid;

  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

        if(resp.ok === true)
        {          
          console.log('contenido', JSON.parse(resp.contenido));

          if(resp.contenido !== null )
          this.servicios = JSON.parse(resp.contenido);

        }
  },
  (error) => {},
  () => {}
);


}


// **************************************** GET agenda ***********************************************

getAgenda()
{

  const url = uriAgenda+ this._gbl.hotelIdSelected+'/master/' + this.idAgenda;

  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

        if(resp.ok === true)
        {    
          console.log('apm', resp)

          this.agenda = resp.agenda;
          this.paquete = resp.paquete;
          this.master = resp.master;

          this.setData();
          this.getMasterContent(this.master.id);
        }
  },
  (error) => {},
  () => {}
);

}

// **************************************** GET servicios ***********************************************

// **************************************** GET divisas ***********************************************


// **************************************** SET datos a las variables ***********************************************

setData()
{

    this.strNombrePareja = this.agenda.nombrePareja;
    this.strHotel= this.master.hotel;
    this.strFechaBoda = this.agenda.fechaBoda + ' ' + this.agenda.horaBoda;
    this.strReunionCoordinador = 'TBC'
    this.strBooking= this.agenda.BookingReference;
    this.strContacto = this.agenda.correoPareja;
    this.strPaquete = this.paquete.descripcion;
    this.strTotalPersonas = this.agenda.paxAdultos;
  
}

activarscroll()
{
  $('.scrollspy').scrollSpy();
}




}
