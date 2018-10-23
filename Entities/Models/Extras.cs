
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models.Extras
{
  public  class DiasBloqueados
    {
        public int Id { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public bool Parcial { get; set; }
        [StringLength(20)]
        public string HoraInicio { get; set; } //cuando sea parcial
        [StringLength(20)]
        public string HoraFinal { get; set; } // cuando sea parcial
        [StringLength(20)]
        public string Locacion { get; set; } // 1,2,3 o * todos
        public int HotelId { get; set; }
        public bool Activo { get; set; }
    }


    public class Comentario
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        [StringLength(150)]
        public string Comentarios { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaReg { get; set; }
        public bool Activo { get; set; }

    }

    public class Historial
    {
        public int Id { get; set; }
        public int  AgendaId { get; set; }
        [StringLength(50)]
        public string ValorAnterior { get; set; }
        [StringLength(50)]
        public string ValorNuevo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaReg { get; set; }
    }


}
