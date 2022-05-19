using Logic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace ModelTest
{
    public class LogicSimulation : LogicAbstractAPI
    {

        bool IsSimulating = false;
        public override void AddBalls(int amount)
        {
            
        }

        public override int GetBoardHeight()
        {
            return 750;
        }

        public override int GetBoardWidth()
        {
            return 400;
        }

        public override void RunSimulation()
        {
            IsSimulating = true;
        }

        public override void StopSimulation()
        {
            IsSimulating = false;
        }
    }
}