using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_oppgave
{
    internal class Terrorist : Character
    {
        public Game Game { get; set; }
        public Terrorist(string name, Game game) : base(name)
        {
            Game = game;
        }
        public bool FindBombSite()
        {
            if (IsSuccessful(10))
            {
                Console.WriteLine("Terroristene fant A-site!");
                PlantBomb();
                return true;
            }
            else
            {
                Console.WriteLine("Terroristene leter A-site");
                return false;
            }
        }

        private void KillCounterTerrorist(CounterTerrorist ct)
        {
            if (IsSuccessful(7))
            {

            }
        }

        public bool PlantBomb()
        {
            for (int i = 20; i >= 0; i--)
            {
                Game.BomHasBeenPlanted = true;
                Console.WriteLine("*");
                Task.Delay(1000);
                if (i == 15)
                {
                    Console.WriteLine("Terroristene har plantet bomben!!!");
                }
                if (i == 0)
                {
                    Console.WriteLine("ALLAHU AKBAR!!! Terroristene vinner.");
                }
                return true;

            } return false;
        }

    }
}
