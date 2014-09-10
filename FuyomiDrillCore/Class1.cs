using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuyomiDrillCore
{
    public class FuyomiGame
    {
        private int level;
        private List<List<string>> qSet;

        public FuyomiGame()
        {

        }

        public void GameStart()
        {

        }

        public string NextQuestion()
        {
            return "end";
        }

        public bool IsCorrect(string ans)
        {
            return false;
        }

        public string Result()
        {
            return "count";
        }
    }
}
