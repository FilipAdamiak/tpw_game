using System;
using Model;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        public MyViewModel() : this(ModelAbstractApi.Create())
        { }

        public MyViewModel(ModelAbstractApi modelAbstractApi)
        {
            _ballsAmount = modelAbstractApi.BallsAmount;
        }

        private int _ballsAmount;
        public int BallsAmount 
        { 
            get { return _ballsAmount; } 
            set { _ballsAmount = value; OnPropertyChanged(); } 
        }
        
        private bool startSimulation;
        public bool StartSimulation 
        {   
            get { return startSimulation; }
            set { startSimulation = value; OnPropertyChanged(); }
        }
        
        private double rectWidth;
        public double RectWidth
        {
            get { return rectWidth; }
            set { rectWidth = value; }
        }

        private double rectHeight;
        public double RectHeight
        { 
            get { return rectHeight; } 
            set { rectHeight = value; } 
        }




    }
}

