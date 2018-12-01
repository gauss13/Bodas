using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Paquetes;
namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {

        public IRepositorioWrapper Repositorio { get; }

        public PaqueteController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }



        // ->> ACTIONS

        [HttpGet("{h:int}/{id:int}")]
        public async Task<IActionResult> GetById(int h, int id)
        {
            var item = await this.Repositorio.Paquetes.GetByIdAsync(id);

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
                paquete = item
            });
        }

        [HttpGet("{h:int}")]
        public async Task<IActionResult> GetAll(int h)
        {
            var lista = await this.Repositorio.Paquetes.FindAsyc(x => x.HotelId == h);
            
            // BAD REQUEST
            if (!lista.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = "No se encontrarón Registros",
                    errors = ""
                };
                return Ok(objB);
            }

            // OK
            var obj = new
            {
                ok = true,
                total = lista.Count(),
                paquete = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Paquete item)
        {
            try
            {
                item.Divisa = item.Divisa.ToUpper();
                var r = await this.Repositorio.Paquetes.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    Paquete = r
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
        public async Task<IActionResult> Actualizar([FromBody] Paquete itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;

                itemNuevo.Divisa = itemNuevo.Divisa.ToUpper();

                var itemEncontrado = await this.Repositorio.Paquetes.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.Paquetes.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    Paquete = itemEncontrado
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

        //      [Route("/login/google")]
        //        [HttpGet("[action]")]
        //[HttpGet("fechas/{h:int}/{a:int}/{m:int}")]
        [HttpPut("total/{id}")]  
        public async Task<IActionResult> ActualizarTotal(int id)
        {
            try
            {
                //busca los servicios del paquete
                var listaservicios = await this.Repositorio.PaquetesServicios.FindAsyc(x => x.PaqueteId == id);

                //busca el paquete
                var itemEncontrado = await this.Repositorio.Paquetes.GetByIdAsync(id);

                //valida a lista y el item

                if(!listaservicios.Any() && itemEncontrado == null)
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = "Se pudo actualizar el total del paquete."

                    });
                }


                //obtenemos el total de los servicios
                var totalservicios = listaservicios.Sum(x => x.Total);

                itemEncontrado.Total = totalservicios;

                var r = this.Repositorio.Paquetes.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                //nav set null
                itemEncontrado.PaqueteServicios = null;


                var obj = new
                {
                    ok = true,
                    paquete = itemEncontrado
                };

                return Ok(obj);

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
            var itemEncontrado = await this.Repositorio.Paquetes.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            // no se borra fisicamente el registro, solo se cambia de estatus
            itemEncontrado.Activo = false;
            var r = this.Repositorio.Paquetes.Update(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se Desactivo el registro {id}, correctamente",
                Paquete = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS
    }
}