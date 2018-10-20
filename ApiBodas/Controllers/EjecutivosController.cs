using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Catalogos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Microsoft.AspNetCore.Authorization;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecutivosController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        //Constructor
        public EjecutivosController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> GetAll()
        {
            var lista = await this.Repositorio.Ejecutivos.GetAllAsyc();

            if(!lista.Any())
            {
                return BadRequest(new {
                    ok=false,
                    mensaje ="No se encontró ejecutivos",
                    errors = ""
                });
            }

            var obj = new
            {
                ok = true,
                total = lista.Count(),
                Ejecutivos = lista
            };
            return Ok(obj);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.Ejecutivos.GetByIdAsync(id);

            if (item == null)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "No se encontró el ejecutivo con id " + id,
                    errors = ""
                });
            }

            var obj = new
            {
                ok = true,            
                Ejecutivo = item
            };
            return Ok(obj);

        }

        [HttpPost]
        [Authorize]
        public IActionResult Crear(Ejecutivo item)
        {
            var r = this.Repositorio.Ejecutivos.Add(item);
            this.Repositorio.Complete();
            
            var obj = new
            {
                ok = true,
                Ejecutivo = r
            };

            return Created("", obj);
                       
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Actualizar( Ejecutivo itemA, int id)
        {
            itemA.Id = id;

            //buscar el ejecutivo
            var itemEncontrado =  await this.Repositorio.Ejecutivos.GetByIdAsync(id);
        
            if(itemEncontrado == null)
            {
                return BadRequest(new {
                    ok= false,
                    mensaje = $"no se econtró el ejecutivo con id: {id}"
                });
            }
            
            itemEncontrado.Map(itemA);

            var r = this.Repositorio.Ejecutivos.Update(itemEncontrado);

            this.Repositorio.Complete();

            var obj = new
            {
                ok = true,
                mensaje = $"Se actualizo los datos del ejecutivo {id}",
                Ejecutivo = r
            };

            return Created("", obj);

        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Borrar(int id)
        {
            var itemEncontrado = await this.Repositorio.Ejecutivos.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"no se econtró el ejecutivo con id: {id}"
                });
            }

            this.Repositorio.Ejecutivos.Remove(itemEncontrado);
            this.Repositorio.Complete();


            var obj = new
            {
                ok = true,
                Ejecutivo = itemEncontrado
            };


            return Ok(obj);
        }

    }
}