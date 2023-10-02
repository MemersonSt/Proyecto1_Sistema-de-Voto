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
        public string _sProvincia {  get; set; }
        public string _sCandidato { get; set; }
        public int _iId { get; set; }

        public Voto() { }

        public Voto(string _sProvincia, string _sCandidato, int _iId)
        {
            this._sProvincia = _sProvincia;
            this._sCandidato = _sCandidato;
            this._iId = _iId;
        }
    }
}
