using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Jugador 
    {
        public List<Carta> mano { get; set; } = new List<Carta>();
        public string Nombre { get; set; }

        public Jugador(string nombre) 
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
