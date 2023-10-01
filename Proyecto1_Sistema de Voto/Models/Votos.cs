using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models {
    public class Votos {
        public string nombreCandidato { get; set; }
        public string archivoVotos { get; set; }
        public string _sCedula { get; set; }
        public string _sProvincia { get; set; }


        public Votos () { }
        public Votos(string nombreCandidato, string _sCedula, string _sProvincia) {
            this.nombreCandidato = nombreCandidato;
            this._sCedula = _sCedula;
            this._sProvincia = _sProvincia;
        }
    }
}
