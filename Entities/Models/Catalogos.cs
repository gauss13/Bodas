using Entities.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models.Catalogos
{
    public class Hotel
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(2)]
        public string Clave { get; set; }
        [StringLength(250)]
        public string Img { get; set; }
        public List<LugarCena> LugaresCena { get; set; }
        public List<LugarCeremonia> LugaresCeremonia { get; set; }
        //public List<Coordinador> Coordinadores { get; set; }
        public List<BackUp> BackUps { get; set; }
        public List<Agenda> Agendas { get; set; }
        public List<UsuarioHotel> UsuariosHotel { get; set; } // nav
    }

   //public class Ejecutivo
   // {
   //     public int Id { get; set; }
   //     [StringLength(50)]
   //     public string Nombre { get; set; }
   //     [StringLength(10)]
   //     public string Iniciales { get; set; }
   // }

    //public class Coordinador
    //{
    //    public int Id { get; set; }
    //    [StringLength(50)]
    //    public string Nombre { get; set; }
    //    public int HotelId { get; set; }
    //    public Hotel Hotel { get; set; }

    //}

    public class LugarCena
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Lugar { get; set; }
        public int HotelId { get; set; }
        public bool Activo { get; set; }
        public Hotel Hotel { get; set; }
        public List<Agenda> Agendas { get; set; }
    }

    public class LugarCeremonia
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Lugar { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Agenda> Agendas { get; set; }
    }

    // [DataType(DataType.Date)]

    //[DataType(DataType.Date)]
    //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public class BackUp
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Lugar { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Agenda> Agendas { get; set; }
    }

    public class Horas
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Hora { get; set; }
        public int Tipo { get; set; }// 1 mañana, 2 tarde, 3 atardecer
    }


    public class TipoCeremonia
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }


    public class Agencia
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
    }

    public class Divisa
    {
        public int Id { get; set; }
        [StringLength(5)]
        public string Clave { get; set; }
    }

}
