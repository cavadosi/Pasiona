using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    internal abstract class Baraja
    {
        public List<Carta> baraja = new List<Carta>();
        
        public int TotalBaraja => baraja.Count;

        public abstract void inicializarBaraja();

        public void barajar()
        {
            var random = new Random();
            baraja = baraja.OrderBy(c => random.Next()).ToList();
        }

        public Carta sacarCarta()
        {
            if (baraja.Count == 0)
                throw new InvalidOperationException("No hay más cartas en la baraja.");

            Carta carta = baraja[0];
            baraja.RemoveAt(0);
            return carta;
        }
    }

    internal class BarajaEspanyola : Baraja
    {

        public override void inicializarBaraja()
        {
            baraja.Clear();
            string[] palos = { "Oros", "Copas", "Espadas", "Bastos" };

            for (int i = 1; i <= 12; i++)
            {
                foreach (var palo in palos)
                {
                    if (i > 10)
                    {
                        baraja.Add(new Carta ( i, palo ));
                    } else
                    {
                        baraja.Add(new Carta ( i, palo, 10 ));
                    }
                }
            }
        }
    }

    internal class BarajaFrancesa : Baraja
    {
        public override void inicializarBaraja()
        {
            baraja.Clear();
            string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };

            for (int i = 1; i <= 13; i++)
            {
                foreach (var palo in palos)
                {
                    baraja.Add(new Carta ( i, palo ));
                }
            }
        }
    }
}

