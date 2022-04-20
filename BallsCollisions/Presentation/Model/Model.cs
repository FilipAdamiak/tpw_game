using System;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI()
        {
            return new ModelAPILayer();
        }
    }
    public class ModelAPILayer : ModelAbstractAPI
    {
        public static void Main()
        {
            Logic.LogicAbstractAPI logicAbstractAPI = Logic.LogicAbstractAPI.CreateLogicAPI(Data.DataAbstractAPI.CreateDataAPI());
            Logic.Board board = logicAbstractAPI.CreateBoard(500, 400, 10);

            for (int i = 0; i < board._balls.Count; i++)
            {
                System.Console.WriteLine("Ball " + i.ToString());
                System.Console.WriteLine(board._balls[i].X);
                System.Console.WriteLine(board._balls[i].Y);
                System.Console.WriteLine(board._balls[i].Radius);
            }
        }
    }

}
