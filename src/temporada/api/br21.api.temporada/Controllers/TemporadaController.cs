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
        /// <summary>
        /// Recupera a lista de todas as temporadas  
        /// </summary>
        /// <returns>Resultado da operação</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response>
        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlRetornoTemporadas lst = new mdlRetornoTemporadas(temporadaServico.Get(out errcode));
            return StatusCode(errcode, lst);
        }


        /// <summary>
        /// Recupera uma temporada
        /// </summary>
        /// <param name="id">Identificador da temporada (Ano da temporada)</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            int errcode = 0;
            mdlRetornoTemporadas lst = new mdlRetornoTemporadas(temporadaServico.Get(out errcode, id));
            return StatusCode(errcode, lst);
        }


        /// <summary>
        /// Inclui uma temporada
        /// </summary>
        /// <param name="value">Temporada a ser incluido (vide estrutura mdlEntradaTemporada)</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="201">jogo incluido com sucesso</response>
        /// <response code="400">parametro ou estrutura de entrada inálida</response>
        /// <response code="409">jogo já existente</response>
        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaTemporada value)
        {
            int errcode = temporadaServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }


        /// <summary>
        /// Altera uma Temporada
        /// </summary>
        /// <param name="id">Identificador da Temporada</param>
        /// <param name="value">Dados a serem alterados de uma Temporada de Identificador especificado no parâmetro [id]</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="202">Temporada atualizada com sucesso</response>
        /// <response code="400">Parametro ou estrutura de entrada inálida</response>
        /// <response code="404">Temporada nao encontrada</response>
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromRoute]int id, [FromBody] mdlEntradaTemporada value)
        {
            int errcode = temporadaServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }


        /// <summary>
        /// Exclui uma Temporada
        /// </summary>
        /// <param name="id">Identificador da Temporada a ser excluido</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="202">Temporada excluida com sucesso</response>
        /// <response code="400">Id da Temporada inválida</response>
        /// <response code="404">Temporada nao encontrada</response>   
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            int errcode = 0;
            temporadaServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }
    }
}
