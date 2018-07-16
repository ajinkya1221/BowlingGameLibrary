using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameLib.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game _game;
        [TestInitialize]
        public void Init()
        {
            _game = new Game(10);
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            Roll(_game, 0, 20);
            Assert.AreEqual(0, _game.GetScore());
        }

        [TestMethod]
        public void Random_roll_without_spare_or_strike()
        {
            Roll(_game, 3, 20);
            Assert.AreEqual(60, _game.GetScore());
        }

        [TestMethod]
        public void Single_spare_game()
        {
            _game.Roll(4);
            _game.Roll(4);
            _game.Roll(5);
            _game.Roll(5);
            Roll(_game, 3, 16);
            Assert.AreEqual(69, _game.GetScore());
        }

        [TestMethod]
        public void Single_strike_game()
        {
            _game.Roll(4);
            _game.Roll(4);
            _game.Roll(10);
            Roll(_game, 3, 16);
            Assert.AreEqual(72, _game.GetScore());
        }

        [TestMethod]
        public void Last_roll_as_spare_game()
        {
            Roll(_game, 3, 18);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(4);
            Assert.AreEqual(68, _game.GetScore());
        }

        [TestMethod]
        public void Last_roll_as_strike_game()
        {
            Roll(_game, 3, 18);
            _game.Roll(10);
            _game.Roll(4);
            _game.Roll(4);
            Assert.AreEqual(72, _game.GetScore());
        }

        [TestMethod]
        public void Perfect_game()
        {
            Roll(_game, 10, 12);
            Assert.AreEqual(300, _game.GetScore());
        }
    }
}
