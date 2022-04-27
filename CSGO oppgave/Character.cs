using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_oppgave
{
    internal class Character
    {
        public string Name { get; set; }
        public bool IsDead { get; set; }
        private static Random rand { get; set; }

        public Character(string name, bool isDead = false)
        {
            Name = name;
            IsDead = isDead;
            rand = new Random();
        }

        public static bool IsSuccessful(int maxValue)
        {
            return rand.Next(0, maxValue) == 2;
        }
    }
}
