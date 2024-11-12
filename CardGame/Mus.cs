using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Mus : Juego
    {
        public Mus(List<Jugador> jugadores)
        {
            Baraja = new BarajaEspanyola();
            Baraja.inicializarBaraja();

            if (jugadores.Count == 4)
            {
                JugadoresList = jugadores;
            }
            else
            {
                throw new ArgumentException("El juego de Mus es de exactamente 4 jugadores.");
            }
        }
        public override void repartirBaraja()
        {
            Baraja.barajar();

            for (int i = 0; i < 4; i++)
            {
                foreach (Jugador jugador in JugadoresList)
                {
                    jugador.mano.Add(Baraja.sacarCarta());
                }
            }
        }

        public static Jugador comprobarGrandes(List<Jugador> jugadores)
        {
            List<Carta> manoGanadora = jugadores.First().mano.OrderByDescending(c => c.Numero).ToList();
            Jugador ganador = jugadores.First();

            foreach (var jugador in jugadores.Skip(1))
            {
                List<Carta> manoActual = jugador.mano.OrderByDescending(c => c.Numero).ToList();

                for (int i = 0; i < manoActual.Count; i++)
                {
                    if (manoActual[i].Numero > manoGanadora[i].Numero)
                    {
                        manoGanadora = manoActual;
                        ganador = jugador;
                        break;
                    }
                    else if (manoActual[i].Numero < manoGanadora[i].Numero)
                    {
                        break;
                    }
                }
            }

            return ganador;
        }
        public static Jugador comprobarPequenyos(List<Jugador> jugadores)
        {
            List<Carta> manoGanadora = jugadores.First().mano.OrderBy(c => c.Numero).ToList();
            Jugador ganador = jugadores.First();

            foreach (var jugador in jugadores.Skip(1))
            {
                List<Carta> manoActual = jugador.mano.OrderBy(c => c.Numero).ToList();

                for (int i = 0; i < manoActual.Count; i++)
                {
                    if (manoActual[i].Numero > manoGanadora[i].Numero)
                    {
                        manoGanadora = manoActual;
                        ganador = jugador;
                        break;
                    }
                    else if (manoActual[i].Numero < manoGanadora[i].Numero)
                    {
                        break;
                    }
                }
            }

            return ganador;
        }

        public static Jugador comprobarParejas(List<Jugador> jugadores)
        {
            return jugadores.OrderByDescending(jugador =>
            {
                var grupos = jugador.mano.GroupBy(c => c.Numero).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key);

                int parejas = grupos.Count(g => g.Count() == 2);
                int trios = grupos.Count(g => g.Count() == 3);

                if (parejas == 2) return 3 * 1000 + grupos.First().Key; 
                if (trios == 1) return 2 * 1000 + grupos.First().Key; 
                if (parejas == 1) return 1 * 1000 + grupos.First().Key;

                return 0;

            }).First();
        }

        public static Jugador comprobarJuego(List<Jugador> jugadores)
        {
            Jugador ganador = null;
            int mejorJuego = -1;
            int mejorPunto = 0;

            foreach (var jugador in jugadores)
            {

                int valorMano = jugador.mano.Sum(c => c.Valor);

                if (valorMano >= 31)
                {
                    int juego = ObtenerJuego(valorMano);
                    if (juego < mejorJuego)
                    {
                        mejorJuego = juego;
                        ganador = jugador;
                    }
                }
                else if ( valorMano > mejorPunto)
                {
                    mejorPunto = valorMano;
                    if ( ganador == null || mejorJuego == -1)
                    {
                        ganador = jugador;
                    }
                }
            }

            return ganador;
        }

        private static int ObtenerJuego(int sumaCartas)
        {
            if (sumaCartas == 31) return 31;
            if (sumaCartas == 32) return 32;
            if (sumaCartas >= 33 && sumaCartas <= 40) return 40 - (sumaCartas - 33);
            return -1;
        }


        public override void partida()
        {
            repartirBaraja();

            Console.WriteLine("Ganador grandes: "+ comprobarGrandes(JugadoresList).ToString());
            Console.WriteLine("Ganador pequeños: "+ comprobarPequenyos(JugadoresList).ToString());
            Console.WriteLine("Ganador parejas: "+ comprobarParejas(JugadoresList).ToString());
            Console.WriteLine("Ganador Juego: " + comprobarJuego(JugadoresList).ToString());

            foreach (var jugador in JugadoresList)
            {
                jugador.mano.Clear();
            }
        }
    }
}
