using System;

namespace br21.core.entidade.temporada
{
    public class entTemporada
    {
        public Object _id { get; set; }
        public int idtemporada { get; set; }

        public entTemporada()
        {
            _id = Guid.NewGuid().ToString();

        }

    }
}
