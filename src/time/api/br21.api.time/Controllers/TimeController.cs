using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br21.core.modelo.time;
using br21.core.negocio.time;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace br21.api.time.Controllers
{
    [Route("br21api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(timeServico.Get(out errcode));
            return StatusCode(errcode, times);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(timeServico.Get(out errcode, id.ToString()));
            return StatusCode(errcode, times);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaTime value)
        {
            int errcode = timeServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpPut]
        public virtual IActionResult Put(int id, [FromBody] mdlEntradaTime value)
        {
            int errcode = timeServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(string id)
        {
            int errcode = 0;
            timeServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }
    }
}
