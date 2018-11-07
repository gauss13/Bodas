using Entities.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models.Masterfiles
{
   public class MasterFile
    {
        public int Id { get; set; }
        public string Hotel { get; set; }
        public int AgendaId { get; set; }
        public bool Activo { get; set; }
        public string  Descripcion { get; set; }

    }

    public class MasterFileContent
    {
        public int Id { get; set; }
        public int MasterFileId { get; set; }
        public int ServicioId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        [StringLength(150)]
        public string Img { get; set; } // img podra ser una imagen por servicio
        public int DivisaId { get; set; }
        public bool Adicional { get; set; } // productos adicionales 
        public bool OcRequerido { get; set; } //requiere orden de compra ?
        public bool OcRealizado { get; set; } //requiere orden de compra ?

    }

 

}
