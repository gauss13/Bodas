﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Entities.Extenciones;
using Entities.Models.Catalogos;
using Entities.Models.Masterfiles;


namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterFileController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }
        public MasterFileController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }


        // ->> ACTIONS

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await this.Repositorio.MasterFile.GetByIdAsync(id);

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
            var lista = await this.Repositorio.MasterFile.GetAllAsyc();

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
                MasterFile = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MasterFile item)
        {
            try
            {
                //1) obtener los datos de la agenda
                var ra = await this.Repositorio.Agendas.GetByIdAsync(item.AgendaId);
                var paq = await this.Repositorio.Paquetes.GetByIdAsync(ra.PaqueteId);

                //2) Crear registro de master file
                item.Divisa = paq.Divisa;
                var m = await this.Repositorio.MasterFile.AddAsync(item);
                await this.Repositorio.CompleteAsync();                            

                //3) obtener los registros del paquete 
                var listaIncluidos = await this.Repositorio.PaquetesServicios.FindAsyc(x => x.PaqueteId == ra.PaqueteId);
                
                //4)  agregarlos como incluidos = true al masterfile content
                List<MasterFileContent> listaContenido = new List<MasterFileContent>();

                var totalIncluido = 0m;
                foreach (var incluido in listaIncluidos)
                {
                    MasterFileContent mfc = new MasterFileContent();
                    mfc.Id = 0;
                    mfc.MasterFileId = m.Id;
                    mfc.ServicioId = incluido.ServicioId;
                    mfc.PrecioUnitario = incluido.PrecioUnitario;
                    mfc.Cantidad = incluido.Cantidad;
                    mfc.Total = incluido.Total;
                    mfc.Img = null;
                    //mfc.DivisaId = m.DivisaId;
                    mfc.TieneImagen = false;
                    mfc.OcRealizado = false;
                    mfc.OcRequerido = false;
                    mfc.Incluido = true;

                    totalIncluido += incluido.Total;

                    listaContenido.Add(mfc);
                }

                //5) guardar contenido
                await this.Repositorio.MasterFileContent.AddRangeAsync(listaContenido);
                m.TotalIncluido = totalIncluido;
                m.TotalMaster = totalIncluido;
                await this.Repositorio.CompleteAsync();


                var obj = new
                {
                    ok = true,
                    masterfile = m
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
        public async Task<IActionResult> Actualizar([FromBody] MasterFile itemNuevo, int id)
        {

            try
            {
                itemNuevo.Id = id;


                var itemEncontrado = await this.Repositorio.MasterFile.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return BadRequest(new { ok = false, mensaje = "No se encontró el registro a actulizar", erros = "" });
                }

                itemEncontrado.Map(itemNuevo);

                var r = this.Repositorio.MasterFile.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                var obj = new
                {
                    ok = true,
                    MasterFile = itemEncontrado
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
            var itemEncontrado = await this.Repositorio.MasterFile.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new { ok = false, mensaje = $"No se encontró el registro con Id {id}", erros = "" });
            }

            // no se borra fisicamente el registro, solo se cambia de estatus
            itemEncontrado.Activo = false;
            var r = this.Repositorio.MasterFile.Update(itemEncontrado);
            await this.Repositorio.CompleteAsync();

            var obj = new
            {
                ok = true,
                mensaje = $"Se Desactivo el registro {id}, correctamente",
                MasterFile = itemEncontrado
            };

            return Ok(obj);

        }


        // <<- ACTIONS

    }
}