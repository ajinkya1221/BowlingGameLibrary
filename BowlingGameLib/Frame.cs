using System.Collections.Generic;
using System.Linq;

namespace BowlingGameLib
{
    public class Frame
    {
        public Frame()
        {
            Rolls = new List<int>();
        }
        public List<int> Rolls { get; set; }

        public int Score => Rolls.Sum();

        public bool IsStrike => Rolls.Count > 0 && Rolls[0] == 10;
        public bool IsSpare => Rolls.Count > 1 && Rolls[0] + Rolls[1] == 10;
    }
}