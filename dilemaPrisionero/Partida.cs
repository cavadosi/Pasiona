using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{

    interface ILogicaPartida
    {
        (int, int)[,] Resultados { get; }
        void comprobacionPartida(Jugador jugador1, Jugador jugador2);
    }

    internal class PartidaDefault : ILogicaPartida
    {
        public (int, int)[,] Resultados { get; } = new (int, int)[,]
        {
            {(3,3), (-5,5) },
            {(5,-5), (-1,-1)}
        };

        public void comprobacionPartida(Jugador jugador1, Jugador jugador2) 
        {

            int i = jugador1.decision() ? 0 : 1;
            int j = jugador2.decision() ? 0 : 1;

            jugador1.Puntuacion += Resultados[i, j].Item1;
            jugador2.Puntuacion += Resultados[i, j].Item2;
        }

    }
}
