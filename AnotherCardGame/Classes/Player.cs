using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1.Classes
{
    public class Player
    {
        public string Name { get; set; }

        public List<int> Cards { get; set; }

        public bool IsFirst { get; set; }

        public bool IsWinner { get; set; }
        public int PlayerTurn { get; set; }
        public int TurnsWon { get; set; }
        
    }
}
