import { Component, OnInit } from '@angular/core';
import { AgendaService, HoraService,LugarcenaService, LugarceremoniaService, TipoceremoniaService, BackupService, PaqueteService, AgenciaService, DivisaService  } from 'src/app/services/service.index';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import {mostrarErrorx, onCambioValorx} from '../../Utils/formUtils';
import { ObjectUnsubscribedError } from 'rxjs';
import { Agenda } from '../../models/agenda.model';
import { Globalx } from 'src/app/config/global';
import { ActivatedRoute } from '@angular/router';



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
  setFechaBoda: boolean = false;
  idHotel = 0;
  idAgenda= 0;
  tipoAgenda=0;
  progreso=10;
  strTipo='Tentativo';
  
  // disponible = 0 
  // tentativo   = 1 -> Edit -> Confirm -> Cancelar -> 
  // confirmado  = 2 -> Editar ->  Cancelar -> Finalizar
  // cancelado   = 3 -> Nada - posible apertura
  // bloqueado   = 4 -> Nada
  // Finalizado  = 5 -> nada

  horas: any;
  lugaresCeremonia: any;
  lugaresCena: any;
  tiposCeremonias:any;
  lugaresBack: any;
  paquetes: any;
  agencias:any;
  divisas:any;

  fechaSeleccionada: string ='';
  agendaIdSelected:number = 0;
  tipoAgendaSelected:number = 0;
  selectedHora:string = '';
  selectedCeremonia: number = 0;
  selectedTipoCe: number = 0;
  selectedCena: number = 0;
  selectedBack: number = 0;
  selectedPaquete: number =0;
  selectedAgencia: number =0;
  selectedDivisaCom: number =0;
  selectedDivisaDepo: number =0;

  fechaDato:string='';
  parejaDato:string='';
  correoDato:string='';
  depositoDato:string='';



  

// FORMULARIO 1
formG: FormGroup

  constructor(public _servicioAgenda: AgendaService, private fb: FormBuilder,
    private _horasService: HoraService,
    private _ceremoniaService: LugarceremoniaService,
    public _cenaService: LugarcenaService,
    public _tipoCeremoniaService: TipoceremoniaService,
    public _backupService: BackupService,
    public _paqueteService: PaqueteService,
    public _agenciaService: AgenciaService,
    public _divisaService: DivisaService,
    public _gbl:Globalx,
    public activeRoute: ActivatedRoute
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
  tipoCeremoniaId:{ required: 'El campo lugar Cena es <strong>requerido</strong>.' } ,

  backUpId:{ required: 'El campo backUp es <strong>requerido</strong>.' } ,
  paqueteId:{ required: 'El campo paquete es <strong>requerido</strong>.' } ,
  agenciaId:{ required: 'El campo agencia es <strong>requerido</strong>.' } ,
  
}



// FORMULARIO 3 - validacion inicial
this.errorCampos = {
  fechaBoda: '',
  horaBoda: '',
  nombrePareja: '',
  correoPareja: '',
  nacionalidad: '',
  lugarCeremoniaId: '',
  tipoCeremoniaId: '',
  lugarCenaId: '',
  backUpId:'',
  paqueteId:'',
  agenciaId:''
}

//Active Route
activeRoute.params.subscribe(
  params =>  {
    const texto = params['abc'];
    if(texto !== 'ini')
    {
      // console.log(this.idHotel);
      // console.log(this._gbl.hotelIdSelected);

      if(this.idHotel !== this._gbl.hotelIdSelected)
      {  
        if( this.idHotel !== 0)
        {
        // console.log('se inicia')
        this.IniciarCal();
        }
        this.idHotel = this._gbl.hotelIdSelected;
      }

    }    
  }
);

} // <- constructor


  ngOnInit() {

    this._gbl.tituloModulo ="Agenda";
   
    this.construirFormulario();
    this.GetHoras();
    this.GetCeremonias();
    this.GetCenas();
    this.GetTiposCeremonia();
    this.GetBackups();
    this.GetPaquetes();
    this.GetAgencias();
    this.GetDivisas();

   this.initSelect();
   // this.initNacionalidad();
    
    $(document).ready(function(){

      $('.modal').modal({
      
      });  

      $('.sidenav').sidenav({edge:'right' });

      //  $('body').on('click', 'button.fc-prev-button', function() {
      //  // ejecutar servicio fechas por mes
      //   });


    }); // <- ready

  }


CargarFechas(yyyy:number, mm:number)
{

  var hid = this._gbl.hotelIdSelected;

if(hid !== undefined && hid !== null)
{
  this._servicioAgenda.GetFechasPorMes(yyyy,mm, hid).subscribe(
    (resp:any) => {
    
    if(resp.ok == true)
    {    
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
    //  weekends: true,
      
      header: {left:'title', right:'', center:''},
      disabledDays: [2,30],

      dayClick: function(date, allDay, jsEvent, view) {        
        //Abrir modal 
        //$('#modal1').modal('open');

      //   if(allDay) {
      //     alert('That is not a valid time slot!');
      //     return;
      // }

        //obtener la fecha
        this.fechaSeleccionada = date.format("DD/MM/YYYY");

       // alert(date + ' formt: '+this.fechaSeleccionada);
        // patch   
       $('#fboda').val(this.fechaSeleccionada);

        // inicializa los select
       $('select').formSelect();

       //init autocomplete
       $('input.autocomplete').autocomplete({
        data: {
          "Apple": null,
          "Microsoft": null,
          "Google": 'https://placehold.it/250x250'
        },
      });
    

      // $('#patchfecha').click();
       $('#btnCrear').click();

      },
      eventClick: function(calEvent, jsEvent, view) {

      //  alert('Event: ' + calEvent.title + ' Id: ' + calEvent.idagenda + ' Tipo: ' + calEvent.estatus);
      $('#idagendaedit').val(calEvent.idagenda);
      $('#tipoagenda').val(calEvent.estatus);

        // if (calEvent.url) {
        //   window.open(calEvent.url);
        //   return false;
        // }


      //  $('#btnEditar').click();

      $('#btnSideBar').click();



      
      },
      timeFormat: 'HH:mm',

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

// Cargar datos

var moment = $('#calendar').fullCalendar('getDate');

this.CargarFechas(moment._i[0], moment._i[1]+1);

    M.toast({html: '<strong> Calendario de ' + this._gbl.hotelSelected+ ' iniciado <strong>', classes:' rounded  pink darken-2'});
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
  alert("Fecha actual " + moment.format());
}
// ***************************************************************************************
//  TODAY 
// ***************************************************************************************
GoToday()
{
  $('#calendar').fullCalendar('today');
  var moment = $('#calendar').fullCalendar('getDate');
  this.CargarFechas(moment._i[0], moment._i[1]+1);
}
// ***************************************************************************************
//   
// ***************************************************************************************
GoAnterior()
{
  $('#calendar').fullCalendar('prev');

  var moment = $('#calendar').fullCalendar('getDate');

  this.CargarFechas(moment._i[0], moment._i[1]+1);
}

// ***************************************************************************************
//  Siguiente 
// ***************************************************************************************
GoSiguiente()
{
  $('#calendar').fullCalendar('next');

  var moment = $('#calendar').fullCalendar('getDate');

  this.CargarFechas(moment._i[0], moment._i[1]+1);

}


// ***************************************************************************************
//  FORMULARIO  - hotel id - sera el que seleccione antes entrar a la agenda
// ***************************************************************************************
// captura evento
formChangesSub: any;

construirFormulario()
{
  this.formG = this.fb.group({
  
    fechaBoda         : [{value: ''}, Validators.required],
    horaBoda          : ['', Validators.required],
    nombrePareja      : ['', Validators.required],
    correoPareja      : ['', Validators.required],
    nacionalidad      : ['', Validators.required],
    lugarCeremoniaId  : ['', Validators.required],
    lugarCenaId       : ['', Validators.required],
    tipoCeremoniaId   : ['', Validators.required],
    backUpId          : ['', Validators.required],
    paqueteId         : ['', Validators.required],
    agenciaId         : ['', Validators.required],
    comision          : [''],
    divisaComision    : [''],
    
    paxAdultos        : [''],
    paxJunior         : [''],
    paxNinos          : [''],    
    paxCunas          : [''],
    pax3raEdad        : [''], 
    nombreAgente      : [''],
    correoAgencia     : [''],
    numReserva        : [''],
    numHabitacion     : [''],
    bookingReference  : [''],

    promocion         : [''],
    deposito          : [''], 
    divisaDeposito    : [''],
   
    fechaConfirmada   : [''],
    fechaPago         : [''],     
    fechaLlegada      : [''],
    fechaSelloAuditoria : ['']        
  });

// Fecha de pago =>  pago de la comision



// manejador del evento de cambio de valor en los inputs
this.formChangesSub = this.formG.valueChanges.subscribe( data => this.onCambioValor());
this.formG.touched;
this.formG.markAsTouched();

}

mostrarError(campo){
  mostrarErrorx(campo, this.formG, this.textoDeValidacion, this.errorCampos);
  }

onCambioValor()
{
  
  onCambioValorx( this.formG, this.textoDeValidacion, this.errorCampos);
}

existenCambiosPendientes(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.formG.pristine; //pristine indica si el formulario ha sido editado

}
resetFormulario() {
  this.formG.reset();
  //this.selectedId = 0;
}

// ***************************************************************************************
//  GUARDAR CAMBIOS 
// ***************************************************************************************
save(){

  console.log(this.tipoAgendaSelected);
  //validar el tipo de agenda antes de guardar
  if(this.tipoAgendaSelected > 2)
  {
    M.toast({html: 'El registro No puede editar!', classes: 'rounded pink darken-3'});
return false;
  }

 let itemAgenda: Agenda = Object.assign({}, this.formG.value)

 itemAgenda.hotelId = this._gbl.hotelIdSelected; 
 itemAgenda.estadoAgendaId = 1;

// validar campos vacios
if(this.formG.value.comision === "" || this.formG.value.comision === null)
  itemAgenda.comision = 0;

if(this.formG.value.deposito === "" || this.formG.value.deposito === null)
    itemAgenda.deposito = 0; 

if(this.formG.value.numHabitacion === "" || this.formG.value.numHabitacion === null)
    itemAgenda.numHabitacion = 0;

let fb = this.GenFecha(this.formG.value.fechaBoda); 

 itemAgenda.fechaBoda = fb;

 if(!this.modoEdicion )
 {
 // CREAR
 //console.log('crear : ' +  this.formG.value.fechaBoda);

 this._servicioAgenda.CrearAgenda(itemAgenda).subscribe( (resp:any) => {
        //Respuesta post
        if(resp.ok)
        {
          M.toast({html: 'El registro se guardó correctamente!', classes: 'rounded pink darken-3'});
          var moment = $('#calendar').fullCalendar('getDate');
          this.resetFormulario();        
          this.CargarFechas(moment._i[0], moment._i[1]+1); 
        }
 });
}
else
{
  //console.log('actualizar fboda: ' + this.formG.value.fechaBoda);
 //ACTUALIZAR
  this._servicioAgenda.ActualizarAgenda(itemAgenda, this.agendaIdSelected).subscribe( (resp:any) => {
    //Respuesta post
    if(resp.ok)
    {
      M.toast({html: '<strong>El registro se actualizó correctamente!</strong>', classes:'rounded  pink darken-3'});
      var moment = $('#calendar').fullCalendar('getDate');
      this.resetFormulario();            
      this.CargarFechas(moment._i[0], moment._i[1]+1);     
    }
});

}
 // limpiar datos
 this.modoEdicion = false;
 this.agendaIdSelected = 0;
 this.tipoAgendaSelected = 0;



this.resetFormulario();

}


formatoFecha(f:string)
{
var str = f.split("/");

var strFecha = `${str[1]}/${str[0]}/${str[2]}`

return strFecha;
}

GenFecha(f:string)
{
  var str = f.split("/");
  var strFecha = `${str[1]}/${str[0]}/${str[2]}`
  //var d = new Date(+str[2],+str[1],+str[0])
  var fecha  = new Date(strFecha);

return fecha;
}

GenFechaFromDb(f:string)
{
var separateTime = f.split("T");

var str = separateTime[0].split("-");

var strFecha = `${str[2]}/${str[1]}/${str[0]}`

return strFecha;

}


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

  this.tiposCeremonias = resp.tipoCeremonia;

  });
}


GetCenas()
{
  this._cenaService.GetLugaresCena().subscribe((resp: any) => {

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

GetAgencias()
{
  this._agenciaService.GetAgencias().subscribe( (resp:any) => {
  this.agencias = resp.agencia;
});
}

GetDivisas()
{
    this._divisaService.GetDivisas().subscribe( (resp:any) => {
    this.divisas = resp.divisa;
    });
}

// ***************************************************************************************
//  INIT - SELECT DATEPICKER 
// ***************************************************************************************

initSelect()
{
  $('select').formSelect();
  // $('.tooltipped').tooltip();
//   $('.datepicker').datepicker({
//     format:'dd/mm/yyyy', 
//     // autoClose:true,
//     // closeOnSelect: true,
//    selectMonths: false,
//    selectYears: 5,
//    firstDay: true, 
//    today:false,
//    formatSubmit: 'dd/mm/yyyy',
//    i18n: {
//     cancel: 'Cancelar',
//     clear: 'Limpiar',
//     done:    'Ok',
//     today: 'Hoy',
//     months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
//     monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Set", "Oct", "Nov", "Dic"],
//     weekdays: ["Domingo","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
//     weekdaysShort: ["Dom","Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
//     weekdaysAbbrev: ["D","L", "M", "M", "J", "V", "S"]
// }});
 // $('.datepicker').datepicker();
}

initNacionalidad()
{

  $('input.autocomplete').autocomplete({
    data: {
      "Apple": null,
      "Microsoft": null,
      "Google": 'https://placehold.it/250x250'
    },
  });

}

// ======================================================
// PATCHES
// ======================================================
patchFecha()
{
 // this.formG.reset();
 var fechab = $('#fboda').val();

console.log('patch val :'  + fechab);

this.formG.patchValue({
    fechaBoda : fechab       
  });

}

modalCrear()
{

  this.agendaIdSelected = 0;
  this.tipoAgendaSelected = 0;
  this.selectedHora = '';
  this.selectedCeremonia  = 0;
  this.selectedTipoCe  = 0;
  this.selectedCena  = 0;
  this.selectedBack  = 0;
  this.selectedPaquete =0;
  this.selectedAgencia =0;
  this.selectedDivisaCom =0;
  this.selectedDivisaDepo =0;

  this.strTipo ='Tentativo';

if(this.modoEdicion === true)
{
  
  this.modoEdicion = false;
//  this.resetFormulario();
 
  var fechab = $('#fboda').val();

  this.formG.patchValue({
    fechaBoda         :  fechab,
    horaBoda          :'',
    nombrePareja      :'',
    correoPareja      :'',
    nacionalidad      :'',
    lugarCeremoniaId  :'',
    lugarCenaId       :'',
    tipoCeremoniaId   :'',
    backUpId          :'',
    paqueteId         :'',
    agenciaId         :'',
    comision          :'',
    divisaComision    :'',
    paxAdultos        :'',
    paxJunior         :'',
    paxNinos          :'',
    paxCunas          :'',
    pax3raEdad        :'',
    nombreAgente      :'',
    correoAgencia     :'',
    numReserva        :'',
    numHabitacion     :'',
    bookingReference  :'',
    promocion         : '',
    deposito          : '',
    divisaDeposito    : '',
    fechaConfirmada   : '',
    fechaPago         : '',
    fechaLlegada      : '',
    fechaSelloAuditoria : '' 
   
  });
  // this.modoEdicion = false;
  this.initSelect();
  // this.modoEdicion = false;
}
else
{
  this.patchFecha();
}

// this.formG.value.touched;
// this.formG.markAsTouched();

 
}

modalEdicion()
{
  var ida = $('#idagendaedit').val();
  var tipoa = $('#tipoagenda').val();

  this.idAgenda= ida;
  this.tipoAgenda=tipoa;
  this.modoEdicion = true;

if(tipoa == 3 ) // Cancelado
{
  this.progreso = 0
  this.strTipo ='Cancelado';
}
if(tipoa == 4) // Cancelado
{
  this.progreso = 0
  this.strTipo ='Bloqueado';
}



if(tipoa == 1)//Tentativo
{
  this.strTipo ='Tentativo';
this.progreso = 15
}

if(tipoa == 2) // Confirmado
{
  this.strTipo ='Confirmado';
this.progreso = 55
}

if(tipoa == 5) // terminado
{
  this.strTipo ='Finalizado';
this.progreso = 100
}

  // this.resetFormulario();
var agendadb:any;

// consular agenda
this._servicioAgenda.GetAgendaById(ida).subscribe(
  (resp:any)=>{

    if(resp.ok === true)
    {
      agendadb = resp.agenda;

      // console.table(agendadb);

      this.agendaIdSelected = ida;
      this.tipoAgendaSelected = agendadb.estadoAgendaId;
      this.selectedHora = agendadb.horaBoda;
      this.selectedCeremonia  = agendadb.lugarCeremoniaId;
      this.selectedTipoCe  = agendadb.tipoCeremoniaId;
      this.selectedCena  = agendadb.lugarCenaId;
      this.selectedBack  = agendadb.backUpId;
      this.selectedPaquete  =agendadb.paqueteId;
      this.selectedAgencia  =agendadb.agenciaId;
      this.selectedDivisaCom  =agendadb.divisaComision == null ? 0 : agendadb.divisaComision;
      this.selectedDivisaDepo  =agendadb.divisaDeposito == null ? 0 : agendadb.divisaDeposito;


      //datos sidebar
      this.fechaDato = this.GenFechaFromDb(agendadb.fechaBoda) +' ' +agendadb.horaBoda;
      this.parejaDato = agendadb.nombrePareja;
      this.correoDato = agendadb.correoPareja;
      this.depositoDato = agendadb.deposito;


      this.formG.patchValue({
        fechaBoda         :  this.GenFechaFromDb(agendadb.fechaBoda),
        horaBoda          :  agendadb.horaBoda,
        nombrePareja      :  agendadb.nombrePareja,
        correoPareja      :  agendadb.correoPareja,
        nacionalidad      :  agendadb.nacionalidad,
        lugarCeremoniaId  :  agendadb.lugarCeremoniaId,
        lugarCenaId       :  agendadb.lugarCenaId,
        tipoCeremoniaId   :  agendadb.tipoCeremoniaId,
        backUpId          :  agendadb.backUpId,
        paqueteId         :  agendadb.paqueteId,
        agenciaId         : agendadb.agenciaId,
        comision          :  agendadb.comision,
        divisaComision    :  agendadb.divisaComision,
        paxAdultos        :  agendadb.paxAdultos,
        paxJunior         :  agendadb.paxJunior,
        paxNinos          :  agendadb.paxNinos,
        paxCunas          :  agendadb.paxCunas,
        pax3raEdad        :  agendadb.pax3raEdad,
        nombreAgente      :  agendadb.nombreAgente,
        correoAgencia     :  agendadb.correoAgencia,
        numReserva        :  agendadb.numReserva,
        numHabitacion     :  agendadb.numHabitacion,
        bookingReference  :  agendadb.bookingReference,
        promocion         :  agendadb.promocion,
        deposito          :  agendadb.deposito,
        divisaDeposito    :  agendadb.divisaDeposito,
        fechaConfirmada   :  agendadb.fechaConfirmada,
        fechaPago         :  agendadb.fechaPago,
        fechaLlegada      :  agendadb.fechaLlegada,
        fechaSelloAuditoria : agendadb.fechaSelloAuditoria  
      });

      // llenar los combos
      // this.GetHoras();
      // this.GetCeremonias();
      // this.GetCenas();
      // this.GetTiposCeremonia();
      // this.GetBackups();
      // this.GetPaquetes();
      // this.GetAgencias();
      // this.GetDivisas();
      this.initSelect();

      this.formG.touched;
      this.formG.markAsTouched();


    }



  }
);// realizar el patch



}


// ***************************************************************************************
//    CONFIRMAR
// ***************************************************************************************
ConfirmarAgenda()
{
  
  this._servicioAgenda.PutCambiarEstatus(this.agendaIdSelected,2).subscribe(
    (resp:any)=> {

      if(resp.ok == true)
      {
        // obtener los cambios
        var moment = $('#calendar').fullCalendar('getDate');
        this.CargarFechas(moment._i[0], moment._i[1]+1);
      }
    }    
  );

}


// ***************************************************************************************
//  CANCELAR 
// ***************************************************************************************
CancelarAgenda()
{
  var r = confirm('¿Estas seguro de cancelar la fecha?');

  if(r)
  {
        this._servicioAgenda.PutCambiarEstatus(this.agendaIdSelected,3).subscribe(
          (resp:any)=> {
          
            if(resp.ok == true)
            {

              M.toast({html: '<strong>Se canceló la fecha, correctamente!</strong>', classes:'rounded  pink darken-3'});

              this.tipoAgendaSelected = 3;
              // obtener los cambios
              var moment = $('#calendar').fullCalendar('getDate');
              this.CargarFechas(moment._i[0], moment._i[1]+1);
            }
          
          }    
  );

  }
}


}
