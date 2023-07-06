/* 
    3 players 4 cards 4 turns
    Person with Card 0 goes first
    Goal to move by the card with the most points
    First To win 2 Rounds

    Only true if theres a chance of winning, doesnt have to win/ guaranteed of winning
    True if frank makes best moves, everyone else makes worst (DUMB) moves
    if frank is player1, remove best cards from player 2 and 3
    can the following apply twice, if so frank has a chance of winning
    else play the worst move frank can make while winning from player 2 and 3's worst cards
    
    Round1:
    First player has to throw 0 - No chance of Winning first round
    Second player Can throw any card
    Third Sees the card the Second Player Throws - Almost Guaranteed to win first Round as 
    they can see current highest. If Their highest is higher than P2 Lowest
    
    2 - 4 Loops

    Round2:
    First player can play any card
    Second Player Can play any card If Their highest is higher than P1 Lowest, chance to win
    Third Player can see Second Player's Card Chance to win If Their highest is higher than P2 Lowest
    Round3:
    First player can play any card
    Second Player Can play any card If Their highest is higher than P1 Lowest, chance to win
    Third Player can see Second Player's Card Chance to win If Their highest is higher than P2 Lowest
    Round4:
    First player can play any card
    Second Player Can play any card If Their highest is higher than P1 Lowest, chance to win
    Third Player can see Second Player's Card Chance to win If Their highest is higher than P2 Lowest
    
 */

using sample1.Classes;

var game = new CardGame();
var gamesetup = game.SetupGame();
GameResult result;
var players = gamesetup.Players;

do
{
    result = game.PlayTurn(players);
    players = result.ReturnPlayers();
    Console.WriteLine("The Winner Is: " + result.Winner().Name);
} while (players.SingleOrDefault(p => p.IsWinner).TurnsWon < 2);

    Console.WriteLine("The Overall Winner Is: " + result.Winner().Name);

/*var newGame = new Game();
var allPlayers = newGame.SetupGame();
Console.WriteLine (newGame.PlayTurn(allPlayers));
*/

/*
List<int> Frank = new List<int> {2,5,8,11};
List<int> Sam = new List<int> {1,4,7,10};
List<int> Tom = new List<int> {0,3,6,9};
bool frankWin = false;

frankWin = GameOutcome(Frank, Sam, Tom);
Console.WriteLine(frankWin);
 static bool GameOutcome( List<int> Frank, List<int> Sam, List<int> Tom)
{
    int turn = 1;
    int turnswon = 0;
    
    for (int i = 1; i <= 3; i++)
    {
        //frank is player1, Does not win first round
        if (Frank[0] == 0 && turn == 1)
        {
            Frank.Remove(0);
            Sam.Remove(Sam.Max());
            Tom.Remove(Tom.Max());

        }
        else
        {
            //Can frank win this round round, find the smallest card played to still win when sam and tom play worst move possible
            for (int j = 0; j < Frank.Count - 1; j++)
            {
                if (Frank[j] > Sam.Min() && Frank[j] > Tom.Min())
                {
                    Frank.Remove(Frank[j]);
                    turnswon++;
                    break;
                }
            }
            Sam.Remove(Sam.Min());
            Tom.Remove(Tom.Min());
        }
        turn++;
    }
    //if frank has won twice, he wins the game
    if (turnswon >= 2)
    {
        return true;
    }
    else
    {
        return false;
    }
    
}
*/