using System;
using br21.modelobase;
using br21.core.entidade.jogo;
using System.Collections.Generic;
using br21.modelobase;
using System.Text.Json.Serialization;


namespace br21.core.modelo.jogo
{
    public class mdlRetornoJogo
    {

        public long idjogo { get; set; } //identificador do jogo
        public int idttemporada { get; set; }//identificador da temporada(exemplo: 2021)
        public int rodada { get; set; } //Numero da rodada
        public string dtajogo { get; set; }  //Data e hora inicio jogo


        public string idttimemandante { get; set; } //Identificador do time visitante
        public string dsctimemandante { get; set; } //Nome do time mandante
        public int vlrplacarmandante { get; set; } //placar do mandante

        public string idttimevisitante { get; set; } //Identificador do time visitante
        public string dsctimevisitante { get; set; } //Nome do time visitante
        public int vlrplacarvisitante { get; set; } //placar do visitante


        public mdlRetornoJogo()
        {
            idjogo = 0;
            idttemporada = 0;
            rodada = 0;
            dtajogo = DateTime.MinValue.ToString("yyyy-MM-dd hh:mm");
            idttimemandante = string.Empty;
            dsctimemandante = "";
            vlrplacarmandante = 0;
            idttimevisitante = string.Empty;
            dsctimevisitante = "";
            vlrplacarvisitante = 0;
            //imgescudo = new List<byte>().ToArray();
        }

        public mdlRetornoJogo(entJogoRetorno jogo)
        {
            idjogo = jogo.idjogo;
            idttemporada = jogo.idttemporada;
            rodada = jogo.rodada;
            dtajogo = jogo.dtajogo;

            idttimemandante = jogo.idttimemandante;
            dsctimemandante = jogo.dsctimemandante;
            vlrplacarmandante = jogo.vlrplacarmandante;

            idttimevisitante = jogo.idttimevisitante;
            dsctimevisitante = jogo.dsctimevisitante;
            vlrplacarvisitante = jogo.vlrplacarvisitante;
        }

        public entJogoRetorno Entidade()
        {
            entJogoRetorno result = new entJogoRetorno();
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

    
    public class mdlRetornoJogos : List<mdlRetornoJogo>
    {
 
        public mdlRetornoJogos()
        {

        }

        public mdlRetornoJogos(List<entJogoRetorno> jogos)
        {
            foreach (var item in jogos)
                Add(new mdlRetornoJogo(item));
        }

        public List<entJogoRetorno> Entidade()
        {
            List<entJogoRetorno> result = new List<entJogoRetorno>();
            foreach (var item in this)
                result.Add(item.Entidade());
            return result;
        }

    }

}