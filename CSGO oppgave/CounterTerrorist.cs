using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void DefuseBomb()
        {
            Thread.Sleep(5000);
            Game.BomHasBeenPlanted = false;
            Console.WriteLine("Bomben er desermert!");
        }
        public bool ScouteAllDeadTerroristAndDefusebomb(List<Terrorist> terrorist)
        {
            bool allTerroristIsDead = true;
            foreach (var t in terrorist.Where(t => t.IsDead == false))
            {
                allTerroristIsDead = false;
            }

            if (allTerroristIsDead)
            {
                DefuseBomb();
            }

            return allTerroristIsDead;
        }

        public void KillTerrorist(Terrorist terrorist)
        {
            var successRate = Game.BomHasBeenPlanted ? 2 : 3;

            if (IsSuccessful(successRate))
            {
                if (terrorist != null)
                {
                    terrorist.IsDead = true;
                    Console.WriteLine(terrorist.Name + " is dead" + terrorist.IsDead);

                }
            }
        }
    }
}
