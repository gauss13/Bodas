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

}
