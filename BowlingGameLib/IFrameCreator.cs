using System.Collections.Generic;

namespace BowlingGameLib
{
    public interface IFrameCreator
    {
        List<Frame> Create(List<int> rolls, int noOfFrames);
    }
}