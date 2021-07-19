using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br21.core.entidade.time;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace br21.api.time.Controllers
{
    [Route("br21api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        // GET: api/<TimeController>
        [HttpGet]
        public virtual IActionResult Get()
        {
            List<entTime> times = new List<entTime>();
            times.Add(new entTime { idttime = 1, dsctime = "America-MG", imgescudo = null, sgltime = "AMG " });
            times.Add(new entTime { idttime = 2, dsctime = "Athletico-PR", imgescudo = null, sgltime = "CAP " });
            times.Add(new entTime { idttime = 3, dsctime = "Atlético-GO", imgescudo = null, sgltime = "ACG" });
            times.Add(new entTime { idttime = 4, dsctime = "Atlético-MG", imgescudo = null, sgltime = "CAM" });
            times.Add(new entTime { idttime = 5, dsctime = "Bahia", imgescudo = null, sgltime = "BAH" });
            return StatusCode(200, times);
        }

        // GET api/<TimeController>/5
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            List<entTime> times = new List<entTime>();
            times.Add(new entTime { idttime = 1, dsctime = "America-MG", imgescudo = null, sgltime = "AMG " });
            times.Add(new entTime { idttime = 2, dsctime = "Athletico-PR", imgescudo = null, sgltime = "CAP " });
            times.Add(new entTime { idttime = 3, dsctime = "Atlético-GO", imgescudo = null, sgltime = "ACG" });
            times.Add(new entTime { idttime = 4, dsctime = "Atlético-MG", imgescudo = null, sgltime = "CAM" });
            times.Add(new entTime { idttime = 5, dsctime = "Bahia", imgescudo = null, sgltime = "BAH" });
            var time = new entTime();
            try
            {
                time = times[id - 1];
            }
            catch (Exception)
            {
                return StatusCode(404, time);
            }
            return StatusCode(200, time);
        }

        // POST api/<TimeController>
        [HttpPost]
        public virtual IActionResult Post([FromBody] entTime value)
        {
            return StatusCode(200, value);
        }

        // PUT api/<TimeController>/5
        [HttpPut]
        public virtual IActionResult Put(int id, [FromBody] entTime value)
        {
            return StatusCode(200, value);
        }

        // DELETE api/<TimeController>/5
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            return StatusCode(202, id);
        }
    }
}
