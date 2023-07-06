using FluentAssertions;
using sample1.Classes;
using sample1.Interfaces;
using System.Collections.Generic;

namespace AnotherCardGameTests
{
    public class GameTests
    {
        private List<Player> players;

        public GameTests()
        {
            var frank = new Player() { Name = "Frank", Cards = new List<int>(4) { 3,7,5, 10 }, IsFirst = false, IsWinner = false, PlayerTurn = 0, TurnsWon = 0 };
            var sam = new Player() { Name = "Sam", Cards = new List<int>(4) { 0,2 ,6, 9 }, IsFirst = true, IsWinner = false, PlayerTurn = 1, TurnsWon = 0 };
            var tom = new Player() { Name = "Tom", Cards = new List<int>(4) { 1, 4, 8, 11 }, IsFirst = false, IsWinner = false, PlayerTurn = 2, TurnsWon = 0 };

            players = new List<Player>() {  frank, sam, tom };
        }

        [Fact]
        public void SetupGame_Should_Be_Return_Type_Game()
        {
            var newGame = new CardGame();

            var game = newGame.SetupGame();
            
            game.Should().BeOfType<Game>();
        }

        [Fact]
        public void SetupGame_Should_Contain_Three_Players()
        {
            var newGame = new CardGame();

            var game = newGame.SetupGame();

            game.Players.Should().HaveCount(3);
        }

        [Fact]
        public void SetupGame_Should_Contain_1_Player_Who_Starts_First()
        {
            var newGame = new CardGame();

            var game = newGame.SetupGame();

            game.Players.Count(x => x.IsFirst == true).Should().Be(1);
        }

        [Fact]
        public void SetupGame_Should_Contain_Cards_In_Asc_Order()
        {
            var newGame = new CardGame();

            var game = newGame.SetupGame();

            game.Players.FirstOrDefault().Cards.Should().BeInAscendingOrder();
        }

        [Fact]
        //[InlineData(List<Player> players = new List<Player>() { })]
        //[InlineData(List < Player > players = new List<Player>() { })]
        public void PlayTurn_FirstPlayer_Has_Zero_ThrownCards_Contains_Zero()
        {
            var newGame = new CardGame();

            var game = newGame.PlayTurn(players);
            game.ReturnPlayers().SingleOrDefault(p => p.IsFirst).Cards[0].Should().NotBe(0);

        }

        
    }
}