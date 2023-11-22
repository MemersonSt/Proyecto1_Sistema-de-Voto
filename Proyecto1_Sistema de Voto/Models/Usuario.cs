using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models {
    [Serializable]
    public class Usuario {
        public string _sMail {  get; set; }
        public string _sCEDULA { get; set; }
        public string _sNOMBRES { get; set; }
        public string _sAPELLIDOS { get; set; }
        public string _sCONTRASEÑA { get; set; }
        public string _sPROVINCIA { get; set; }
        public bool _bESTADO_VOTO {get; set; }
        public string _sSEXO { get; set; }
        public string _sESTADO {  get; set; }
        public DateTime _dFECHA_CREACION { get; set; }

        public Usuario () { }

        public Usuario (string _sMail, string _sCEDULA, string _sNOMBRES, string _sAPELLIDOS, string _sCONTRASEÑA, string _sPROVINCIA, bool _bESTADO_VOTO, string _sSEXO, string _sESTADO, DateTime _dFECHA_CREACION) {
            this._sMail = _sMail;
            this._sCEDULA = _sCEDULA;
            this._sNOMBRES = _sNOMBRES;
            this._sAPELLIDOS = _sAPELLIDOS;
            this._sCONTRASEÑA = _sCONTRASEÑA;
            this._sPROVINCIA = _sPROVINCIA;
            this._bESTADO_VOTO = _bESTADO_VOTO;
            this._sSEXO = _sSEXO;
            this._sESTADO = _sESTADO;
            this._dFECHA_CREACION = _dFECHA_CREACION;
        }
    }
}