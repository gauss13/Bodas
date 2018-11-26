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
                    masterFileContent = r
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

        [HttpPut("{id}/{idm:int}")]
        public async Task<IActionResult> Actualizar([FromBody] MasterFileContent itemNuevo, int id, int idm)
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

                // var item = await this.Repositorio.MasterFileContent.GetContenidoById(id);

                var master = await this.Repositorio.MasterFile.GetByIdAsync(idm);

                //obtener los nuevos totales
                var listaActual = await this.Repositorio.MasterFileContent.GetContenido(idm);

                var totalInc = listaActual.Where(x => x.Incluido == true).Sum(x => x.Total);
                var totalAdd = listaActual.Where(x => x.Incluido == false).Sum(x => x.Total);

                master.TotalAdicional = totalAdd;
                master.TotalIncluido = totalInc ;
                master.TotalMaster = totalInc + totalAdd;

                var rm = this.Repositorio.MasterFile.Update(master);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    contenido = r,
                    master = master
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

        [HttpDelete("{id}/{idm:int}")]
        public async Task<IActionResult> Eliminar(int id, int idm)
        {
            //buscar la Role 
            var itemEncontrado = await this.Repositorio.MasterFileContent.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            var master = await this.Repositorio.MasterFile.GetByIdAsync(idm);

            //  se borra fisicamente el registro
            this.Repositorio.MasterFileContent.Remove(itemEncontrado);
            await this.Repositorio.CompleteAsync();


            //obtener los nuevos totales
            var listaActual = await this.Repositorio.MasterFileContent.GetContenido(idm);

            var totalInc = listaActual.Where(x => x.Incluido == true).Sum(x => x.Total);
            var totalAdd = listaActual.Where(x => x.Incluido == false).Sum(x => x.Total);

            master.TotalAdicional = totalAdd;
            master.TotalIncluido = totalInc ;
            master.TotalMaster = totalInc + totalAdd;

            var r = this.Repositorio.MasterFile.Update(master);
            await this.Repositorio.CompleteAsync();


            var obj = new
            {
                ok = true,
                mensaje = $"Se Elimino el registro {id}, correctamente",
                contenido = itemEncontrado,
                master = master
            };

            return Ok(obj);

        }

        [HttpPost("registrar/{h:int}/{idm:int}")]
        public async Task<IActionResult> RegistrarAdicionales(int h, int idm, [FromBody] int[] lista)
        {
            try
            {

                // obtener los servicios que estan en el array
                var listaServicios = await this.Repositorio.Servicios.GetServicioInclude(h, lista);

                var master = await this.Repositorio.MasterFile.GetByIdAsync(idm);
                // 
                List<MasterFileContent> listaContenido = new List<MasterFileContent>();

                foreach (var serv in listaServicios)
                {
                    MasterFileContent mfc = new MasterFileContent();

                    mfc.Id = 0;
                    mfc.MasterFileId = master.Id;
                    mfc.ServicioId = serv.Id;
                    mfc.PrecioUnitario = serv.PrecioSugerido;
                    mfc.Cantidad = 1;
                    mfc.Total = serv.PrecioSugerido;
                    mfc.Img = null;
                    //mfc.DivisaId = master.DivisaId;
                    mfc.TieneImagen = false;
                    mfc.OcRealizado = false;
                    mfc.OcRequerido = false;
                    mfc.Incluido = false;

                    listaContenido.Add(mfc);
                }

                // Guardar contenido
                await this.Repositorio.MasterFileContent.AddRangeAsync(listaContenido);
                await this.Repositorio.CompleteAsync();

                // Actualizar los totales

                var listaActual = await this.Repositorio.MasterFileContent.GetContenido(idm);

                var totalInc = listaActual.Where(x => x.Incluido == true).Sum(x => x.Total);
                var totalAdd = listaActual.Where(x => x.Incluido == false).Sum(x => x.Total);

                master.TotalAdicional = totalAdd;
                master.TotalIncluido = totalInc ;
                master.TotalMaster = totalInc + totalAdd;

                var r = this.Repositorio.MasterFile.Update(master);

                await this.Repositorio.CompleteAsync();

                // OK
                var obj = new
                {
                    ok = true,
                    contenido = listaActual,
                    master = master
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

        // <<- ACTIONS

    }
}