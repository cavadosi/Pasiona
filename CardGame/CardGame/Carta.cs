using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Carta : IComparable<Carta>
    {
        public int Numero { get; set; }
        public string Palo { get; set; }
        public int Valor { get; set; }

        public int CompareTo(Carta other)
        {
            return this.Numero.CompareTo(other.Numero);
        }
        public Carta(int numero, string palo, int valor)
        {
            Numero = numero;
            Palo = palo;
            Valor = valor;
        }

        public Carta(int numero, string palo)
        {
            Numero = numero;
            Palo = palo;
            Valor = numero;
        }
    }

}
