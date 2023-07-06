using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1.Classes
{
    public class GameResult
    {
        Player firstPlayer { get; set; }
        Player secondPlayer { get; set; }
        Player thirdPlayer { get; set; }
        List<Player> players { get; set; }
        List<int> thrownCards { get; set; }
        public GameResult(Player FirstP, Player SecondP, Player ThirdP)
        {
            firstPlayer = FirstP;
            secondPlayer = SecondP;
            thirdPlayer = ThirdP;
            players = new List<Player> { FirstP, SecondP, ThirdP }; 
            thrownCards = new List<int>();

        }
        public List<Player> ReturnPlayers()
        {
            return players;
        }
        public void AddThrownCard(int cardnumber)
        {
            thrownCards.Add(cardnumber);
        }
        public int ViewThrownCard(int cardpoition)
        {
            return thrownCards[cardpoition];
        }
        public void EmptyThrownCards()
        {
            thrownCards.Clear();
        }
        public Player Winner()
        {
            return players.SingleOrDefault(p => p.IsWinner == true);
        }
    }
}
