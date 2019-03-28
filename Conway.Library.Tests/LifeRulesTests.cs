using System;
using NUnit.Framework;
using Conway.Library;

namespace Conway.Library.Tests
{
    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbours_Dies([Values (0,1)] int liveNeighbours)
        {
            var currentState = CellState.Alive;
            
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void LiveCell_2Or3LiveNeighbours_Lives([Values(2, 3)] int liveNeighbours)
        {
            var currentState = CellState.Alive;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Alive, newState);
        }
        [Test]
        public void LiveCell_MoreThan3LiveNeighbours_Dies([Range(4,8)] int liveNeighbours)
        {
            var currentState = CellState.Alive;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_Exactly3LiveNeighbours_Lives()
        {
            var currentState = CellState.Dead;
            int liveNeighbours = 3;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Alive, newState);
        }
        [Test]
        public void DeadCell_Fewer3LiveNeighbours_StaysDead([Range(0,2)] int liveNeighbours)
        {
            var currentState = CellState.Dead;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void DeadCell_MoreThan3LiveNeighbours_StaysDead([Range(4,8)] int liveNeighbours)
        {
            var currentState = CellState.Dead;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);

            Assert.AreEqual(CellState.Dead, newState);
        }
    }
}
