using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_oppgave
{
    internal class CounterTerrorist : Character
    {
        public Game Game { get; set; }
        private Random rand { get; set; }
        public CounterTerrorist(string name, Game game) : base(name)
        {
            Game = game;
        }
        private void DefuseBomb()
        {
            Task.Delay(5000);
        }

       
        public void KillTerrorist(Terrorist terrorist)
        {
            var successRate = Game.BomHasBeenPlanted ? 3 : 5;

            if (IsSuccessful(successRate))
            {
                //var terroristToDie = terrorist.FindLast(t => t.IsDead == false);
                if (terrorist != null)
                {
                    terrorist.IsDead = true;
                    Console.WriteLine(terrorist.IsDead);
                }
            }

            //if (Game.BomHasBeenPlanted == true)
            //{
            //    IsSuccessful(3);
            //}
        }
    }
}
