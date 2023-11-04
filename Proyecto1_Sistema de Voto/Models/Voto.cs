using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models
{
    [Serializable]
    public class Voto
    {
        public int _sID_VOTO {  get; set; }
        public string _sCANDIDATO { get; set; }
        public string _sESTADO { get; set; }
        public DateTime _dFECHA_CREACION { get; set; }

        public Voto() { }

        public Voto(string _sCANDIDATO, string _sESTADO, DateTime _dFECHA_CREACION)
        {
            this._sCANDIDATO = _sCANDIDATO;
            this._sESTADO = _sESTADO;
            this._dFECHA_CREACION = _dFECHA_CREACION;
        }
    }
}
