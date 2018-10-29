﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarCenaController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public LugarCenaController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.LugaresCena.GetByIdAsync(id);

            if (item == null)
            {
                var objB = new
                {
                    ok = false,
                    mensaje = $"No se encontró el registro con id {id}",
                    errors = ""
                };

                return BadRequest(objB);
            }

            return Ok(new
            {
                ok = true,
                Role = item
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var lista = await this.Repositorio.LugaresCena.GetAllAsyc();
            var lista = await this.Repositorio.LugaresCena.GetLugarCenaConHotelAsync();

            // BAD REQUEST
            if (!lista.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = "No se encontrarón Registros",
                    errors = ""
                };
                return BadRequest(objB);
            }

            // OK
            var obj = new
            {
                ok = true,
                total = lista.Count(),
                LugarCena = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] LugarCena item)
        {
            try
            {

                var r = await this.Repositorio.LugaresCena.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var db = await this.Repositorio.LugaresCena.GetLugarCenaConHotelByIdAsync(r.Id);

                db.Hotel.LugaresCena = null;
                db.Hotel.LugaresCeremonia = null;
                db.Hotel.Agendas = null;
                db.Hotel.BackUps = null;
                db.Hotel.UsuariosHotel = null;

                var obj = new
                {
                    ok = true,
                    LugarCena = db
                };

                return Ok( obj);

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al crear el registro",
                    errors = new { mensaje = ex.Message }

                });

            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar([FromBody] LugarCena itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;

                
                var itemEncontrado = await this.Repositorio.LugaresCena.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.LugaresCena.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var db = await this.Repositorio.LugaresCena.GetLugarCenaConHotelByIdAsync(r.Id);

                db.Hotel.LugaresCena = null;
                db.Hotel.LugaresCeremonia = null;
                db.Hotel.Agendas = null;
                db.Hotel.BackUps = null;
                db.Hotel.UsuariosHotel = null;


                var obj = new
                {
                    ok = true,
                    LugarCena = db
                };

                return Created("", obj);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al Actualizar el registro",
                    errors = new { mensaje = ex.Message }

                });

            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            //buscar la Role 
            var itemEncontrado = await this.Repositorio.LugaresCena.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            // no se borra fisicamente el registro, solo se cambia de estatus
            itemEncontrado.Activo = false;
            var r = this.Repositorio.LugaresCena.Update(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se Desactivo el registro {id}, correctamente",
                LugarCena = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS


    }
}