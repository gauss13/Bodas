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



    }
}