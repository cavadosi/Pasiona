namespace dilemaPrisionero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maquiavelo jugador1 = new Maquiavelo("Joan");
            Panfilo jugador2 = new Panfilo("Quevedo");
            Tuntun jugador3 = new Tuntun("Bad Bunny");

            PartidaDefault partida = new PartidaDefault();
            
            Juego juego = new Juego(new List<Jugador> { jugador1, jugador2, jugador3 }, partida);


            juego.jugarPartida();
            
        }
    }
}
