using Entities.Models;
using Entities.Models.Catalogos;
using Entities.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models.Extras;

namespace Entities.Extenciones
{
    public static class EntityExtension
    {

        public static void Map(this LugarCena itemDb, LugarCena item)
        {
            itemDb.Lugar = item.Lugar;
            itemDb.HotelId = item.HotelId;
            itemDb.Activo = item.Activo;
        }
        
        public static void Map(this LugarCeremonia itemDb, LugarCeremonia item)
        {
            itemDb.Lugar = item.Lugar;
            itemDb.HotelId = item.HotelId;
            itemDb.Activo = item.Activo;
        }
        
        public static void Map(this BackUp itemDb, BackUp item)
        {
            itemDb.Lugar = item.Lugar;
            itemDb.HotelId = item.HotelId;
            itemDb.Activo = item.Activo;
        }

        public static void Map(this Agencia itemDb, Agencia itemNuevo)
        {
      
            itemDb.Nombre = itemNuevo.Nombre;
            itemDb.Correo = itemNuevo.Correo;
            itemDb.Activo = itemNuevo.Activo;

        }

        public static void Map(this Usuario itemDb, Usuario itemNuevo)
        {
            itemDb.UserName = itemNuevo.UserName;
            itemDb.RoleId = itemNuevo.RoleId;
            itemDb.Nombre = itemNuevo.Nombre;
            itemDb.Correo = itemNuevo.Correo;     
            itemDb.Img = itemNuevo.Img;
            
        }

        public static void Map(this TipoCeremonia itemDb, TipoCeremonia item)
        {
            itemDb.Descripcion = item.Descripcion;     
            itemDb.Activo = item.Activo;
        }

        //EXTRAS
        public static void Map(this DiasBloqueados itemDb, DiasBloqueados item)
        {
            itemDb.Fecha = item.Fecha;
            itemDb.Parcial = item.Parcial;
            itemDb.HoraInicio = item.HoraInicio;
            itemDb.HoraFinal = item.HoraFinal;
            itemDb.Locacion = item.Locacion;
            itemDb.HotelId = item.HotelId;
            itemDb.Activo = item.Activo;
        }

        public static void Map(this Comentario itemDb, Comentario item)
        {
            itemDb.Comentarios = item.Comentarios;
        }

        //public static void Map(this Ejecutivo itemDb, Ejecutivo itemNuevo)
        //{
        //    itemDb.Nombre = itemNuevo.Nombre;
        //    itemDb.Iniciales = itemNuevo.Iniciales;
        //}
    }
}
