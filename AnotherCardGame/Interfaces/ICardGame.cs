using sample1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1.Interfaces
{
    public interface ICardGame
    {
        public Game SetupGame();
        public string PlayTurn(List<Player> players);
    }
}
