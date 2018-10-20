using Entities.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models.Usuarios
{
   public class Usuario
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string UserName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(20)]
        public string Apaterno { get; set; }
        [StringLength(20)]
        public string Amaterno { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }
        //[StringLength(50)]
        //public string Hoteles { get; set; }
        [StringLength(250)]
        public string Img { get; set; }
        public Role Role { get; set; }
        [StringLength(3)]
        public string Iniciales { get; set; }
        public List<UsuarioHotel> UsuariosHotel { get; set; } // nav
    }

    public  class Role
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(2)]
        public string Clave { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }

    public class UsuarioHotel
    {
        public int UsuarioId { get; set; }
        public int HotelId { get; set; }
        public bool Activo { get; set; }
        public Usuario Usuario {get; set; }
        public Hotel Hotel { get; set; }
    }

}
