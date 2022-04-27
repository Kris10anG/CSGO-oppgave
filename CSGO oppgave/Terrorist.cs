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
                return true;
            }
            else
            {
                return false;
            }
        }

        public void KillCounterTerrorist(CounterTerrorist ct)
        {
            if (IsSuccessful(7))
            {
                if (ct != null)
                {
                    ct.IsDead = true;
                    Console.WriteLine(ct.Name + " is dead" + ct.IsDead);

                }
            }
        }

        //public void PlantBomb()
        //{
        //    for (int i = 20; i >= 0; i--)
        //    {
        //        Console.WriteLine("*");
        //        Task.Delay(1000);
        //        if (Game.BomHasBeenPlanted)
        //        {
        //        if (i == 15)
        //        {
        //            Game.BomHasBeenPlanted = true;
        //            Console.WriteLine("Terroristene har plantet bomben!!!");
        //        }
        //        if (i == 0)
        //        {
        //            Console.WriteLine("ALLAHU AKBAR!!! Terroristene vinner.");
        //        }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Bomben har stoppet å tikke ned!");
        //        }

        //    }
        //}

    }
}
