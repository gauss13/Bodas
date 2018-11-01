export class Agenda {
    
    constructor(
    public id:number,
    public ejecutivoId: number,
    public cordinadorId:number ,

    public lugarCeremoniaId: number,
    public lugarCenaId:number ,
    public backUpId: number,
    public paxAdultos:number ,
    public paxNinos: number,
    public paxJunior:number ,
    public paxCunas:number ,
    public paqueteId: number,
    public agenciaId: number,
   

    public comision: number,
    public fechaSelloAuditoria:Date ,

    public hotelId: number,

    public fechaReg: Date,
    public usuarioMod: number,


    public tipoCeremoniaId: number,
    public estadoAgendaId: number,
    public pax3raEdad: number,
    public activo: boolean,

    public divisaComision: number,
    public divisaDeposito: number,
    public numHabitacion: number,

    public fechaConfirmada?:Date,
    public fechaBoda?: Date,
    public horaBoda?: string,

    public nombrePareja?:string,
    public correoPareja?:string,
    public nacionalidad?:string,
    public nombreAgente?:string,
  
    public correoAgencia?:string ,
    public deposito?: number,
    public numReserva?:string ,
    public promocion?: string,
 
    public fechaPago?: Date,
    public fechaLlegada?:Date ,
    
    public usuarioId?: number,

    public fechaMod?: Date,
  
    public bookingReference?:string 


    )
{}

}