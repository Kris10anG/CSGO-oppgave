using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
                new Terrorist("Kristian1", this),
                new Terrorist("Marie2", this),
                new Terrorist("Terje3", this),
                new Terrorist("Eskil4", this),
                new Terrorist("Geir5", this),
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
                Console.WriteLine("Round has begun");
                Task.Delay(3000);
                if (roundCounter == 5)
                {
                    roundCounter = 0;
                }

                var result = Terrorists[roundCounter].FindBombSite();
                Console.WriteLine(Terrorists[roundCounter].Name + " tried to find the bomb site!");
                if (result) 
                {
                    for (int i = 30; i >= 0; i--)
                    {
                        BombCountdown(i);

                        var rndTerrorist = FindRandomTerrorist(Terrorists);
                        if (rndTerrorist == null)
                        {
                            Console.WriteLine("CT drepte alle terrorister");
                        }
                        else
                        {
                            Console.WriteLine(CounterTerrorists[roundCounter].Name + " is trying to kill" + rndTerrorist.Name);
                            CounterTerrorists[roundCounter].KillTerrorist(rndTerrorist);
                        }
                        var succes = CounterTerrorists[roundCounter].ScouteAllDeadTerroristAndDefusebomb(Terrorists);
                        if (succes)
                        {
                            break;
                        }
                        var rndCt = FindRandomCounterTerrorist(CounterTerrorists);
                        if (rndCt == null)
                        {
                            Console.WriteLine("Alle er drept. Terroristene har vunnet!");
                        }
                        else
                        {
                            Console.WriteLine(Terrorists[roundCounter].Name + " is trying to kill" + rndCt.Name);

                            Terrorists[roundCounter].KillCounterTerrorist(rndCt);
                        }

                    }
                }
                roundCounter++;
            }
        }

        private Terrorist FindRandomTerrorist(List<Terrorist> terrorists)
        {
            var terror = terrorists.Where(t => t.IsDead == false).ToList();
            if (terror.Count > 0)
            {
                var randomTerrorist = rand.Next(0, terror.Count);
                return terror[randomTerrorist];

            }
            else
            {
                return null;
            }
        }

        private CounterTerrorist FindRandomCounterTerrorist(List<CounterTerrorist> ct)
        {
            var Ct = ct.Where(c => c.IsDead == false).ToList();
            if (Ct.Count > 0)
            {
                var randomCt = rand.Next(0, Ct.Count);
                return Ct[randomCt];
            }
            else
            {
                return null;
            }
        }

        public void BombCountdown(int i)
        {
            Console.WriteLine("*");
            Thread.Sleep(1000);
            if (i == 15)
            {
                BomHasBeenPlanted = true;
                Console.WriteLine("Terroristene har plantet bomben!!!");
            }

            if (i == 0)
            {
                if (BomHasBeenPlanted)
                    Console.WriteLine("ALLAHU AKBAR!!! Terroristene vinner.");
                Environment.Exit(0);
            }
            //else
            //{
            //    Console.WriteLine("Bomben har stoppet å tikke ned!");
            //}

        }
    }
}
