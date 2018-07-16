using System.Collections.Generic;

namespace BowlingGameLib
{
    public class StdFrameCreator : IFrameCreator
    {
        private List<Frame> _frames;

        public StdFrameCreator()
        {
            
        }

        public List<Frame> Create(List<int> rolls, int noOfFrames)
        {
            _frames = new List<Frame>();
            for (int frameCnt = 0, rollCnt = 0; frameCnt < noOfFrames; frameCnt++)
            {
                var frame = new Frame();
                frame.Rolls.Add(rolls[rollCnt]);
                if (!frame.IsStrike)
                {
                    frame.Rolls.Add(rolls[rollCnt + 1]);
                    if (frame.IsSpare)
                    {
                        frame.Rolls.Add(rolls[rollCnt + 2]);
                        rollCnt = rollCnt + 2;
                    }
                    else
                    {
                        rollCnt = rollCnt + 2;
                    }
                }
                else
                {
                    frame.Rolls.AddRange(rolls.GetRange(rollCnt + 1, 2));
                    rollCnt++;
                }

                _frames.Add(frame);
            }

            return _frames;
        }
    }
}