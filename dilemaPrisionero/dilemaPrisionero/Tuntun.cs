using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{
    internal class Tuntun : Jugador
    {
        public Tuntun(string nombre) : base(nombre)
        {
        }

        public override bool decision()
        {
            Random random = new Random();
            int decision = random.Next(2);

            return decision == 1 ? true : false;
        }
    }
}
