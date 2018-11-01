import { Component, OnInit } from '@angular/core';
import { AgendaService, HoraService,LugarcenaService, LugarceremoniaService, TipoceremoniaService, BackupService, PaqueteService  } from 'src/app/services/service.index';
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

  //VARIABLES
  arrEventos = [];
  textoDeValidacion: any;
  errorCampos: any;
  ignorarExistenCambiosPendientes: boolean = false;
  modoEdicion: boolean= false;
  fechaSeleccionada: string ='';

  horas: any;
  lugaresCeremonia: any;
  lugaresCena: any;
  tiposCeremonias:any;
  lugaresBack: any;
  paquetes: any;

  selectedHora:string = '';
  selectedCeremonia: number = 0;
  selectedTipoCe: number = 0;
  selectedCena: number = 0;
  selectedBack: number = 0;
  selectedPaquete: number =0;

// FORMULARIO 1
formG: FormGroup

  constructor(public _servicioAgenda: AgendaService, private fb: FormBuilder,
    private _horasService: HoraService,
    private _ceremoniaService: LugarceremoniaService,
    public _cenaService: LugarcenaService,
    public _tipoCeremoniaService: TipoceremoniaService,
    public _backupService: BackupService,
    public _paqueteService: PaqueteService
    ) { 


// FORMULARIO 2 - texto validacion
this.textoDeValidacion = {
  fechaBoda: { required: 'El campo Fecha Boda es <strong>requerido</strong>.' },
  horaBoda: { required: 'El campo Hora Boda es <strong>requerido</strong>.' },
  nombrePareja: { required: 'El campo nombre Pareja es <strong>requerido</strong>.' },
  correoPareja: { required: 'El campo correo Pareja es <strong>requerido</strong>.' },
  nacionalidad: { required: 'El campo nacionalidad es <strong>requerido</strong>.' },
  lugarCeremoniaId: { required: 'El campo lugar Ceremonia es <strong>requerido</strong>.' },
  lugarCenaId: { required: 'El campo lugar Cena es <strong>requerido</strong>.' },
  tipoCeremoniaId:{ required: 'El campo lugar Cena es <strong>requerido</strong>.' } 
}

 //backup no es obligatorio



// FORMULARIO 3 - validacion inicial
this.errorCampos = {
  fechaBoda: ' ',
  horaBoda: ' ',
  nombrePareja: ' ',
  correoPareja: ' ',
  nacionalidad: ' ',
  lugarCeremoniaId: ' ',
  tipoCeremoniaId: ' ',
  lugarCenaId: ' ',
  backUpId: ' '

}


  }

  ngOnInit() {

    this.construirFormulario();
    this.GetHoras();
    this.GetCeremonias();
    this.GetCenas();
    this.GetTiposCeremonia();
    this.GetBackups();
    this.GetPaquetes();
    this.initSelect();
    
    $(document).ready(function(){

      $('.modal').modal();  

    //  $('body').on('click', 'button.fc-prev-button', function() {
    //  // ejecutar servicio fechas por mes
    //   });


    }); // <- ready

  }


CargarFechas(yyyy:number, mm:number)
{
  this._servicioAgenda.GetFechasPorMes(yyyy,mm).subscribe(
    (resp:any) => {
    
    if(resp.ok == true)
    {
      //console.log(resp.fechas);

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

      dayClick: function(date, jsEvent, view) {        
        //Abrir modal 
        $('#modal1').modal('open');
        //obtener la fecha
        this.fechaSeleccionada = date.format();
        // patch   
       $('#fboda').val(this.fechaSeleccionada);
        // inicializa los select
       $('select').formSelect();



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
  
    fechaBoda         : ['', Validators.required],
    horaBoda          : ['', Validators.required],
    nombrePareja      : ['', Validators.required],
    correoPareja      : ['', Validators.required],
    nacionalidad      : ['', Validators.required],
    lugarCeremoniaId  : ['', Validators.required],
    lugarCenaId       : ['', Validators.required],
    tipoCeremoniaId   : ['', Validators.required],
    backUpId            : ['', Validators.required],
    paqueteId           : ['', Validators.required]
    // paxAdultos          : ['', Validators.required],
    // paxNinos            : ['', Validators.required],
    // paxJunior           : ['', Validators.required],
    // paxCunas            : ['', Validators.required],
    // paqueteId           : ['', Validators.required],
    // agenciaId           : ['', Validators.required],
    // comision            : ['', Validators.required],
    // fechaSelloAuditoria : ['', Validators.required], 
    // hotelId           : ['', Validators.required],   
    // tipoCeremoniaId   : ['', Validators.required],  
    // pax3raEdad        : ['', Validators.required],  
    // divisaComision    : ['', Validators.required],
    // divisaDeposito    : ['', Validators.required],
    // numHabitacion     : ['', Validators.required],
    // fechaConfirmada   : ['', Validators.required],

    // nombrePareja      : ['', Validators.required],
    // correoPareja      : ['', Validators.required],
    // nacionalidad      : ['', Validators.required],
    // nombreAgente      : ['', Validators.required],
    // correoAgencia     : ['', Validators.required],
    // deposito          : ['', Validators.required],
    // numReserva        : ['', Validators.required],
    // promocion         : ['', Validators.required],
    // fechaPago         : ['', Validators.required],
    // fechaLlegada      : ['', Validators.required], 
    // bookingReference  : ['', Validators.required]
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

// ***************************************************************************************
//  GETS SELECTS 
// ***************************************************************************************
GetHoras()
{
  this._horasService.GetHoras().subscribe( (resp:any)=> {
        this.horas = resp;
  });
}

GetCeremonias()
{
  this._ceremoniaService.GetLugaresCeremonia().subscribe( (resp:any) => {
    this.lugaresCeremonia = resp.lugarCeremonia;
  });
}

GetTiposCeremonia()
{
  this._tipoCeremoniaService.GetTiposCeremonia().subscribe((resp: any) => {

    console.log('GET Tipo' + resp);

  this.tiposCeremonias = resp.tipoCeremonia;

  });
}


GetCenas()
{
  this._cenaService.GetLugaresCena().subscribe((resp: any) => {

    console.log('GET GET' + resp);

  this.lugaresCena = resp.lugarCena;
  });
}


GetBackups()
{
this._backupService.GetLugaresBackup().subscribe( (resp:any) => {
this.lugaresBack = resp.backUp;
});

}


GetPaquetes()
{
  this._paqueteService.GetPaquetes().subscribe( (resp:any) => {
  this.paquetes = resp.paquete;
  } );
}



initSelect()
{
  $('select').formSelect();
}


patchFecha()
{
 // this.formG.reset();

console.log(this.fechaSeleccionada );

  this.formG.patchValue({
    fechaBoda : this.fechaSeleccionada          
  });

}



}
