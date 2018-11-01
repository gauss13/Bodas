using System;
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
    public class HorasController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public HorasController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.Horas.GetByIdAsync(id);

            if (item == null)
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
                Hora = item
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var lista = await this.Repositorio.LugaresCena.GetAllAsyc();
            var lista = await this.Repositorio.Horas.GetAllAsyc();

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
                Horas = lista
            };

            return Ok(obj);
        }


    }
}