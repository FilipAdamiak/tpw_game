using Model;

namespace ViewModel
{
    public class MyViewModel : ViewModelBase    
    {

        private ModelAPILayer modelLayer;
        private int _ballsAmount;

        public AsyncObservableCollection<VisualBall> Ellipses { get; set; }
        public MyViewModel()
        {
            Ellipses = new AsyncObservableCollection<VisualBall>();
            modelLayer = new ModelAPILayer();
            BallsAmount = 0;
            ClickButton = new RelayCommand(() => ClickHandler());
            ExitClick = new RelayCommand(() => ExitClickHandler());
        }
        
        public ISimplyCommand ClickButton { get; set; }
        public ISimplyCommand ExitClick { get; set; }
        public int ViewHeight
        {
            get { return modelLayer.GetHeight(); }
        }
        public int ViewWidth
        {
            get { return modelLayer.GetWidth(); }
        }
        private void ClickHandler()
        {
            modelLayer.SetBallAmount(_ballsAmount);

            for (var i = 0; i < BallsAmount; i++)
            {
                Ellipses.Add(new VisualBall());
            }

            modelLayer.BallPositionChange += (sender, args) =>
            {
                if (Ellipses.Count <= 0) return;

                for (var i = 0; i < _ballsAmount; i++)
                { 
                    Ellipses[args.Ball.ID].Position = args.Ball.Position;
                }
            };
          
            modelLayer.CallSimulation();
            SwitchOnOffButtons();
        }

        private void ExitClickHandler()
        {
            modelLayer.StopSimulation();
            Ellipses.Clear();
            modelLayer.SetBallAmount(BallsAmount);
            SwitchOnOffButtons();
        }

        public int BallsAmount
        {
            get { return _ballsAmount; }
            set
            {
                _ballsAmount = value;
                RaisePropertyChanged();
            }
        }
        public AsyncObservableCollection<VisualBall> BallsGroup
        {   
            get => Ellipses;
            set
            {
                Ellipses = value;
                RaisePropertyChanged();
            }
        }
        private void SwitchOnOffButtons()
        {
                ClickButton.IsEnabled = !ClickButton.IsEnabled;
                ExitClick.IsEnabled = !ExitClick.IsEnabled;
                if (!ClickButton.IsEnabled && !ExitClick.IsEnabled)
                    ExitClick.IsEnabled = !ExitClick.IsEnabled;
        }
    }
}

