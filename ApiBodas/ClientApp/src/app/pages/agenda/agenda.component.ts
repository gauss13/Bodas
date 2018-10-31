import { Component, OnInit } from '@angular/core';
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

  constructor() { }

  ngOnInit() {

    $(document).ready(function(){

      $('.modal').modal();  

      // var calendar = $('#calendar').fullCalendar('getCalendar');

    }); // <- ready

  }

  IniciarCal()
  {
    $('#calendar').fullCalendar('destroy');

   
    
    $('#calendar').fullCalendar( {
      // put your options and callbacks here
      locale: 'es',
      defaultView: 'month',
      weekends: false,
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


  DestroyCal()
  {
    $('#calendar').fullCalendar('destroy');
  }

}
