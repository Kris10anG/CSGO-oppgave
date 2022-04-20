using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_oppgave
{
    internal class Game
    {
        public List<Terrorist> Terrorists { get; set; }
        public List<CounterTerrorist> CounterTerrorists { get; set; }
        public static Random rand = new Random();
        public int roundCounter = 0;
        public bool BomHasBeenPlanted = false;
        public Game()
        {
            Terrorists = new List<Terrorist>()
            {
                new Terrorist("Kristian", this),
                new Terrorist("Marie", this),
                new Terrorist("Terje", this),
                new Terrorist("Eskil", this),
                new Terrorist("Geir", this),
            };
            CounterTerrorists = new List<CounterTerrorist>()
            {
                new CounterTerrorist("Geir", this),
                new CounterTerrorist("Freddy", this),
                new CounterTerrorist("Anders", this),
                new CounterTerrorist("Lillie", this),
                new CounterTerrorist("Bjørnar", this),
            };
            while (true)
            {
                roundCounter ++;
                Terrorists[roundCounter].FindBombSite();
                var rndTerrorist = FindRandomTerrorist(Terrorists);
                CounterTerrorists[roundCounter].KillTerrorist(rndTerrorist);
            }
        }
        private Terrorist FindRandomTerrorist(List<Terrorist> terrorists)
        {
           var randomTerrorist = rand.Next(0, terrorists.Count);
           return terrorists[randomTerrorist];
        }
        

        public void FindRandomPlayer(List<Character> enemyList)
        {
            var randomIndex = rand.Next(enemyList.Count);
        }

    }
}
