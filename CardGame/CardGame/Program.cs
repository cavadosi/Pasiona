namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador1 = new Jugador("Anuel");
            Jugador jugador2 = new Jugador("Quevedo");
            Jugador jugador3 = new Jugador("Xavi");
            Jugador jugador4 = new Jugador("Pol");
            List<Jugador> jugadoresList = new List<Jugador> { jugador1, jugador2, jugador3, jugador4};

            Mus partidaMus = new Mus(jugadoresList);

            partidaMus.partida();


        }
    }
}
