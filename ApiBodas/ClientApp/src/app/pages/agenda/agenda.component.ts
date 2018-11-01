import { Component, OnInit } from '@angular/core';
import { AgendaService } from 'src/app/services/service.index';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import {mostrarErrorx, onCambioValorx} from '../../Utils/formUtils';
import { ObjectUnsubscribedError } from 'rxjs';

declare var $: any;
declare var M: any;



@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styles: [],
})
export class AgendaComponent implements OnInit {

  arrEventos = [];

  textoDeValidacion: any;
  errorCampos: any;
  ignorarExistenCambiosPendientes: boolean = false;
  modoEdicion: boolean= false;

// FORMULARIO 1
formG: FormGroup

  constructor(public _servicioAgenda: AgendaService, private fb: FormBuilder) { 


// FORMULARIO 2 - texto validacion
this.textoDeValidacion = {
  fechaBoda: { required: 'El campo Lugar es <strong>requerido</strong>.' }

}

// FORMULARIO 3 - validacion inicial
this.errorCampos = {
  fechaBoda: ' ',
  otro: ' ',
  hotelid: ' ',
  activo: ' '
}


  }

  ngOnInit() {

    this.construirFormulario();
    
    $(document).ready(function(){

      $('.modal').modal();  

     $('body').on('click', 'button.fc-prev-button', function() {
     // ejecutar servicio fechas por mes
   
    });
    }); // <- ready

  }


CargarFechas(yyyy:number, mm:number)
{
  this._servicioAgenda.GetFechasPorMes(yyyy,mm).subscribe(
    (resp:any) => {
    
    if(resp.ok == true)
    {
      console.log(resp.fechas);

      this.arrEventos = resp.fechas;
      $('#calendar').fullCalendar('removeEvents');
      $('#calendar').fullCalendar('addEventSource', this.arrEventos);

    }
    else
    {
      this.arrEventos = [];
      $('#calendar').fullCalendar('removeEvents');
      $('#calendar').fullCalendar('addEventSource', this.arrEventos);
    }

});
}

  // ***************************************************************************************
  //  Inicializar el calendario 
  // ***************************************************************************************
  IniciarCal()
  {
    $('#calendar').fullCalendar('destroy');

   
    
    $('#calendar').fullCalendar( {
      // put your options and callbacks here
      locale: 'es',
      defaultView: 'month',
      weekends: false,
      
      header: {left:'title', right:'', center:''},
      dayClick: function() {
        // alert('a day has been clicked!');
        $('#modal1').modal('open');
      },


    //  hiddenDays: [ 2, 4 ]
    events: [
      {
        id: 5,
        title  : 'event1',
        start  : '2018-10-01',
        color : 'yellow',
        textColor: 'black'

      },
      {
        title  : 'event2',
        start  : '2018-10-05',
        end    : '2018-10-07'
      },
      {
        title  : 'event3',
        start  : '2018-10-09T12:30:00',
        allDay : false // will make the time show
      }
    ]

    });


    M.toast({html: 'Calendario iniciado!'});
  }

// ***************************************************************************************
//  Destruir el calendario 
// ***************************************************************************************
  DestroyCal()
  {
    $('#calendar').fullCalendar('destroy');
  }

// ***************************************************************************************
//  Obetener Fecha Actual 
// ***************************************************************************************
GetFecha()
{
  var moment = $('#calendar').fullCalendar('getDate');
  alert("The current date of the calendar is " + moment.format());
}
// ***************************************************************************************
//  TODAY 
// ***************************************************************************************
GoToday()
{
  $('#calendar').fullCalendar('today');

}
// ***************************************************************************************
//   
// ***************************************************************************************
GoAnterior()
{
  $('#calendar').fullCalendar('prev');

  var moment = $('#calendar').fullCalendar('getDate');

  console.log( moment._i[0] + ' - '+ (moment._i[1]+1));

  this.CargarFechas(moment._i[0], moment._i[1]-1);
}

// ***************************************************************************************
//  Siguiente 
// ***************************************************************************************
GoSiguiente()
{
  $('#calendar').fullCalendar('next');

  var moment = $('#calendar').fullCalendar('getDate');

  console.log( moment._i[0] + ' - '+ (moment._i[1]+1));

  this.CargarFechas(moment._i[0], moment._i[1]+1);

}


// ***************************************************************************************
//  FORMULARIO  
// ***************************************************************************************
// captura evento
formChangesSub: any;

construirFormulario()
{
  this.formG = this.fb.group({
  
    lugarCeremoniaId    : ['', Validators.required],
    lugarCenaId         : ['', Validators.required],
    backUpId            : ['', Validators.required],
    paxAdultos          : ['', Validators.required],
    paxNinos            : ['', Validators.required],
    paxJunior           : ['', Validators.required],
    paxCunas            : ['', Validators.required],
    paqueteId           : ['', Validators.required],
    agenciaId           : ['', Validators.required],
    comision            : ['', Validators.required],
    fechaSelloAuditoria : ['', Validators.required], 
    hotelId           : ['', Validators.required],   
    tipoCeremoniaId   : ['', Validators.required],  
    pax3raEdad        : ['', Validators.required],  
    divisaComision    : ['', Validators.required],
    divisaDeposito    : ['', Validators.required],
    numHabitacion     : ['', Validators.required],
    fechaConfirmada   : ['', Validators.required],
    fechaBoda         : ['', Validators.required],
    horaBoda          : ['', Validators.required],
    nombrePareja      : ['', Validators.required],
    correoPareja      : ['', Validators.required],
    nacionalidad      : ['', Validators.required],
    nombreAgente      : ['', Validators.required],
    correoAgencia     : ['', Validators.required],
    deposito          : ['', Validators.required],
    numReserva        : ['', Validators.required],
    promocion         : ['', Validators.required],
    fechaPago         : ['', Validators.required],
    fechaLlegada      : ['', Validators.required], 
    bookingReference  : ['', Validators.required]
  });

// manejador del evento de cambio de valor en los inputs
this.formChangesSub = this.formG.valueChanges.subscribe( data => this.onCambioValor());
this.formG.touched;
this.formG.markAsTouched();

}

mostrarError(campo){
//  mostrarErrorx(campo, this.formG, this.textoDeValidacion, this.errorCampos);
  }

onCambioValor()
{
 // onCambioValorx( this.formG, this.textoDeValidacion, this.errorCampos);
}

existenCambiosPendientes(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.formG.pristine; //pristine indica si el formulario ha sido editado

}
resetFormulario() {
  this.formG.reset();
  //this.selectedId = 0;
}

save(){}

// ***************************************************************************************
//   GET Lugar Ceremonia
// ***************************************************************************************
GetLugaresCeremonia()
{

}






}
