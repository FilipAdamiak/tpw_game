using System.Collections;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        private readonly ModelAbstractAPI modelLayer;
        private int _amountOfBalls;
        private IList _balls;

        public MyViewModel() : this(ModelAbstractAPI.CreateModelAPI()) { }

        public MyViewModel(ModelAbstractAPI modelAbstractAPI)
        {
            modelLayer = modelAbstractAPI ?? ModelAbstractAPI.CreateModelAPI();
            ClickButton = new RelayCommand(() => ClickHandler());
            ExitClick = new RelayCommand(() => ExitClickHandler());
        }
        
        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }

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

