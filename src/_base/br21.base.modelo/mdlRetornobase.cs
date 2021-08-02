using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace br21.modelobase
{
    public class mdlRetornobase
    {
        public string codigoErroNegocio { get; set; }
        public string msgErroNegocio { get; set; }
        public string dscerrodetalhado { get; set; }
    }

    [Serializable()]
    public class mdlRetornobaseLista<T> : List<T>
    {
        public est_erro erro { get; set; }
        
        public mdlRetornobaseLista(){
            erro = new est_erro();
        }

    }

    [Serializable()]
    public class est_erro
    {
        public string codigoErroNegocio { get; set; }
        public string msgErroNegocio { get; set; }
        public string dscerrodetalhado { get; set; }
    }
}
