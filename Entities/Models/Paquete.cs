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
        public int HotelId { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public List<PaqueteServicio> PaqueteServicios { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        [StringLength(3)]
        public string Divisa { get; set; }
        [StringLength(350)]
        public string Nota { get; set; }
    }

    

    public class Servicio
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioSugerido { get; set; }
        [StringLength(150)]
        public string Nota { get; set; }
        [StringLength(250)]
        public string Img { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }
        public Categoria Categoria { get; set; }//nav
        [StringLength(3)]
        public string Divisa { get; set; }
        //public Divisa Divisa { get; set; }
      //  public string Departamentos { get; set; } // un servicio puede estar ligado a uno o varios departamentos

    }

    // VISTA
    public class ServiciConSelected
    {
        public int ServicioId { get; set; }

        public int PaqueteId { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        public string Categoria { get; set; }

        public int CategoriaId { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Total { get; set; }

        public bool Selected { get; set; }
        public bool ChangeValue { get; set; }

    }


    // un servicio puede estar ligado a uno o varios departamentos
    public class DepartamentoServicio
    {
        public int ServicioId { get; set; }
        public int DepartamentoId { get; set; }
    }

    public class Departamento
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Nombre { get; set; }


    }



    public class PaqueteServicio
    {
        public int PaqueteId { get; set; }
        public int ServicioId { get; set; }
        public Paquete Paquete { get; set; }
        public Servicio Servicio { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
    }

    

    public class Categoria
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
    }

}
