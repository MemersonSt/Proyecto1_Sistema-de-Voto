using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models
{
    public class Candidato
    {
        public string _sCedula { get; set; }
        public string _sNombre { get; set; }
        public string _sLista { get; set; }
        public string _sMail { get; set; }
        public string _sTag { get; set; }

        public Candidato() { }

        public Candidato(string _sCedula, string _sNombre, string _sLista, string _sMail)
        {
            this._sCedula = _sCedula;
            this._sNombre = _sNombre;
            this._sLista = _sLista;
            this._sMail = _sMail;
        }
    }
}
