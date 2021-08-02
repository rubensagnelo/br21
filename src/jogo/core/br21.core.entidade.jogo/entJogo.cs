using System;
using System.Collections.Generic;

namespace br21.core.entidade.jogo
{
    public class entJogo
    {
        public Object _id { get; set; }
        public long idjogo { get; set; } //identificador do jogo
        public int idttemporada { get; set; }//identificador da temporada(exemplo: 2021)
        public int rodada { get; set; } //Numero da rodada

        private string _dtajogo;
        public string dtajogo //Data e hora inicio jogo
        { 
            get { return _dtajogo; }

            set {
                ehDataValida("dtajogo", value);
                _dtajogo = value;
            } 
        }  


        public string idttimemandante { get; set; } //Identificador do time visitante
        //public string dsctimemandante { get; set; } //Nome do time mandante
        public int vlrplacarmandante { get; set; } //placar do mandante

        public string idttimevisitante { get; set; } //Identificador do time visitante
        //public string dsctimevisitante { get; set; } //Nome do time visitante
        public int vlrplacarvisitante { get; set; } //placar do visitante

        private void ehDataValida(string atributo, string valor)
        {
            try
            {
                Convert.ToDateTime(valor);
            }
            catch (Exception ex)
            {
                throw new Exception("Formato de data invalido no atributo[" + atributo + "] O formato deve ser dd/MM/yyyy HH:mm");
            }

        }

    }





    public class entJogos : List<entJogo>
    {
    }


    public class entJogoRetorno
    {
        public Object _id { get; set; }
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

    }

    public class entJogosRetorno : List<entJogoRetorno>
    {
    }

}

