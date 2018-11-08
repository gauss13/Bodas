
export class Servicio {

    constructor(
     public  id:number,
    public descripcion:string,
    public precioSugerido:number,
    public nota:string,
    public divisaId:number,
    public activo:boolean,
    public categoriaId:number,
    public strCategoria:string,
    public strDivisa:string,
    public hotelId:number,
    public departamento:string
          
        )
        {}
    
    }