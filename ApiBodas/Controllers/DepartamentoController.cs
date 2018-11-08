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
    public class DepartamentoController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public DepartamentoController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }



        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.Departamentos.GetByIdAsync(id);

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
            //var lista = await this.Repositorio.Departamentos.GetAllAsyc();

            var lista = await this.Repositorio.Departamentos.FindAsyc(x => x.HotelId == h);

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
                departamento = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Departamento item)
        {
            try
            {

                var r = await this.Repositorio.Departamentos.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    departamento = r
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
        public async Task<IActionResult> Actualizar([FromBody] Departamento itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;


                var itemEncontrado = await this.Repositorio.Departamentos.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.Departamentos.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    departamento = itemEncontrado
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
        //    var itemEncontrado = await this.Repositorio.DepartamentosServicios.GetByIdAsync(id);

        //    if (itemEncontrado == null)
        //    {
        //        return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
        //    }


        //    var r = this.Repositorio.DepartamentosServicios.Update(itemEncontrado);
        //    await this.Repositorio.CompleteAsync();

        //    var obj = new
        //    {
        //        ok = true,
        //        mensaje = $"Se Desactivo el registro {id}, correctamente",
        //        Departamentoservicio = itemEncontrado
        //    };

        //    return Ok(obj);

        //}


        // <<- ACTIONS



    }
}