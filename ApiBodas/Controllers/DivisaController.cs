using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisaController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public DivisaController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var lista = await this.Repositorio.LugaresCena.GetAllAsyc();
            var lista = await this.Repositorio.Divisas.GetAllAsyc();

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
                divisa = lista
            };

            return Ok(obj);
        }


    }
}