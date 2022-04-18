using System;
using Model;
using System.Windows.Input;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        public MyViewModel() : this(ModelAbstractApi.Create())
        { }

        public ICommand ButtonClicked { get; set; }

        public MyViewModel(ModelAbstractApi modelAbstractApi)
        {
            ButtonClicked = new RelayCommand(() => ClickHandle());
            BallsAmount = "0";
        }

        public void ClickHandle() { }

        private string _ballsAmount;
        public string BallsAmount 
        { 
            get { return _ballsAmount; } 
            set { _ballsAmount = value; OnPropertyChanged(); } 
        }
        
        private bool _startSimulation;
        public bool StartSimulation 
        {   
            get { return _startSimulation; }
            set { _startSimulation = value; OnPropertyChanged(); }
        }
        
        private int _rectWidth;
        public int RectWidth
        {
            get { return _rectWidth; }
            set { _rectWidth = value; }
        }

        private int _rectHeight;
        public int RectHeight
        { 
            get { return _rectHeight; } 
            set { _rectHeight = value; } 
        }

    }
}

