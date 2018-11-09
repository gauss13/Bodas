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
    public class DepartamentoServicioController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public DepartamentoServicioController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lista = await this.Repositorio.DepartamentosServicio.FindAsyc(x => x.ServicioId == id);


            if (!lista.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = $"No se encontró el registro con id {id}",
                    errors = ""
                };

                return Ok(objB);
            }

            return Ok(new
            {
                ok = true,
                dservicio = lista
            });
        }

        // http://localhost:50271/api/DepartamentoServicio/reg/2?h=1&h=2
        [HttpGet("reg/{id}")]
        public IActionResult CrearRegistro(int id, [FromQuery] int[] h)
        {
            return Ok(new {
                ok=true,
                mensaje = ""
            });
        }

        //http://localhost:50271/api/DepartamentoServicio/2
        //[
        //{ServicioId:1, DepartamentoId:2},
        //{ServicioId:1, DepartamentoId:3}
        //]
        //public IActionResult CrearRegistros(int id, [FromBody] DepartamentoServicio[] lista)
        //public IActionResult CrearRegistros(int id, [FromBody] int[] lista)
        [HttpPost("{id}")]
        public async Task<IActionResult> CrearRegistros(int id, [FromBody] DepartamentoServicio[] lista)
        {
            try
            {
                var r = await this.Repositorio.DepartamentosServicio.AddRangeAsync(lista);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    dservicio = r
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




    }
}