using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Models
{
    [Serializable]
    public class Contador
    {
        public int _iContador { get; set; }

        public Contador() { }

        public Contador(int _iContador) 
        {
            this._iContador = _iContador;
        }
    }
}
