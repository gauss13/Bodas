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

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public AgendaController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.Agendas.GetByIdAsync(id);

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
                return BadRequest(objB);
            }

            // OK
            var obj = new
            {
                ok = true,
                total = lista.Count(),
                Agenda = lista
            };

            return Ok(obj);
        }

        
        [HttpGet("fechas/{a:int}/{m:int}")]
        public async Task<IActionResult> GetFechasPorMes(int a, int m)
        {
            var lista = await this.Repositorio.Agendas.GetFechasByMes(a, m);
            var listaFechas = new List<AgendaFechas>();

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
            else
            {
                foreach (var ag in lista)
                {
                    if (!ag.FechaBoda.HasValue) continue;

                    AgendaFechas iagenda = new AgendaFechas();

                    var tipo = TipoEstatus(ag.EstadoAgendaId);

                    iagenda.idagenda = ag.Id;
                    iagenda.start = $"{ag.FechaBoda.Value.ToString("yyyy-MM-dd")}T{ag.HoraBoda}";
                    iagenda.end = "";
                    iagenda.title = tipo.tipoFecha;
                    iagenda.estatus = ag.EstadoAgendaId;
                    iagenda.url = "";
                    iagenda.color = tipo.color;
                    iagenda.textColor = tipo.colortexto;

                    listaFechas.Add(iagenda);
                }
            }


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
                    return ("Tentativo", "blue", "white"); 
                case 2:
                    return ("Confirmado", "green", "white");  
                case 3:
                    return ("Cancelado", "red", "white"); 
                case 4:
                    return ("Bloqueado", "gray", "black"); 
                default:
                    return ("otro", "blue", "white"); 

            }
        }

   

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Agenda item)
        {
            try
            {
                item.FechaReg = DateTime.Now;
                item.Activo = true;
                var r = await this.Repositorio.Agendas.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    Agenda = r
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
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

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
                Agenda = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS



    }
}