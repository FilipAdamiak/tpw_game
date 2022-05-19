using System;
using Logic;

namespace Model
{
   
    public class ModelAPILayer
    {
        private LogicAbstractAPI logicLayer;
      
        public int ballsAmount;
        public ModelAPILayer()
        {
            logicLayer = LogicAbstractAPI.CreateApi();
            ballsAmount = 0;
            logicLayer.ChangedPosition += OnBallsLogicOnPositionChange;
        }
        public event EventHandler<ModelEventArgs> BallPositionChange;

        private void OnBallsLogicOnPositionChange(object sender, LogicEventArgs args)
        {
            BallPositionChange?.Invoke(this, new ModelEventArgs(new ModelBall(args.Ball)));
        }
        public void CallSimulation()
        {
            logicLayer.AddBalls(ballsAmount);
            logicLayer.RunSimulation();
        }
        public void StopSimulation()
        {
            logicLayer.StopSimulation();
            logicLayer = LogicAbstractAPI.CreateApi();
            logicLayer.ChangedPosition += OnBallsLogicOnPositionChange;
        }
        public void SetBallAmount(int amount)
        {
            ballsAmount = amount;
        }
        public int GetBallAmount()
        {
            return ballsAmount;
        }
        public int GetWidth()
        {
            return logicLayer.GetBoardWidth();
        }
        public int GetHeight()
        {
            return logicLayer.GetBoardHeight();
        }
        

    }

}
