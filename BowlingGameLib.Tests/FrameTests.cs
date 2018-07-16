using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameLib.Tests
{
    [TestClass]
    public class FrameTests
    {
        private IFrameCreator _frameCreator;
        [TestInitialize]
        public void Init()
        {
            _frameCreator = new StdFrameCreator();
        }

        [TestMethod]
        public void FrameCreator_returning_no_of_frames_provided()
        {
            var rolls = new List<int> { 4, 3, 10, 6, 3 };
            var frames = _frameCreator.Create(rolls, 2);
            Assert.AreEqual(2, frames.Count);
            frames = _frameCreator.Create(rolls, 3);
            Assert.AreEqual(3, frames.Count);
        }

        [TestMethod]
        public void Spare_frame_has_sum_of_2_rolls_as_10()
        {
            var frames = _frameCreator.Create(new List<int> { 4, 6, 3 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsSpare);

            frames = _frameCreator.Create(new List<int> { 1, 1 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(false, frames[0].IsSpare);
        }

        [TestMethod]
        public void Strike_frame_has_1st_roll_as_10()
        {
            var frames = _frameCreator.Create(new List<int> { 10, 6, 3 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsStrike);

            frames = _frameCreator.Create(new List<int> { 1, 1 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(false, frames[0].IsStrike);
        }

        [TestMethod]
        public void Std_frame_have_score_as_sum_of_rolls()
        {
            var frames = _frameCreator.Create(new List<int> { 4, 4 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(8, frames[0].Score);
            
        }

        [TestMethod]
        public void Spare_frame_score_test()
        {
            var frames = _frameCreator.Create(new List<int> { 5, 5, 4 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsSpare);
            Assert.AreEqual(14, frames[0].Score);

        }

        [TestMethod]
        public void Strike_frame_score_test()
        {
            var frames = _frameCreator.Create(new List<int> { 10, 5, 4 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsStrike);
            Assert.AreEqual(19, frames[0].Score);

        }

        [TestMethod]
        public void Strike_is_not_spare_test()
        {
            var frames = _frameCreator.Create(new List<int> { 10, 4, 4 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsStrike);
            Assert.AreEqual(false, frames[0].IsSpare);
        }

        [TestMethod]
        public void Spare_is_not_strike_test()
        {
            var frames = _frameCreator.Create(new List<int> { 5, 5, 4 }, 1);

            Assert.AreEqual(1, frames.Count);
            Assert.AreEqual(true, frames[0].IsSpare);
            Assert.AreEqual(false, frames[0].IsStrike);
        }
    }
}
