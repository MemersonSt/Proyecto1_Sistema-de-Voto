using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models {
    [Serializable]
    public class Usuario {
        public string _sCedula { get; set; }
        public string _sNombres { get; set; }
        public string _sApellidos { get; set; }
        public string _sContraseña { get; set; }
        public string _sProvincia { get; set; }
        public bool _sVoto = false;

        public Usuario () { }

        public Usuario (string _sCedula, string _sNombres, string _sApellidos, string _sContraseña, string _sProvincia) {
            this._sCedula = _sCedula;
            this._sNombres = _sNombres;
            this._sApellidos = _sApellidos;
            this._sContraseña = _sContraseña;
            this._sProvincia = _sProvincia;
        }
    }
}