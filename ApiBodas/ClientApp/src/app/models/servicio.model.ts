
export class Servicio {

    constructor(
     public  id:number,
    public descripcion:string,
    public precioSugerido:number,
    public nota:string,
    public divisaId:number,
    public activo:boolean,
    public categoriaId:number,
    public hotelId:number
          
        )
        {}
    
    }