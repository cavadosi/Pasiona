using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Poker : Juego
    {

        public enum puntuacionMano
        {
            CartaAlta = 0,
            UnPar = 1,
            DoblePar = 2,
            Trio = 3,
            Escalera = 4,
            Color = 5,
            Full = 6,
            Poker = 7,
            EscaleraColor = 8
        }

        public Poker(List<Jugador> jugadores)
        {
            Baraja = new BarajaFrancesa();
            Baraja.inicializarBaraja();

            if (jugadores.Count() >= 2 && jugadores.Count() <= 10)
            {
                JugadoresList = jugadores;
            }
            else
            {
                throw new ArgumentException("El juego de poker es de 2 a 10 jugadores");
            }
        }
        public override void repartirBaraja()
        {
            Baraja.barajar();

            for (int i = 0; i < 5; i++)
            { 
                foreach (Jugador jugador in JugadoresList)
                {
                    jugador.mano.Add(Baraja.sacarCarta());
                }
            }
        }

        public puntuacionMano evaluarMano(Jugador jugador)
        {

            if (esEscaleraColor(jugador))
                return puntuacionMano.EscaleraColor;
            else if (esPoker(jugador))
                return puntuacionMano.Poker;
            else if (esFull(jugador))
                return puntuacionMano.Full;
            else if (esColor(jugador))
                return puntuacionMano.Color;
            else if (esEscalera(jugador))
                return puntuacionMano.Escalera;
            else if (esTrio(jugador))
                return puntuacionMano.Trio;
            else if (esDoblePar(jugador))
                return puntuacionMano.DoblePar;
            else if (esPar(jugador))
                return puntuacionMano.UnPar;
            else
                return puntuacionMano.CartaAlta;
        }

        private bool esEscaleraColor(Jugador jugador) 
        {
            return esColor(jugador) && esEscalera(jugador);
        }
        private bool esPoker(Jugador jugador) 
        {
            return jugador.mano.GroupBy(c => c.Numero).Any(g => g.Count() == 4);
        }
        private bool esFull(Jugador jugador) 
        {
            var grupos = jugador.mano.GroupBy(c => c.Numero);

            bool pareja = grupos.Any(g => g.Count() == 2);
            bool trio = grupos.Any(g => g.Count() == 3);

            return pareja && trio;
        }
        private bool esColor(Jugador jugador) 
        {
            return jugador.mano.GroupBy(c => c.Palo).Count() == 5;
        }
        private bool esEscalera(Jugador jugador)
        {
            var cartasOrdenadas = jugador.mano.OrderBy(c => c.Numero).ToList();

            for (int i = 0; i < cartasOrdenadas.Count - 1; i++)
            {
                if (cartasOrdenadas[i + 1].Numero != cartasOrdenadas[i].Numero + 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool esTrio(Jugador jugador) 
        {
            return jugador.mano.GroupBy(c => c.Numero).Any(g => g.Count() == 3);
        }
        private bool esDoblePar(Jugador jugador) 
        {
            return jugador.mano.GroupBy(c => c.Numero).Where(g => g.Count() == 2).Count() == 2;
        }
        private bool esPar(Jugador jugador) 
        {
            return jugador.mano.GroupBy(c => c.Numero).Where(g => g.Count() == 2).Count() == 1;
        }

        private Jugador compararManosEmpate(Jugador ganadorActual, Jugador jugador)
        {
            List<Carta> cartasGanador = ganadorActual.mano.OrderByDescending(c => c.Numero).ToList();
            List<Carta> cartasjugador = jugador.mano.OrderByDescending(c => c.Numero).ToList();

            for (int i = 0; i < cartasGanador.Count; i++ ) 
            {
                if (cartasGanador[i].Numero > cartasjugador[i].Numero)
                {
                    return ganadorActual;   
                }
            }

            return jugador;

        }

        public override void partida()
        {
            repartirBaraja();

            Jugador ganador = null;
            puntuacionMano mejorPuntuacion = puntuacionMano.CartaAlta;
            

            foreach (var jugador in JugadoresList)
            {
                var puntuacion = evaluarMano(jugador);

                if (puntuacion > mejorPuntuacion)
                {
                    mejorPuntuacion = puntuacion;
                    ganador = jugador;
                } else if ( puntuacion == mejorPuntuacion && ganador != null)
                {
                    ganador = compararManosEmpate(ganador, jugador);
                }
            }

            if (ganador != null)
            {
                Console.WriteLine("El ganador es: " + ganador.Nombre + " con: " + mejorPuntuacion);
            }

            foreach (var jugador in JugadoresList)
            {
                jugador.mano.Clear();
            }
        }
    }
}
