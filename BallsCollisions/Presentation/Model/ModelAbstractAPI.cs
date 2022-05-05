using System.Collections.ObjectModel;
using Logic;


namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI(LogicAbstractAPI logicApi = default(LogicAbstractAPI))
        {
            return new ModelAPILayer(logicApi);
        }

        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract ObservableCollection<Ball> CreateBalls(int ballsNumber, int radius);
        public abstract void CallSimulation();
        public abstract void StopSimulation();
    }
    internal class ModelAPILayer : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI logicLayer;
        public override int Width => logicLayer.Width;
        public override int Height => logicLayer.Height;

        public ModelAPILayer() : this(LogicAbstractAPI.CreateApi()) { }
        
        public ModelAPILayer(LogicAbstractAPI logicApi)
        {
            logicLayer = logicApi ?? LogicAbstractAPI.CreateApi() ;
        }

        public override void CallSimulation()
        {
            logicLayer.RunSimulation();
        }

        public override void StopSimulation()
        {
            logicLayer.StopSimulation();
        }

        public override ObservableCollection<Ball> CreateBalls(int ballsNumber, int radius)
        {
            logicLayer.CreateBalls(ballsNumber, radius);
            return logicLayer.Balls;
        }
    
  

       
    }

}
