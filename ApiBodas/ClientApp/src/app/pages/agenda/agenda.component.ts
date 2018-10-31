import { Component, OnInit } from '@angular/core';
//import * as $ from 'jquery';
declare var $: any;

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

      // var calendar = $('#calendar').fullCalendar('getCalendar');

    }); // <- ready

  }

  IniciarCal()
  {
    M.toast({html: 'I am a toast!'});
    
    $('#calendar').fullCalendar( {
      // put your options and callbacks here
      locale: 'es',
      weekends: false,
      dayClick: function() {
        alert('a day has been clicked!');
      },
    //  hiddenDays: [ 2, 4 ]
    events: [
      {
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
  }


  DestroyCal()
  {
    $('#calendar').fullCalendar('destroy');
  }

}
