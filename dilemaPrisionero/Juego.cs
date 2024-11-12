using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dilemaPrisionero
{
    internal class Juego
    {
        public ILogicaPartida Partida;
        List<Jugador> JugadorList;

        public Juego(List<Jugador> jugadorList)
        {
            JugadorList = jugadorList;
            Partida = new PartidaDefault();
        }
        public Juego(List<Jugador> jugadorList, ILogicaPartida logicaPartida)
        {
            JugadorList = jugadorList;
            Partida = logicaPartida;
        }

        public void jugarPartida()
        {
            for (int i = 0; i < JugadorList.Count; i++) 
            {
                for (int j = i + 1; j < JugadorList.Count ; j++) 
                {
                    for(int k = 0; k < 50; k++)
                    {
                        Partida.comprobacionPartida(JugadorList[i], JugadorList[j]);
                    }
                }
            }

            foreach (var jugador in JugadorList)
            {
                Console.WriteLine(jugador.ToString());
            }
        }
    }
}
