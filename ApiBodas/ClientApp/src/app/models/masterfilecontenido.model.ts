export class MasterFileContenido {

    constructor(
        public id:number =0,
        public masterFileId:number =0,
        public servicioId:number =0,
        public precioUnitario:number =0,
        public cantidad:number =0,
        public total:number =0,
        public img:string,
        public divisa:string,
        public tieneImagen:boolean,
        public ocRealizado:boolean,
        public ocRequerido:boolean,
        public incluido:boolean,
        public nota:string,
        public nota2:string,
        public nota3:string,

    ){ }
}