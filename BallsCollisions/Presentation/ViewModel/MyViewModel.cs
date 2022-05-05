using System.Collections;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        private readonly ModelAbstractAPI modelLayer;
        private readonly int _width;
        private readonly int _height;
        private int _amountOfBalls;
        private IList _balls;

        public MyViewModel() : this(ModelAbstractAPI.CreateModelAPI()) { }

        public MyViewModel(ModelAbstractAPI modelAbstractAPI)
        {
            modelLayer = modelAbstractAPI ?? ModelAbstractAPI.CreateModelAPI();
            _height = modelLayer.Height;
            _width = modelLayer.Width;
            ClickButton = new RelayCommand(() => ClickHandler());
            ExitClick = new RelayCommand(() => ExitClickHandler());
        }
        
        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }
        public int ViewHeight
        {
            get { return _height; }
        }
        public int ViewWidth
        {
            get { return _width; }
        }
        private void ClickHandler()
        {
            BallsGroup = modelLayer.CreateBalls(_amountOfBalls, 25);
            modelLayer.CallSimulation();
        }

        private void ExitClickHandler()
        {
            modelLayer.StopSimulation();
        }

        public int BallsAmount
        {
            get { return _amountOfBalls; }
            set
            {
                _amountOfBalls = value;
                RaisePropertyChanged("Ball Amount");
            }
        }
        public IList BallsGroup
        {
            get => _balls;
            set
            {
                _balls = value;
                RaisePropertyChanged("BallsGroup");
            }
        }

       
    }
}

