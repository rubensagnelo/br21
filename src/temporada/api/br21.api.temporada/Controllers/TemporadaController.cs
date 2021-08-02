using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br21.core.modelo.temporada;
using br21.core.negocio.temporada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace br21.api.temporada.Controllers
{
    [Route("br21api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {
        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlRetornoTemporadas lst = new mdlRetornoTemporadas(temporadaServico.Get(out errcode));
            return StatusCode(errcode, lst);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            int errcode = 0;
            mdlRetornoTemporadas lst = new mdlRetornoTemporadas(temporadaServico.Get(out errcode, id));
            return StatusCode(errcode, lst);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaTemporada value)
        {
            int errcode = temporadaServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpPut]
        public virtual IActionResult Put(int id, [FromBody] mdlEntradaTemporada value)
        {
            int errcode = temporadaServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            int errcode = 0;
            temporadaServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }
    }
}
