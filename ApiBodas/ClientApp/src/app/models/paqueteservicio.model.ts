
export class PaqueteServicio {

    constructor(
     public  id:number,
     public descripcion:string,             
     public nota:string,             
     public img:string,            
     public strDivisa:string,
     public strCategoria:string,
     public divisa:string,
     public categoriaId:number,
     public hotelId:number,
     public selected:boolean
     )
     {}
    
    }