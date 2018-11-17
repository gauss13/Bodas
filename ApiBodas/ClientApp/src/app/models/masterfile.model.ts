export class MasterFile {

    constructor(
        public id:number = 0,
        public hotel:string,
        public agendaId:number,
        public activo:boolean,
        public descripcion:string,
        public totalIncuido:number = 0,
        public totalAdicional:number = 0,
        public totalMaster:number = 0,
        public divisaId:number,

    ){}
    
    }