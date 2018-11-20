using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;
using Entities.Models.Masterfiles;
using Newtonsoft.Json;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterFileContentController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public MasterFileContentController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.MasterFileContent.GetByIdAsync(id);

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

        [HttpGet("contenido/{mfid:int}")]
        public async Task<IActionResult> GetContenido(int mfid)
        {
             //var lista = await this.Repositorio.MasterFileContent.FindAsyc(x=> x.MasterFileId == mfid);
            var lista = await this.Repositorio.MasterFileContent.GetContenido(mfid);

            // BAD REQUEST
            if (!lista.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = "No se encontrarón Registros contenido",
                    errors = ""
                };
                return BadRequest(objB);
            }

            //Serializar
            //string json = JsonConvert.SerializeObject(lista);

            // OK
            var obj = new
            {
                ok = true,
                total = lista.Count(),
                contenido = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MasterFileContent item)
        {
            try
            {

                var r = await this.Repositorio.MasterFileContent.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    MasterFileContent = r
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
        public async Task<IActionResult> Actualizar([FromBody] MasterFileContent itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;


                var itemEncontrado = await this.Repositorio.MasterFileContent.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.MasterFileContent.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var item = await this.Repositorio.MasterFileContent.GetContenidoById(id);

                var obj = new
                {
                    ok = true,
                    contenido = item
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
            var itemEncontrado = await this.Repositorio.MasterFileContent.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            //  se borra fisicamente el registro
           
             this.Repositorio.MasterFileContent.Remove(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se Elimino el registro {id}, correctamente",
                MasterFileContent = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS

    }
}