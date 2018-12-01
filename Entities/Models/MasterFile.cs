using Entities.Models.Catalogos;
using Entities.Models.Paquetes;
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
        [StringLength(150)]
        public string  Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalIncluido { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAdicional { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalMaster { get; set; } //suma de los totales Inciudos + Adicionales
        public string Divisa { get; set; }//divisa principal, cada item tiene su propia divisa, inicialmente no la mostraremos, tomaremos esta la principal
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
        public bool TieneImagen { get; set; } // para mostrar o no en el documento final
        //public int DivisaId { get; set; } // no se mostrará de manera inicial o version 1, sino que todos los servicios tendran la divisa del master
        public bool Incluido { get; set; } // productos adicionales 
        public bool OcRequerido { get; set; } //requiere orden de compra ?
        public bool OcRealizado { get; set; } //requiere orden de compra ?
        //NOTAS
        [StringLength(150)]
        public string Nota { get; set; }
        [StringLength(150)]
        public string Nota2 { get; set; }
        [StringLength(150)]
        public string Nota3 { get; set; }

        // NAV
        public Servicio Servicio { get; set; }
        //public Divisa Divisa { get; set; }


    }

 

}
