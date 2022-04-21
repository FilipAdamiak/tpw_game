using System;
using Model;
using System.Windows.Input;
using System.Collections;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        private readonly ModelAbstractAPI modelLayer = ModelAbstractAPI.CreateModelAPI();
        private readonly int _width;
        private readonly int _height;
        private int _amountOfBalls;
        private IList _balls;

        public MyViewModel() : this(ModelAbstractAPI.CreateModelAPI()) { }

        public MyViewModel(ModelAbstractAPI modelAbstractAPI)
        {
            modelLayer = modelAbstractAPI;
            _height = modelLayer.Height;
            _width = modelLayer.Width;
            ClickButton = new RelayCommand(() => ClickHandler());
            BallsGroup = modelLayer.Balls(_amountOfBalls);
        }
        

        public int ViewHeight
        {
            get { return _height; }
        }
        public int ViewWidth
        {
            get { return _width; }
        }

        public ICommand ClickButton { get; set; }
        private void ClickHandler()
        {
            modelLayer.Balls(_amountOfBalls);
            //Begin simulation
            
        }

        public int BallsAmount
        {
            get { return _amountOfBalls; }
            set
            {
                _amountOfBalls = value;
                
            }
        }
        public IList BallsGroup { get => _balls; set
            {
                _balls = value;

            } }

    }
}

