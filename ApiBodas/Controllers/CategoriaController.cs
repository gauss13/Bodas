using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;
using Entities.Models.Paquetes;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public CategoriaController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.Categorias.GetByIdAsync(id);

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

        [HttpGet("{h:int}")]
        public async Task<IActionResult> GetAll(int h)
        {
            //var lista = await this.Repositorio.Categorias.GetAllAsyc();

            var lista = await this.Repositorio.Categorias.FindAsyc(x => x.HotelId == h);

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
                categoria = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Categoria item)
        {
            try
            {

                var r = await this.Repositorio.Categorias.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    categoria = r
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
        public async Task<IActionResult> Actualizar([FromBody] Categoria itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;


                var itemEncontrado = await this.Repositorio.Categorias.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.Categorias.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    categoria = itemEncontrado
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

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Eliminar(int id)
        //{
        //    //buscar la Role 
        //    var itemEncontrado = await this.Repositorio.CategoriasServicios.GetByIdAsync(id);

        //    if (itemEncontrado == null)
        //    {
        //        return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
        //    }

          
        //    var r = this.Repositorio.CategoriasServicios.Update(itemEncontrado);
        //    await this.Repositorio.CompleteAsync();

        //    var obj = new
        //    {
        //        ok = true,
        //        mensaje = $"Se Desactivo el registro {id}, correctamente",
        //        CategoriaServicio = itemEncontrado
        //    };

        //    return Ok(obj);

        //}


        // <<- ACTIONS

    }
}