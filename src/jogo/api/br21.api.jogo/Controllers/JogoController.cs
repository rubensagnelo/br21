using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using br21.core.modelo.jogo;
using br21.core.negocio.jogo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using br21.modelobase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace br21.api.time.Controllers
{

    /// <summary>
    /// Recurso para manutenção do Jogo
    /// Documentação em: https://localhost:5001/index.html
    /// </summary>
    [Route("br21api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {

        /// <summary>
        /// Recupera a lista de todos os jogos  
        /// </summary>
        /// <returns>Resultado da operação</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet]
        public virtual IActionResult Get()
        {
            int errcode = 0;
            mdlRetornoJogos lst = new mdlRetornoJogos(jogoServico.Get(out errcode,_urlTime));
            return StatusCode(errcode, lst);
        }

        /// <summary>
        /// Recupera a lista de todos os jogos de uma temporada 
        /// </summary>
        /// <param name="Temporada">Temporada relacionada aos jogos a serem selecionados</param>
        /// <returns>Resultado da operação</returns>
        /// <returns>Lista de todos os jogos de uma temporada</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet("{Temporada}")]
        public virtual IActionResult Get(int Temporada)
        {
            int errcode = 0;
            mdlRetornoJogos lst = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada));
            return StatusCode(errcode, lst);
        }

        /// <summary>
        /// Recupera a lista de todos os jogos de uma temporada e rodada 
        /// </summary>
        /// <param name="Temporada">Temporada relacionada aos jogos a serem selecionados</param>
        /// <param name="rodada">rodada relacionada aos jogos a serem selecionados</param>
        /// <returns>Resultado da operação</returns>
        /// <returns>Lista de todos os jogos de uma temporada e rodada</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet("{Temporada}/{rodada}")]
        public virtual IActionResult Get(int Temporada, int rodada)
        {
            int errcode = 0;
            mdlRetornoJogos times = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada, rodada));
            return StatusCode(errcode, times);
        }


        /// <summary>
        /// Recupera a lista de todos os jogos de uma temporada, rodada e identificador do jogo 
        /// </summary>
        /// <param name="Temporada">Temporada relacionada aos jogos a serem selecionados</param>
        /// <param name="rodada">rodada relacionada aos jogos a serem selecionados</param>
        /// <returns>Resultado da operação</returns>
        /// <param name="idjogo">Identificador do Jogo relacionada ao jogo a ser selecionado</param>
        /// <returns>Lista de todos os jogos de uma temporada, rodada e identificador do jogo</returns>
        /// <response code="200">Sucesso na recuperação dos Jogos</response>
        /// <response code="400">valor do parametro inválido</response> 
        [HttpGet("{Temporada}/{rodada}/{idjogo}")]
        public virtual IActionResult Get(int Temporada, int rodada, int idjogo)
        {
            int errcode = 0;
            mdlRetornoJogos times = new mdlRetornoJogos(jogoServico.Get(out errcode, _urlTime, Temporada, rodada, idjogo));
            return StatusCode(errcode, times);
        }


        /// <summary>
        /// Inclui um jogo
        /// </summary>
        /// <param name="value">Jogo a ser incluido (vide estrutura mdlEntradaJogo)</param>
        /// <returns>Resultado da operação</returns>
        /// <response code="201">jogo incluido com sucesso</response>
        /// <response code="400">parametro ou estrutura de entrada inálida</response>
        /// <response code="409">jogo já existente</response>
        [HttpPost]
        public virtual IActionResult Post([FromBody] mdlEntradaJogo value)
        {
            int errcode = jogoServico.Add(value.Entidade());
            return StatusCode(errcode, value);
        }


        /// <summary>
        /// Altera os valores de um Jogo
        /// </summary>
        /// <param name="id">Identificador do Jogo</param>
        /// <param name="value">Dados a serem alterados de um jogo de Identificador especificado no parâmetro [id]</param>
        /// <returns>Resultado da operação</returns>
        // <response code="204">Jogo atualizado com sucesso</response>
        // <response code="400">Parametro ou estrutura de entrada inálida</response>
        // <response code="404">jogo nao encontrado</response>
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromRoute] int id, [FromBody] mdlEntradaJogo value)
        {
            int errcode = jogoServico.Update(id, value.Entidade());
            return StatusCode(errcode, value);
        }

        /// <summary>
        /// Exclui um Jogo
        /// </summary>
        /// <param name="id">Identificador do jogo a ser excluido</param>
        /// <returns>Resultado da operação</returns>
        // <response code="202">Jogo excluido com sucesso</response>
        // <response code="400">Id do jogo invalido</response>
        // <response code="404">Jogo nao encontrado</response>        
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            int errcode = 0;
            jogoServico.Del(out errcode, id);
            return StatusCode(errcode, id);
        }


        //[Route("br21api/ver")]
        [HttpGet]
        public virtual IActionResult ver()
        {
            var result = string.Empty;
            int errcode = 500;
            result = _config.GetSection("Aplicacao").GetValue<String>("versao").ToString();
            errcode = 200;
            return StatusCode(errcode, result);
        }

        private IConfiguration _config;
        private String _urlTime = "";
        public JogoController(IConfiguration config)
        {
            _config = config;
            _urlTime = config.GetSection("Aplicacao").GetSection("Parametros").GetValue<String>("urlserviceTime").ToString();
        }


    }
}
