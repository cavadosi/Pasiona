using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{


    internal abstract class Jugador
    {
        public string Nombre {  get; set; }
        public int Puntuacion {  get; set; }   
        bool Decision { get; set; }

        public Jugador(string nombre) 
        { 
            Nombre = nombre;
            Puntuacion = 0;
        }

        public abstract bool decision();

        public override string ToString()
        {
            return Nombre +": "+ Puntuacion +" puntos";
        }
    }
}
