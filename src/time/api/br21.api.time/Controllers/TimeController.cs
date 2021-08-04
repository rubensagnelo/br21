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
    public class TimeController : ControllerBase
    {

        /// <summary>
        /// Recupera a lista de todos os Times  
        /// </summary>
        /// <returns>Resultado da operação</returns>
        /// <response code="200">Sucesso na recuperação dos Times</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(timeServico.Get(out errcode));
            return StatusCode(errcode, times);
        }


        /// <summary>
        /// Recupera um time
        /// </summary>
        /// <param name="id">Identificado do Time</param>
        /// <returns>Resultado da operação - Dados do Time selecionado (vide mdlEntradaTimes) </returns>
        /// <returns>Lista de todos os jogos de uma temporada</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            int errcode = 0;
            mdlEntradaTimes times = new mdlEntradaTimes(timeServico.Get(out errcode, id.ToString()));
            return StatusCode(errcode, times);
        }


        /// <summary>
        /// Inclui um Time
        /// </summary>
        /// <param name="value">Time a ser incluido (vide estrutura mdlEntradaJogo)</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="201">Time incluido com sucesso</response>
        /// <response code="400">parametro ou estrutura de entrada inálida</response>
        /// <response code="409">Time já existente</response>
        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaTime value)
        {
            int errcode = timeServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }

        /// <summary>
        /// Altera os dados de um Time
        /// </summary>
        /// <param name="id">Identificador do Time</param>
        /// <param name="value">Dados a serem alterados de um Time de Identificador especificado no parâmetro [id]</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="202">Jogo atualizado com sucesso</response>
        /// <response code="400">Parametro ou estrutura de entrada inálida</response>
        /// <response code="404">jogo nao encontrado</response>
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromRoute] int id, [FromBody] mdlEntradaTime value)
        {
            int errcode = timeServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }

        /// <summary>
        /// Exclui um Time
        /// </summary>
        /// <param name="id">Identificador do Time a ser excluido</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="202">Time excluido com sucesso</response>
        /// <response code="400">Id do Time invalido</response>
        /// <response code="404">Time nao encontrado</response>    
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(string id)
        {
            int errcode = 0;
            timeServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }
    }
}
