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
        // GET: api/<TimeController>
        [HttpGet]
        public virtual IActionResult Get()
        {

            /*
            List<mdlEntradaTime> times = new List<mdlEntradaTime>();
            times.Add(new mdlEntradaTime { idttime = 1, dsctime = "America-MG", imgescudo = null, sgltime = "AMG " });
            times.Add(new mdlEntradaTime { idttime = 2, dsctime = "Athletico-PR", imgescudo = null, sgltime = "CAP " });
            times.Add(new mdlEntradaTime { idttime = 3, dsctime = "Atlético-GO", imgescudo = null, sgltime = "ACG" });
            times.Add(new mdlEntradaTime { idttime = 4, dsctime = "Atlético-MG", imgescudo = null, sgltime = "CAM" });
            times.Add(new mdlEntradaTime { idttime = 5, dsctime = "Bahia", imgescudo = null, sgltime = "BAH" });


            */

            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(jogoService.Get(out errcode));
            return StatusCode(errcode, times);

        }

        // GET api/<TimeController>/5
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            /*
            List<mdlEntradaTime> times = new List<mdlEntradaTime>();
            times.Add(new mdlEntradaTime { idttime = 1, dsctime = "America-MG", imgescudo = null, sgltime = "AMG " });
            times.Add(new mdlEntradaTime { idttime = 2, dsctime = "Athletico-PR", imgescudo = null, sgltime = "CAP " });
            times.Add(new mdlEntradaTime { idttime = 3, dsctime = "Atlético-GO", imgescudo = null, sgltime = "ACG" });
            times.Add(new mdlEntradaTime { idttime = 4, dsctime = "Atlético-MG", imgescudo = null, sgltime = "CAM" });
            times.Add(new mdlEntradaTime { idttime = 5, dsctime = "Bahia", imgescudo = null, sgltime = "BAH" });
            var time = new mdlEntradaTime();
            try
            {
                time = times[id - 1];
            }
            catch (Exception)
            {
                return StatusCode(404, time);
            }
            return StatusCode(200, time);
            */

            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(jogoService.Get(out errcode, id.ToString()));
            return StatusCode(errcode, times);

        }

        // POST api/<TimeController>
        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaTime value)
        {
            int errcode = jogoService.Add(value.Entidade());
            return StatusCode(200, value);
        }

        // PUT api/<TimeController>/5
        [HttpPut]
        public virtual IActionResult Put(int id, [FromBody] mdlEntradaTime value)
        {
            int errcode = jogoService.Update(id, value.Entidade());
            return StatusCode(200, value);
        }

        // DELETE api/<TimeController>/5
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            int errcode = 0;
            jogoService.Del(out errcode, id);
            return StatusCode(202, id);
        }
    }
}
