using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;
using Entities.Models;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace ApiBodas.Controllers
{
   
    [Route("api/[controller]")]
    [EnableCors("EnableCORS")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public AgendaController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        // ->> ACTIONS

        [HttpGet("{h:int}/{id}")]
        public async Task<IActionResult> GetById(int h, int id)
        {
            //var item = await this.Repositorio.Agendas.GetByIdAsync(id);
            var item = await this.Repositorio.Agendas.FindAsyc(x => x.HotelId == h && x.Id == id);

            if (!item.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = $"No se encontró el registro con id {id}",
                    errors = ""
                };

                return Ok(objB);
            }


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
                agenda = item.FirstOrDefault()
            });
        }

        [HttpGet("{h:int}/master/{id}")]
        public async Task<IActionResult> GetByIdForMaster(int h, int id)
        {            
            var item = await this.Repositorio.Agendas.FindAsyc(x => x.HotelId == h && x.Id == id);

            if (!item.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = $"No se encontró el registro con id {id}",
                    errors = ""
                };

                return Ok(objB);
            }


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

            var agenda = item.FirstOrDefault();

            //buscamos el paquete
            var paq = await this.Repositorio.Paquetes.GetByIdAsync(agenda.PaqueteId);
            //buscamos el master file
            var mfl = await this.Repositorio.MasterFile.FindAsyc(x => x.AgendaId == agenda.Id);

            var mf = mfl.FirstOrDefault();
            //buscamos el contenido de master file
            //var mfc = await this.Repositorio.MasterFileContent.FindAsyc(x => x.MasterFileId == mf.Id);


            return Ok(new
            {
                ok = true,
                agenda,
                paquete=paq,
                master= mf               

            });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await this.Repositorio.Agendas.GetAllAsyc();

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
                agenda = lista
            };

            return Ok(obj);
        }

        
        [HttpGet("fechas/{h:int}/{a:int}/{m:int}")]
        public async Task<IActionResult> GetFechasPorMes(int h, int a, int m)
        {
            var lista = await this.Repositorio.Agendas.GetFechasByMes(h,a, m);
            var listaBloqueadas = await this.Repositorio.DiasBloqueados.GetFechasByMes(h,a,m);

            var listaFechas = new List<AgendaFechas>();

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
            else
            {
                foreach (var ag in lista)
                {
                    if (!ag.FechaBoda.HasValue) continue;

                    AgendaFechas iagenda = new AgendaFechas();

                    var tipo = TipoEstatus(ag.EstadoAgendaId);

                    iagenda.idagenda = ag.Id;
                    iagenda.start = $"{ag.FechaBoda.Value.ToString("yyyy-MM-dd")}T{ag.HoraBoda}:00";
                    iagenda.end = "";
                    iagenda.title = tipo.tipoFecha;
                    iagenda.estatus = ag.EstadoAgendaId;
                    iagenda.url = "";
                    iagenda.color = tipo.color;
                    iagenda.textColor = tipo.colortexto;

                    listaFechas.Add(iagenda);
                }
            }

            // DIAS BLOQUEADOS
      
            //foreach (var dia in listaBloqueadas)
            //{
            //    AgendaFechas iagenda = new AgendaFechas();

            //    iagenda.idagenda = 0;
            //    iagenda.start = $"{dia.Fecha.ToString("yyyy-MM-dd")}T00:00";
            //    iagenda.end = $"{dia.Fecha.ToString("yyyy-MM-dd")}T00:00"; ;
            //    iagenda.title = "Bloqueado";
            //    iagenda.estatus = -1;
            //    iagenda.url = "";
            //    iagenda.color = "";
            //    iagenda.textColor = "";
            //    iagenda.editable = false;
            //    iagenda.selectable = false;
            //    iagenda.allDay = true;

            //    listaFechas.Add(iagenda);
            //}

            // AGREGAR A LA LISTA 

       



             // OK
             var obj = new
            {
                ok = true,
                total = listaFechas.Count(),
                fechas = listaFechas
            };

            return Ok(obj);


        }


        private (string tipoFecha, string color, string colortexto)  TipoEstatus(int e)
        {
           // (string Alpha, string Beta) letrasTuple = ("Al", "Be");


            switch (e)
            {
                case 1:
                    return ("Tentativo", "#b2dfdb", "black"); //blue
                case 2:
                    return ("Confirmado", "#009688 ", "white");  //green
                case 3:
                    return ("Cancelado", "#e91e63", "white");//rojo
                case 4:
                    return ("Bloqueado", "#9e9e9e", "black");            //gray                       
                case 5:
                    return ("Terminado", "#9e9d24 ", "white"); //orange
                default:
                    return ("Disponible", "white", "white"); //

            }
        }

   

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Agenda item)
        {
            try
            {
                item.FechaReg = DateTime.Now;
                item.Activo = true;

                if(item.Nacionalidad != null)
                item.Nacionalidad = item.Nacionalidad.ToUpper();

                if(item.DivisaComision != null)
                item.DivisaComision = item.DivisaComision.ToUpper();
                if(item.DivisaDeposito != null)
                item.DivisaDeposito = item.DivisaDeposito.ToUpper();

                var r = await this.Repositorio.Agendas.AddAsync(item);
                await this.Repositorio.CompleteAsync();



                var obj = new
                {
                    ok = true,
                    agenda = r
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
        public async Task<IActionResult> Actualizar([FromBody] Agenda itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;

                var itemEncontrado = await this.Repositorio.Agendas.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                itemEncontrado.FechaMod = DateTime.Now;
                itemEncontrado.Nacionalidad = itemEncontrado.Nacionalidad.ToUpper();

                var r = this.Repositorio.Agendas.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    agenda = itemEncontrado
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
            var itemEncontrado = await this.Repositorio.Agendas.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            // no se borra fisicamente el registro, solo se cambia de estatus
            itemEncontrado.Activo = false;
            var r = this.Repositorio.Agendas.Update(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se Desactivo el registro {id}, correctamente",
                agenda = itemEncontrado
            };

            return Ok(obj);

        }

        [HttpPut("estatus/{id:int}/{e:int}")]
        public async Task<IActionResult> CambiarEstatus(int id, int e)
        {
            try
            {
                var itemEncontrado = await this.Repositorio.Agendas.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.EstadoAgendaId = e;

                itemEncontrado.FechaMod = DateTime.Now;
                var r = this.Repositorio.Agendas.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    Agenda = itemEncontrado
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

        // <<- ACTIONS

        // ARCHIVOS 

        [HttpGet("files/{h:int}/{a:int}/{m:int}")]
        public IActionResult GetReporteMensual(int h, int a, int m)
        {
            try
            {
                Reportes.AgendaR ar = new Reportes.AgendaR();
                var r = ar.Mensual();              

                return File(r, "application/vnd.ms-excel", "holamundo.xlsx");        
                




            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
           

        }



    }
}