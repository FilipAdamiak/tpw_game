using System.Collections.ObjectModel;
using Logic;


namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI()
        {
            return new ModelAPILayer();
        }

        public abstract ObservableCollection<Ball> CreateBalls(int ballsNumber, int radius);
        public abstract void CallSimulation();
        public abstract void StopSimulation();

    }
    public class ModelAPILayer : ModelAbstractAPI
    {
        private readonly LogicApi logicLayer;

        public ModelAPILayer() : this(LogicApi.CreateApi()) { }
        
        public ModelAPILayer(LogicApi logicApi)
        {
            logicLayer = logicApi ?? LogicApi.CreateApi();
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
