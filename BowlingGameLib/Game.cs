using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameLib
{
    public class Game
    {
        private List<int> _rollList;
        private List<Frame> _frameList;
        private int _noOfFrames;
        private IFrameCreator _frameCreator;

        public Game(int noOfFrames)
        {
            _rollList = new List<int>();
            _frameList = new List<Frame>();
            _noOfFrames = noOfFrames;
            _frameCreator = new StdFrameCreator(); //can use reflection or config manager to load frame creator dynamically
        }

        public void Roll(int pins)
        {
            _rollList.Add(pins);
        }

        public int GetScore()
        {
            _frameList = _frameCreator.Create(_rollList, _noOfFrames);
            return _frameList.Sum(f => f.Score);
        }
    }
}