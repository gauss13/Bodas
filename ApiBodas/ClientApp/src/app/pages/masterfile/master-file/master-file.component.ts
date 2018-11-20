import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Globalx } from 'src/app/config/global';
import { GenericoService } from 'src/app/services/service.index';
import { uriMasterFile, uriMasterFileContenido, uriAgenda, alertSuccess, alertError, alertMessage, alertWarning, alertInfo } from 'src/app/config/config';
import { NgForm } from '@angular/forms';
import { MasterFileContenido } from 'src/app/models/masterfilecontenido.model';


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
strHoraBoda:string='';
iniciarMaster:boolean = false;

agenda:any;
master:any;
paquete:any;
servicios:any;

idAgenda:number = 0;


// FORMULARIO
frmId:number=0;
frmCantidad:number=0;
frmDivisa:number=0;
frmDivisaId:number=0;
frmUnitario:number=0;
frmTotal:number=0;
frmServicio:number=0;
frmServicioId:number=0;
frmIncluido:boolean=false;
frmNota:string;
frmNota2:string;
frmNota3:string;
//IMG cambiar imagen // version 2

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
          //console.log('contenido', JSON.parse(resp.contenido));
          console.log('Contenido', resp);

          if(resp.contenido !== null )
          this.servicios = resp.contenido;  //JSON.parse(resp.contenido);

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
    this.strHoraBoda = this.agenda.horaBoda;
  
}

activarscroll()
{
  $('.scrollspy').scrollSpy();
}

// **************************************** SET Datos Formulario ***********************************************

setFormulario(servicio:any)
{

  console.log('seleccionado: ', servicio);

  this.frmId = servicio.id;
  this.frmCantidad= servicio.cantidad;
  // this.frmDivisa= servicio.;
  // this.frmDivisaId= servicio.divisaId; // divisa sera la que tiene le masterfile que lo tomará del paquete
  this.frmUnitario= servicio.precioUnitario;
  this.frmTotal= servicio.total;
  this.frmServicio= servicio.servicio.descripcion;
  this.frmServicioId= servicio.servicioId;
  this.frmIncluido= servicio.incluido;

this.frmNota = servicio.nota;
this.frmNota2 = servicio.nota2;
this.frmNota3 = servicio.nota3;

}

guardaFormulario(f:NgForm)
{ 
  let item: MasterFileContenido;

item = {
  id	:	0,
  masterFileId	:	    this.master.id,
  servicioId	:	    this.frmServicioId,
  precioUnitario	:	    this.frmUnitario,
  cantidad	:	    this.frmCantidad,
  total	:	    this.frmTotal,
  img	:	    null,
  divisaId	:	    this.master.divisaId,
  tieneImagen	:	    false,//imagen
  ocRealizado	:	    false,
  ocRequerido	:	    false,
  incluido	:	    this.frmIncluido,
  nota	:	    this.frmNota,
  nota2	:	    this.frmNota2,
  nota3	:	    this.frmNota3

};

// **************************************** api ***********************************************
  const url = uriMasterFileContenido + this.frmId;

  this._servicioGenerico.Actualizar(item, url).subscribe( (resp:any) => {

        if( resp.ok === true)
        {    
          M.toast({html: 'Se actualizó el registro, correctamente!', classes: alertInfo});

          //buscar el registro en el array
          let itemEncontrado = this.servicios.find( item => item.id ===  this.frmId);
          let pos = this.servicios.indexOf(itemEncontrado);          
          this.servicios[pos] = resp.contenido;  

        }  

  },
  (error) => {},
  () => {}
);


}

cambioCantidad(cantidad)
{
  if(isNaN(cantidad))
  {
    M.toast({html: '<strong> Solo se aceptan numeros <strong>', classes:' rounded  pink darken-2'}); 
    this.frmCantidad = 0;
    return;
  }

  this.frmTotal = this.frmCantidad * this.frmUnitario;

}

cambioUnitario(preciounitario)
{
  if(isNaN(preciounitario))
  {
    M.toast({html: '<strong> Solo se aceptan numeros <strong>', classes:' rounded  pink darken-2'}); 
    this.frmCantidad = 0;
    return;
  }

  this.frmTotal = this.frmCantidad * this.frmUnitario;
}


}
