using Entities.Models.Catalogos;
using Entities.Models.Paquetes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public  class Agenda
    {
        public int Id { get; set; }
        public int EstadoAgenda { get; set; }
        public int EjecutivoId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FechaConfirmada { get; set; } //Fecha de venta

        public int CordinadorId { get; set; }

        [Column(TypeName = "Date")]     
        public DateTime FechaBoda { get; set; }

        [StringLength(20)]
        public string HoraBoda { get; set; }
        public int LugarCeremoniaId { get; set; }
        public int LugarCenaId { get; set; }
        public int BackUpId { get; set; }
        public int TipoCereminiaId { get; set; }
        public int PaxAdultos { get; set; }
        public int PaxMenores { get; set; }
        public int PaxBebes { get; set; }
        public int PaqueteId { get; set; }
        [StringLength(50)]
        public string NombrePareja { get; set; }
        [StringLength(50)]
        public string CorreoPareja { get; set; }
        [StringLength(3)]
        public string Nacionalidad { get; set; }
        [StringLength(50)]
        public string NombreAgente { get; set; }
        public int AgenciaId { get; set; }
        [StringLength(50)]
        public string CorreoAgencia { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Deposito { get; set; } // es anticipo?
        [StringLength(25)]
        public string NumReserva { get; set; }
        [StringLength(20)]
        public string Promocion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Comision { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaSelloAuditoria { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaPago { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaLlegada { get; set; }

        public int HotelId { get; set; }

        // Usuario
        public int UsuarioId { get; set; }
        public DateTime FechaReg { get; set; }
        public int UsuarioMod { get; set; }
        public DateTime FechaMod { get; set; }

        //Propiedad Nav
        public Hotel Hotel { get; set; }
        //public Ejecutivo Ejecutivo { get; set; }
        //public Coordinador Coordinador { get; set; }
        public LugarCeremonia LugarCeremonia { get; set; }
        public LugarCena LugarCena { get; set; }
        public BackUp BackUp { get; set; }
        public TipoCeremonia TipoCeremonia { get; set; }
        public Paquete Paquete { get; set; }
        public Agencia Agencia { get; set; }
        

        //[NotMapped]

    }
}
