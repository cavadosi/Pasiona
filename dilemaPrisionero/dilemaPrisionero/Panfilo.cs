using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{
    internal class Panfilo : Jugador
    {
        public Panfilo(string nombre) : base(nombre)
        {
        }

        public override bool decision()
        {
            return true;
        }
    }
}
