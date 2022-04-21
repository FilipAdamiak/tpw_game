using System.Collections.ObjectModel;
using System;
using Logic;
using System.Collections.Generic;
using Data;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI()
        {
            return new ModelAPILayer();
        }

        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract ObservableCollection<Ball> Balls(int balls);
        public abstract void CallSimulation();
        public abstract void StopSimulation();

    }
    public class ModelAPILayer : ModelAbstractAPI
    {
        private Board board = new Board();
        private LogicAbstractAPI logicLayer = LogicAbstractAPI.CreateLogicAPI(DataAbstractAPI.CreateDataAPI());

        public override int Width => Board._boardWidth;
        public override int Height => Board._boardHeight;

        public override void CallSimulation()
        {
            logicLayer.RunSimulation(board);
        }

        public override void StopSimulation()
        {
            logicLayer.StopSimulation(board);
        }

        public override ObservableCollection<Ball> Balls(int amount)
        {
            board.CreateBalls(amount);
            return board._balls;
        }

       
    }

}
