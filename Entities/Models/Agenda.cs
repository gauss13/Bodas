using Entities.Models.Catalogos;
using Entities.Models.Paquetes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class EstadoAgenda
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [StringLength(3)]
        public string Acronimo { get; set; }
    }

  public  class Agenda
    {
        public int Id { get; set; }
        public int EstadoAgendaId { get; set; }
        public int EjecutivoId { get; set; } // de la tabla de usuarios

        [Column(TypeName = "Date")]
        public DateTime? FechaConfirmada { get; set; } //Fecha de venta

        public int CordinadorId { get; set; } // de la tabla de usuarios

        [Column(TypeName = "Date")]     
        public DateTime? FechaBoda { get; set; }

        [StringLength(20)]
        public string HoraBoda { get; set; }
        public int LugarCeremoniaId { get; set; }
        public int LugarCenaId { get; set; }
        public int BackUpId { get; set; }
        public int TipoCeremoniaId { get; set; }
        public int Pax3raEdad { get; set; } // R= AD Adultos, SE Señor (3era edad se usa mayormente en España), JR Junior (Adolescentes), NI Niños, CU Cunas (bebés).
        public int PaxAdultos { get; set; }
        public int PaxJunior { get; set; }
        public int PaxNinos { get; set; }
        public int PaxCunas { get; set; }
        public int PaqueteId { get; set; }
        [StringLength(50)]
        public string NombrePareja { get; set; }
        [StringLength(50)]
        public string CorreoPareja { get; set; }
        [StringLength(2)]
        public string Nacionalidad { get; set; }
        [StringLength(50)]
        public string NombreAgente { get; set; }
        public int AgenciaId { get; set; }
        [StringLength(50)]
        public string CorreoAgencia { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Deposito { get; set; }  // es anticipo?
        public int DivisaDeposito { get; set; } //tipo de monenda del deposito
        public int NumHabitacion { get; set; } // num de habitacion y numero de reserva
        [StringLength(50)]
        public string BookingReference { get; set; } // pedido por martina -
        [StringLength(25)]
        public string NumReserva { get; set; }
        [StringLength(20)]
        public string Promocion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Comision { get; set; }
        public int DivisaComision { get; set; }// tipo de moneda de la comision
        [Column(TypeName = "Date")]
        public DateTime FechaSelloAuditoria { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FechaPago { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FechaLlegada { get; set; }

        public int HotelId { get; set; }

        public bool Activo { get; set; }

        // Usuario
        public int UsuarioId { get; set; }
        public DateTime FechaReg { get; set; }
        public int? UsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }

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

    public class AgendaFechas
    {
        public int idagenda { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }       
        public int estatus { get; set; }
        public string url { get; set; }
    }
}
