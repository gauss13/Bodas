using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Extenciones;
using Entities.Models.Paquetes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteServicioController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public PaqueteServicioController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.PaquetesServicios.GetByIdAsync(id);

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
            var lista = await this.Repositorio.PaquetesServicios.GetAllAsyc();

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
                PaqueteServicio = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PaqueteServicio item)
        {
            try
            {

                var r = await this.Repositorio.PaquetesServicios.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    PaqueteServicio = r
                };

                return Created("", obj);

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
        public async Task<IActionResult> Actualizar([FromBody] PaqueteServicio itemNuevo, int id)
        {

            try
            {


                var lista = await this.Repositorio.PaquetesServicios.FindAsyc(x => x.PaqueteId == itemNuevo.PaqueteId && x.ServicioId == itemNuevo.ServicioId);

                var itemEncontrado = lista.FirstOrDefault();

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.PaquetesServicios.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    PaqueteServicio = itemEncontrado
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
        public async Task<IActionResult> Eliminar([FromBody] PaqueteServicio itemBorrar)
        {
            //buscar la Role 
            var itemEncontrado = await this.Repositorio.PaquetesServicios.FindAsyc(x => x.PaqueteId == itemBorrar.PaqueteId && x.ServicioId == itemBorrar.ServicioId);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro ", erros = "" });
            }

            
           
            this.Repositorio.PaquetesServicios.RemoveRange(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se elimino el registro , correctamente",
                PaqueteServicio = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS


    }
}