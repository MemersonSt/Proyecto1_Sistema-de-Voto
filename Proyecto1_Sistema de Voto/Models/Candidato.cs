   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models
{
    [Serializable]
    public class Candidato
    {
        public string _sCEDULA { get; set; }
        public string _sNOMBRE { get; set; }
        public string _sLISTA { get; set; }
        public string _sMAIL { get; set; }
        public string _sESTADO { get; set; }
        public DateTime _dFECHA_CREACION { get; set; }

        public Candidato() { }

        public Candidato(string _sCEDULA, string _sNOMBRE, string _sLISTA, string _sMAIL, string _sESTADO, DateTime _dFECHA_CREACION)
        {
            this._sCEDULA = _sCEDULA;
            this._sNOMBRE = _sNOMBRE;
            this._sLISTA = _sLISTA;
            this._sMAIL = _sMAIL;
            this._sESTADO = _sESTADO;
            this._dFECHA_CREACION = _dFECHA_CREACION;
        }
    }
}
