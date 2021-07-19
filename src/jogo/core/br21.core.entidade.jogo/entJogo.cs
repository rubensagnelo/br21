using System;

namespace br21.core.entidade.jogo
{
    public class entJogo
    {
        public int idttemporada { get; set; }//identificador da temporada(exemplo: 2021)
        public DateTime dtajogo { get; set; }  //Data e hora inicio jogo


        public int idttimemandante { get; set; } //Identificador do time visitante
        public string dsctimemandante { get; set; } //Nome do time mandante
        public int vlrplacarmandante { get; set; } //placar do mandante

        public int idttimevitantes { get; set; } //Identificador do time visitante
        public string dsctimevisitante { get; set; } //Nome do time visitante
        public int vlrplacarvisitante { get; set; } //placar do visitante

    }
}
