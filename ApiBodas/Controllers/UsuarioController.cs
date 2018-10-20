using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiBodas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IRepositorioWrapper Rw { get; }

        public UsuarioController(IRepositorioWrapper rw)
        {
            Rw = rw;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetUsuario(int id)
        {
            if(id <= 0)
            {
                return BadRequest(new {
                    ok= false,
                    mensaje ="no se ecnontro el usuario",
                    errors = ""
                });
            }

            var item =  await this.Rw.Usuarios.GetByIdAsync(id);

            return Ok(item);
        }

        public async Task<IActionResult> GetAllUsuarios()
        {
            var lista = await this.Rw.Usuarios.GetAllAsyc();

            var obj = new
            {
                ok = true,
                total = lista.Count(),
                usuarios = lista
            };

            return Ok(obj);
        }

    
        [HttpPost]
        public  IActionResult Crear(Usuario item)
        {
          var itemCreado = this.Rw.Usuarios.AddAsync(item);

            var ob = new
            {
                ok = true,
                usuario = itemCreado
            };

            return Created("",ob);

        }


       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var itemEncontrado =  await this.Rw.Usuarios.GetByIdAsync(id);

            if(itemEncontrado == null)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "No se contró el usuario a borrar",
                    errores = new { mensaje = "No se contró el usuario a borrar" }
                });
            }

          this.Rw.Usuarios.Remove(itemEncontrado);


            return Ok(new {
                ok = true,
                usuario = itemEncontrado
            });

        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualiza(int id)
        {
            var itemEncontrado = await this.Rw.Usuarios.GetByIdAsync(id);

            if (itemEncontrado == null)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "No se contró el usuario a actualizar",
                    errores = new { mensaje = "No se contró el usuario a actualizare" }
                });
            }

          var r =   this.Rw.Usuarios.Update(itemEncontrado);

            return Ok(new
            {
                ok = true,
                usuario = r
            });

        }




    }
}