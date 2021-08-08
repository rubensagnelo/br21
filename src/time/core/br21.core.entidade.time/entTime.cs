using System;

namespace br21.core.entidade.time
{
    public class entTime
    {
        /// <summary>
        /// Identificador único do registro exigido pelo mongodb
        /// </summary>
        public Object _id { get; set; }
        
        /// <summary>
        /// Identificador único do time
        /// </summary>
        public string idttime { get; set; }
        
        /// <summary>
        /// Sigla do time
        /// </summary>
        public string sgltime { get; set; }
        
        /// <summary>
        /// Nome do time
        /// </summary>
        public string dsctime { get; set; }
                

        public entTime()
        {
            _id = Guid.NewGuid().ToString();

        }
    }
}
