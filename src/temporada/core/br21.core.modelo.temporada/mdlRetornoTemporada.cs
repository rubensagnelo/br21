using System;
using br21.core.entidade.temporada;
using System.Collections.Generic;
using br21.modelobase;

namespace br21.core.modelo.temporada
{
    public class mdlRetornoTemporada 
    {
        public int idtemporada { get; set; }


        public mdlRetornoTemporada()
        {
            idtemporada = 0;
        }

        public mdlRetornoTemporada(entTemporada temporada)
        {
            idtemporada = temporada.idtemporada;
        }

        public entTemporada Entidade()
        {
            entTemporada result = new entTemporada();
            result.idtemporada = this.idtemporada;
            return result;
        }

    }


    public class mdlRetornoTemporadas : mdlRetornobaseLista<mdlRetornoTemporada>
    {
        public mdlRetornoTemporadas()
        {

        }

        public mdlRetornoTemporadas(List<entTemporada> temporadas)
        {
            foreach (var item in temporadas)
                Add(new mdlRetornoTemporada(item));
        }

        public List<entTemporada> Entidade()
        {
            List<entTemporada> result = new List<entTemporada>();
            foreach (var item in this)
                result.Add(item.Entidade());
            return result;
        }

    }


}
