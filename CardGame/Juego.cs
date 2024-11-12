using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal abstract class Juego
    {
        public Baraja Baraja { get; set; }

        public List<Jugador> JugadoresList { get; set; } = new List<Jugador>();

        public abstract void repartirBaraja();

        public abstract void partida();
    }

}
