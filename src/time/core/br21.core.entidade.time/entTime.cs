using System;

namespace br21.core.entidade.time
{
    public class entTime
    {
        public Object _id { get; set; }
        public string idttime { get; set; }
        public string sgltime { get; set; }
        public string dsctime { get; set; }
        //public byte[] imgescudo { get; set; }

        public entTime()
        {
            _id = Guid.NewGuid();

        }

    }
}
