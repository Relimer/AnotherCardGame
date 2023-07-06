using sample1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1.Classes
{
    public class CardGame
    {
        public CardGame() { }

        public Game SetupGame()
        {
            var game = new Game();

            var frank = new Player() { Name = "Frank", Cards = new List<int>(4), IsFirst = false, IsWinner = false, PlayerTurn = 0, TurnsWon = 0 };
            var sam = new Player() { Name = "Sam", Cards = new List<int>(4), IsFirst = false, IsWinner = false, PlayerTurn = 1, TurnsWon = 0 };
            var tom = new Player() { Name = "Tom", Cards = new List<int>(4), IsFirst = false, IsWinner = false, PlayerTurn = 2, TurnsWon = 0 };
            //var jack = new Player() { Name = "Jack", Cards = new List<int>(4), IsFirst = false, IsWinner = false, PlayerTurn = 3, TurnsWon = 0 };

            var allPlayers = new List<Player>() { frank, sam, tom };

            var cards = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var random = new Random();
            allPlayers.ForEach(p =>
            {
                for (int i = 0; i <= 3; i++)
                {
                    var num = random.Next(cards.Count);
                    var card = cards[num];
                    p.Cards.Add(card);
                    cards.Remove(card);
                    if (card == 0) p.IsFirst = true;
                }
                p.Cards.Sort();
            });
            game.Players = allPlayers;

            return game;
        }

        public GameResult PlayTurn(List<Player> players)
        {
            Player firstPlayer;
            if(players.All(p => p.IsWinner == false))
            {
                firstPlayer = players.SingleOrDefault(p => p.IsFirst == true);
            }
            else
            {
                firstPlayer = players.SingleOrDefault(p => p.IsWinner == true);
                firstPlayer.IsFirst = true;
                firstPlayer.IsWinner = false;
            }
            var secondPlayer = players.SingleOrDefault(p => p.PlayerTurn == (firstPlayer.PlayerTurn + 1) % 3);
            var thirdPlayer = players.SingleOrDefault(p => p.PlayerTurn == (secondPlayer.PlayerTurn + 1) % 3);

            GameResult result = new GameResult(firstPlayer, secondPlayer, thirdPlayer);
                
                var chosenCard = 0;
                var random = new Random();
                if (firstPlayer.Cards.Min() == 0)
                {
                    result.AddThrownCard(0);
                    firstPlayer.Cards.Remove(0);
                }
                else
                {
                    chosenCard = random.Next(0, firstPlayer.Cards.Count);
                    result.AddThrownCard(firstPlayer.Cards[chosenCard]);
                    firstPlayer.Cards.Remove(firstPlayer.Cards[chosenCard]);
                }
                chosenCard = random.Next(0, secondPlayer.Cards.Count);
                result.AddThrownCard(secondPlayer.Cards[chosenCard]);
                secondPlayer.Cards.Remove(secondPlayer.Cards[chosenCard]);


                for (int i = 0; i < thirdPlayer.Cards.Count; i++)
                {
                    if (thirdPlayer.Cards[i] > result.ViewThrownCard(0) && thirdPlayer.Cards[i] > result.ViewThrownCard(1))
                    {
                        thirdPlayer.Cards.Remove(thirdPlayer.Cards[i]);
                        result.EmptyThrownCards();
                        thirdPlayer.TurnsWon++;
                    if(players.SingleOrDefault(p => p.IsWinner == true) != null)
                    {
                        players.SingleOrDefault(p => p.IsWinner == true).IsWinner = false;
                    }
                        thirdPlayer.IsWinner = true;
                        break;
                    }
                }
                if(thirdPlayer.IsWinner == false)
                {
                    thirdPlayer.Cards.Remove(thirdPlayer.Cards.Min());
                }
                if (players.SingleOrDefault(p => p.IsWinner == true) == null)
                {
                    if (result.ViewThrownCard(0) > result.ViewThrownCard(1))
                    {
                        result.EmptyThrownCards();
                        firstPlayer.TurnsWon++;
                    if (players.SingleOrDefault(p => p.IsWinner == true) != null)
                    {
                        players.SingleOrDefault(p => p.IsWinner == true).IsWinner = false;
                    }
                    firstPlayer.IsWinner = true;
                    }
                    else
                    {
                        result.EmptyThrownCards();
                        secondPlayer.TurnsWon++;
                    if (players.SingleOrDefault(p => p.IsWinner == true) != null)
                    {
                        players.SingleOrDefault(p => p.IsWinner == true).IsWinner = false;
                    }
                    secondPlayer.IsWinner = true;
                    }
                }
                if (players.SingleOrDefault(p => p.IsWinner == true).TurnsWon == 2)
                {
                    return result;
                }
                else
                {
                    return result;
                }
        }
    }
}
