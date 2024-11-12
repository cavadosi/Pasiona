using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{
    internal class Maquiavelo : Jugador
    {
        public Maquiavelo(string nombre) : base(nombre)
        {
        }

        public override bool decision()
        {
            return false;
        }
    }
}
