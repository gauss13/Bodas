using Entities.Models;
using Entities.Models.Catalogos;
using Entities.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models.Extras;
using Entities.Models.Masterfiles;
using Entities.Models.Paquetes;

namespace Entities.Extenciones
{
    public static class EntityExtension
    {
        //Agenda

        public static void Map(this Agenda itemDb, Agenda item)
        {
            itemDb.PaxCunas = item.PaxCunas;
            itemDb.EjecutivoId = item.EjecutivoId;
            itemDb.FechaConfirmada = item.FechaConfirmada;
            itemDb.CordinadorId = item.CordinadorId;
            itemDb.FechaBoda = item.FechaBoda;
            itemDb.HoraBoda = item.HoraBoda;
            itemDb.LugarCeremoniaId = item.LugarCeremoniaId;
            itemDb.LugarCenaId = item.LugarCenaId;
            itemDb.BackUpId = item.BackUpId;
            itemDb.TipoCeremoniaId = item.TipoCeremoniaId;
            itemDb.PaxAdultos = item.PaxAdultos;
            itemDb.PaxNinos = item.PaxNinos;
            itemDb.PaxJunior = item.PaxJunior;
            itemDb.PaqueteId = item.PaqueteId;
            itemDb.NombrePareja = item.NombrePareja;
            itemDb.CorreoPareja = item.CorreoPareja;
            itemDb.Nacionalidad = item.Nacionalidad;
            itemDb.NombreAgente = item.NombreAgente;
            itemDb.AgenciaId = item.AgenciaId;
            itemDb.CorreoAgencia = item.CorreoAgencia;
            itemDb.Deposito = item.Deposito;
            itemDb.NumReserva = item.NumReserva;
            itemDb.Promocion = item.Promocion;
            itemDb.Comision = item.Comision;
            itemDb.FechaSelloAuditoria = item.FechaSelloAuditoria;
            itemDb.FechaPago = item.FechaPago;
            itemDb.FechaLlegada = item.FechaLlegada;
            itemDb.HotelId = item.HotelId;
            itemDb.UsuarioId = item.UsuarioId;
            itemDb.FechaReg = item.FechaReg;
            itemDb.UsuarioMod = item.UsuarioMod;
            itemDb.FechaMod = item.FechaMod;
            itemDb.EstadoAgendaId = item.EstadoAgendaId;
            itemDb.Pax3raEdad = item.Pax3raEdad;

        }


        // CATALOGOS

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

        //MASTER FILE

        public static void Map(this MasterFile itemDb, MasterFile item)
        {
            itemDb.Hotel = item.Hotel;
            itemDb.Descripcion = item.Descripcion;

        }

        public static void Map(this MasterFileContent itemDb, MasterFileContent item)
        {
            itemDb.PrecioUnitario = item.PrecioUnitario;
            itemDb.Cantidad = item.Cantidad;
            itemDb.Total = item.Total;
            itemDb.Img = item.Img;
            itemDb.DivisaId = item.DivisaId;
        }

        //PAQUETES
        public static void Map(this Categoria itemDb, Categoria item)
        {
            itemDb.Descripcion = item.Descripcion;
        }

        public static void Map(this PaqueteServicio itemDb, PaqueteServicio item)
        {
            itemDb.PaqueteId = item.PaqueteId;
            itemDb.ServicioId= item.ServicioId;
        }

        public static void Map(this Servicio itemDb, Servicio item)
        {
            itemDb.Descripcion = item.Descripcion;
            itemDb.PrecioSugerido = item.PrecioSugerido;
            itemDb.Nota = item.Nota;
            itemDb.Img = item.Img;
            itemDb.CategoriaId = item.CategoriaId;
            itemDb.DivisaId = item.DivisaId;
        }

        public static void Map(this Paquete itemDb, Paquete item)
        {
            itemDb.Descripcion = item.Descripcion;
            itemDb.Clave = item.Clave ;
            itemDb.Activo = item.Activo;
    
        }




            //public static void Map(this Ejecutivo itemDb, Ejecutivo itemNuevo)
            //{
            //    itemDb.Nombre = itemNuevo.Nombre;
            //    itemDb.Iniciales = itemNuevo.Iniciales;
            //}
        }
}
