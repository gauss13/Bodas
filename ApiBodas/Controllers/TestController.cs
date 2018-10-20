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
    public class TestController : ControllerBase
    {
        public IRepositorioWrapper Rw { get; }

        public TestController(IRepositorioWrapper rw)
        {
            Rw = rw;
        }

       
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var lista = await this.Rw.Usuarios.GetAllAsyc();

            return lista;
        }



    }
}