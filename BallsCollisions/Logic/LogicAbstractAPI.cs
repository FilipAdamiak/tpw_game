using System.Numerics;
using System.Collections.ObjectModel;
using Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateApi( DataAbstractAPI dataAbstractAPI = default(DataAbstractAPI))
        {
            dataAbstractAPI = DataAbstractAPI.CreateDataAPI();
            return new LogicAPI(dataAbstractAPI);
        }
        public abstract void RunSimulation();
        public abstract void StopSimulation();
        public abstract void AddBalls(int amount);

        public event EventHandler<LogicEventArgs> ChangedPosition;
        protected void OnPositionChange(LogicEventArgs args)
        {
            ChangedPosition?.Invoke(this, args);
        }
        public abstract int GetBoardWidth();
        public abstract int GetBoardHeight();
       

    }
}
