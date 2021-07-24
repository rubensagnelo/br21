using System;
using System.Collections.Generic;

namespace br21.core.entidade.jogo
{
    public class Ext_entTime
    {
        public Object _id { get; set; }
        public string idttime { get; set; }
        public string sgltime { get; set; }
        public string dsctime { get; set; }
        //public byte[] imgescudo { get; set; }

    }

    public class Ext_entTimes : List<Ext_entTime> { }
}
