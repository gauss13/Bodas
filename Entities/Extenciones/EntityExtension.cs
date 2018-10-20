using Entities.Models;
using Entities.Models.Catalogos;
using Entities.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extenciones
{
  public static class EntityExtension
    {

        public static void Map(this Usuario itemDb, Usuario itemNuevo)
        {
            itemDb.UserName = itemNuevo.UserName;
            itemDb.RoleId = itemNuevo.RoleId;
            itemDb.Nombre = itemNuevo.Nombre;
            itemDb.Correo = itemNuevo.Correo;     
            itemDb.Img = itemNuevo.Img;
            
        }

        //public static void Map(this Ejecutivo itemDb, Ejecutivo itemNuevo)
        //{
        //    itemDb.Nombre = itemNuevo.Nombre;
        //    itemDb.Iniciales = itemNuevo.Iniciales;
        //}
    }
}
