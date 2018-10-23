using Entities.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models.Paquetes
{
  public  class Paquete
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public List<PaqueteServicio> PaqueteServicios { get; set; }
    }

    

    public class Servicio
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioSugerido { get; set; }
        [StringLength(150)]
        public string Nota { get; set; }
        [StringLength(250)]
        public string Img { get; set; }
        public int CategoriaServicioId { get; set; }
        public bool Activo { get; set; }
        public CategoriaServicio Categoria { get; set; }
        public int DivisaId { get; set; }
        public Divisa Divisa { get; set; }
       
    }

    public class PaqueteServicio
    {
        public int PaqueteId { get; set; }
        public int ServicioId { get; set; }
        public Paquete Paquete { get; set; }
        public Servicio Servicio { get; set; }
    }


    public class CategoriaServicio
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
    }

}
