using System;
using br21.core.entidade.temporada;
using System.Collections.Generic;
using br21.modelobase;
using System.ComponentModel.DataAnnotations;

namespace br21.core.modelo.temporada
{
    public class mdlEntradaTemporada
    {

        [Required(ErrorMessage = "Identificador da temporada é obrigatória.")]
        public int idtemporada { get; set; }

        public mdlEntradaTemporada()
        {
            idtemporada = 0;
        }

        public mdlEntradaTemporada(entTemporada temporada)
        {
            idtemporada = temporada.idtemporada;
        }

        public entTemporada Entidade() {
            entTemporada result = new entTemporada();
            result.idtemporada = this.idtemporada;
            return result;
        }

    }


    public class mdlEntradaTemporadas : List<mdlEntradaTemporada>
    {
        public mdlEntradaTemporadas()
        {

        }

        public mdlEntradaTemporadas(List<entTemporada> temporadas)
        {
            foreach (var item in temporadas)
                Add(new mdlEntradaTemporada(item));
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