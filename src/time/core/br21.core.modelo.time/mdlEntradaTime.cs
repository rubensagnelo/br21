using System;
using br21.modelobase;
using br21.core.entidade.time;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace br21.core.modelo.time
{
    public class mdlEntradaTime : mdlEntradabase
    {
        [Required(ErrorMessage = "Identificador do time é obrigatório.")]
        public string idttime { get; set; }

        [Required(ErrorMessage = "A sigla do time é obrigatória.")]
        public string sgltime { get; set; }
        
        [Required(ErrorMessage = "A descrição do time é obrigatório.")]
        public string dsctime { get; set; }
        //public byte[] imgescudo { get; set; }


        public mdlEntradaTime() {
            idttime = "";
            sgltime = "";
            dsctime = "";
            //imgescudo = new List<byte>().ToArray();
        }

    public mdlEntradaTime(entTime time)
        {
            idttime = time.idttime;
            dsctime = time.dsctime;
            sgltime = time.sgltime;
            //imgescudo = time.imgescudo;
        }

        public entTime Entidade() {
            entTime result = new entTime();
            result.idttime = this.idttime;
            result.dsctime = this.dsctime;
            result.sgltime = this.sgltime;
            //result.imgescudo = this.imgescudo;
            return result;
        }

    }

    public class mdlEntradaTimes : List<mdlEntradaTime>
    {

        public mdlEntradaTimes() { 
        
        }

        public mdlEntradaTimes(List<entTime> times)
        {
            foreach (var item in times)
                Add(new mdlEntradaTime(item));
        }

        public List<entTime> Entidade() {
            List<entTime> result = new List<entTime>();
            foreach (var item in this)
                result.Add(item.Entidade());
            return result;
        }

    }

}
