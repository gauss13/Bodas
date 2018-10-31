import { Component, OnInit } from '@angular/core';
import { AgendaService } from 'src/app/services/service.index';
//import * as $ from 'jquery';
declare var $: any;
declare var M: any;
//import 'fullcalendar';


@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styles: [],
})
export class AgendaComponent implements OnInit {

  arrEventos = [];

  constructor(public _servicioAgenda: AgendaService) { }

  ngOnInit() {

    
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
        $('#modalt').modal('open');
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
  this.CargarFechas(moment._i[0], moment._i[1]-1);
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







}
