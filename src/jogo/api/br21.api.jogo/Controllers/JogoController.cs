using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br21.core.modelo.jogo;
using br21.core.negocio.jogo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace br21.api.time.Controllers
{
    [Route("br21api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {



        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlRetornoJogos lst = new mdlRetornoJogos(jogoServico.Get(out errcode,_urlTime));
            return StatusCode(errcode, lst);
        }


        [HttpGet("{Temporada}")]
        public virtual IActionResult Get(int Temporada)
        {
            int errcode = 0;
            mdlRetornoJogos lst = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada));
            return StatusCode(errcode, lst);
        }

        [HttpGet("{Temporada}/{rodada}")]
        public virtual IActionResult Get(int Temporada, int rodada)
        {
            int errcode = 0;
            mdlRetornoJogos times = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada, rodada));
            return StatusCode(errcode, times);
        }

        [HttpGet("{Temporada}/{rodada}/{idjogo}")]
        public virtual IActionResult Get(int Temporada, int rodada, int idjogo)
        {
            int errcode = 0;
            mdlRetornoJogos times = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada, rodada, idjogo));
            return StatusCode(errcode, times);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaJogo value)
        {
            int errcode = jogoServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpPut]
        public virtual IActionResult Put(int id, [FromBody] mdlEntradaJogo value)
        {
            int errcode = jogoServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            int errcode = 0;
            jogoServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }

        private IConfiguration _configuration;
        private String _urlTime = "";
        public JogoController(IConfiguration config)
        {
            _configuration = config;
            _urlTime = _configuration.GetSection("Aplicacao").GetSection("Parametros").GetValue<String>("urlserviceTime").ToString();
        }


    }
}
