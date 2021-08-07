using System;
using br21.modelobase;
using br21.core.entidade.jogo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace br21.core.modelo.jogo
{
    public class mdlEntradaJogo : mdlEntradabase
    {
        [Required(ErrorMessage = "Identificador do jogo é obrigatório.")]
        public long idjogo { get; set; } //identificador do jogo

        [Required(ErrorMessage = "Identificador da temporada é obrigatória.")]
        public int idttemporada { get; set; }//identificador da temporada(exemplo: 2021)
        [Required(ErrorMessage = "A Rodada é obrigatória.")]
        public int rodada { get; set; } //Numero da rodada

        [Required(ErrorMessage = "Data e Hora do jogo são obrigatórios.")]
        public string dtajogo { get; set; }  //Data e hora inicio jogo

        [Required(ErrorMessage = "O identificador do time mandante é obrigatório.")]
        public string idttimemandante { get; set; } //Identificador do time visitante
        public int vlrplacarmandante { get; set; } //placar do mandante

        [Required(ErrorMessage = "O identificador do time visitante é obrigatório.")]
        public string idttimevisitante { get; set; } //Identificador do time visitante
        public int vlrplacarvisitante { get; set; } //placar do visitante

        public mdlEntradaJogo()
        {
            idjogo = 0;
            idttemporada = 0;
            rodada = 0;
            dtajogo = DateTime.MinValue.ToString("yyyy-MM-dd hh:mm");
            idttimemandante = string.Empty;
            vlrplacarmandante = 0;
            idttimevisitante = string.Empty;
            vlrplacarvisitante = 0;
            //imgescudo = new List<byte>().ToArray();
        }

        public mdlEntradaJogo(entJogo jogo)
        {
            idjogo = jogo.idjogo;
            idttemporada = jogo.idttemporada;
            rodada = jogo.rodada;
            dtajogo = jogo.dtajogo;

            idttimemandante = jogo.idttimemandante;
            vlrplacarmandante = jogo.vlrplacarmandante;

            idttimevisitante = jogo.idttimevisitante;
            vlrplacarvisitante = jogo.vlrplacarvisitante;
        }

        public entJogo Entidade()
        {
            entJogo result = new entJogo();
            result.idjogo = this.idjogo;
            result.idttemporada = this.idttemporada;
            result.rodada = this.rodada;
            result.dtajogo = this.dtajogo;

            result.idttimemandante = this.idttimemandante;
            result.vlrplacarmandante = this.vlrplacarmandante;

            result.idttimevisitante = this.idttimevisitante;
            result.vlrplacarvisitante = this.vlrplacarvisitante;
            return result;
        }

    }

    public class mdlEntradaJogos : List<mdlEntradaJogo>
    {

        public mdlEntradaJogos()
        {

        }

        public mdlEntradaJogos(List<entJogo> jogos)
        {
            foreach (var item in jogos)
                Add(new mdlEntradaJogo(item));
        }

        public List<entJogo> Entidade()
        {
            List<entJogo> result = new List<entJogo>();
            foreach (var item in this)
                result.Add(item.Entidade());
            return result;
        }

    }

}
