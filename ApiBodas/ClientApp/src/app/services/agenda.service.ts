import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { URL_SERVICIOS } from '../config/config';
import { map } from 'rxjs/operators'; // version 6 en adelante
import { Agenda } from '../models/agenda.model';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  totalRegistros: number = 0;


  constructor(public http: HttpClient, public router: Router) { }

// ***************************************************************************************
//  GET Fechas por Mes 
// ***************************************************************************************
GetFechasPorMes(an:number, mes:number)
{
  const url = URL_SERVICIOS + '/api/agenda/fechas/'+an+'/'+mes;

  return this.http.get(url).pipe(
    map((resp:any) => {
     
      if(resp.ok == true)
      this.totalRegistros = resp.total;
   
      return resp;
    
    })
    
    );
}

// ***************************************************************************************
//   POST
// ***************************************************************************************
CrearAgenda(item: Agenda)
{
  const url= URL_SERVICIOS + "/api/Agenda";

  const headersj = new HttpHeaders({'Content-Type':'application/json'});

//var nuevo =  this.Sanity(item);

//var objj= JSON.stringify(nuevo);

  return this.http.post(url,item,{headers: headersj}).pipe(

    map( (resp:any) => {

      return resp.agenda;
    })
  );

}


StringOrEmpty(value:string)
{
  return !(typeof value === "string" && value.length > 0);
}

Sanity(item:Agenda)
{


 let id = 0;
 let ejecutivoId  = 0;//provisional
 let cordinadorId  = 0; //provisional
 
 let lugarCeremoniaId  = !isNaN(item.lugarCeremoniaId) ? +0 :  +item.lugarCeremoniaId;

 let lugarCenaId = !isNaN(item.lugarCenaId) ? 0 :  +item.lugarCenaId ;
 let backUpId  =  !isNaN(item.backUpId  ) ? 0 : +item.backUpId   ; 
 let paxAdultos = !isNaN(item.paxAdultos ) ? 0 : item.paxAdultos   ; 
 let paxNinos  =  !isNaN(item.paxNinos ) ? 0 : item.paxNinos   ; 
 let paxJunior  = !isNaN(item.paxJunior ) ? 0 : item.paxJunior   ;  
 let paxCunas  =  !isNaN(item.paxCunas ) ? 0 : item.paxCunas   ; 
 let paqueteId  = !isNaN(item.paqueteId ) ? 0 :  item.paqueteId  ; 
 let agenciaId  = !isNaN(item.agenciaId ) ? 0 :item.agenciaId    ; 
 let comision  =  !isNaN(item.comision) ? 0 : item.comision  ;   


 let fechaSelloAuditoria  = item.fechaSelloAuditoria

 let hotelId  = 0; //item.hotelId  provisional
 let fechaReg  = new Date();// "2018/05/11";// item.fechaReg // se modifica en el back
 let usuarioMod  =  0;// item.usuarioMod  provisional

 let tipoCeremoniaId  =  !isNaN(item.tipoCeremoniaId ) ? 0 :  item.tipoCeremoniaId  ; 
 let estadoAgendaId  =  !isNaN(item.estadoAgendaId ) ? 0 : item.estadoAgendaId   ; 
 let pax3raEdad  =  !isNaN(item.pax3raEdad ) ? 0 : item.pax3raEdad   ; 

 let activo  = true; //item.activo; provicional
 
 let divisaComision  = !isNaN(item.divisaComision) ? 0 :  item.divisaComision;   
 let divisaDeposito  = !isNaN(item.divisaDeposito) ? 0 :  item.divisaDeposito; 
 let numHabitacion   = !isNaN(item.numHabitacion)  ? 0 :  item.numHabitacion; 



 let fechaConfirmada = item.fechaConfirmada
 let fechaBoda  = new Date(item.fechaBoda ) ;
 let horaBoda  = item.horaBoda 
 let nombrePareja = item.nombrePareja
 let correoPareja = item.correoPareja
 let nacionalidad = item.nacionalidad
 let nombreAgente = item.nombreAgente
 let correoAgencia  = item.correoAgencia 
 let deposito  =  !isNaN( item.deposito ) ? 0 :   item.deposito  ; 
 let numReserva  = item.numReserva 
 let promocion  = item.promocion 
 let fechaPago  = item.fechaPago 
 let fechaLlegada = item.fechaLlegada 
 let usuarioId  =  !isNaN( item.usuarioId ) ? 0 :  item.usuarioId   ;
 let fechaMod  = new Date(); //item.fechaMod 
 let bookingReference = item.bookingReference; 


 let agendaSana = new Agenda (id,  ejecutivoId ,  cordinadorId ,  lugarCeremoniaId ,  lugarCenaId ,
  backUpId ,  paxAdultos,   paxNinos ,  paxJunior ,  paxCunas ,
  paqueteId ,  agenciaId ,  comision ,  fechaSelloAuditoria ,  hotelId ,
  fechaReg ,  usuarioMod,   tipoCeremoniaId ,  estadoAgendaId ,  pax3raEdad ,
  activo ,  divisaComision ,  divisaDeposito ,  numHabitacion ,  fechaConfirmada,
  fechaBoda ,   horaBoda ,   nombrePareja,  correoPareja,  nacionalidad,
  nombreAgente,  correoAgencia,   deposito ,  numReserva,   promocion ,
  fechaPago ,   fechaLlegada ,  usuarioId ,  fechaMod ,  bookingReference );

return agendaSana;
  // {
  //   PaxCunas	:1,
  //   EjecutivoId	:1,
  //   FechaConfirmada	:"10/11/2018",
  //   CordinadorId	:1,
  //   FechaBoda	:"12/11/2018",
  //   HoraBoda	:"15:35",
  //   LugarCeremoniaId	:1,
  //   LugarCenaId	:1,
  //   BackUpId	:1,
  //   TipoCeremoniaId	:1,
  //   PaxAdultos	:5,
  //   PaxNinos	:2,
  //   PaxJunior	:3,
  //   PaqueteId	:1,
  //   NombrePareja	:"Lucas",
  //   CorreoPareja	:"eselucas@test.com",
  //   Nacionalidad	:"US",
  //   NombreAgente	:"Juana",
  //   AgenciaId	:1,
  //   CorreoAgencia	:"agencia@correo.com",
  //   Deposito	: 250,
  //   NumReserva	: 452,
  //   Promocion	: "na",
  //   Comision	: 152,
  //   FechaSelloAuditoria	:"11/11/2018",
  //   FechaPago	: "11/11/2018",
  //   FechaLlegada	:"12/11/2018",
  //   HotelId	:1,
  //   UsuarioId	:7,
  //   FechaReg	: "10/10/2018",
  //   UsuarioMod	:0,
  //   FechaMod	:"09/09/2018",
  //   EstadoAgendaId	:1,
  //   Pax3raEdad	:0
    
  //   }
}



}
