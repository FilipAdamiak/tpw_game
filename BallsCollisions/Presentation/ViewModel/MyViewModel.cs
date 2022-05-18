using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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
            BallsAmount = 5;
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
                    //Ellipses[args.Ball.ID].Radius = args.Ball.Radius;
                }
            };
          
            modelLayer.CallSimulation();
            ToggleSimulationButtons();
        }

        private void ExitClickHandler()
        {
            modelLayer.StopSimulation();
            Ellipses.Clear();
            modelLayer.SetBallAmount(BallsAmount);
            ToggleSimulationButtons();

        }

        public int BallsAmount
        {
            get { return _ballsAmount; }
            set
            {
                _ballsAmount = value;
                OnPropertyChanged();
            }
        }
        public AsyncObservableCollection<VisualBall> BallsGroup
        {   
            get => Ellipses;
            set
            {
                Ellipses = value;
                RaisePropertyChanged("BallsGroup");
            }
        }
        private void ToggleSimulationButtons()
        {
            ClickButton.IsEnabled = !ClickButton.IsEnabled;
            ExitClick.IsEnabled = !ExitClick.IsEnabled;
            if (!ClickButton.IsEnabled && !ExitClick.IsEnabled)
                ExitClick.IsEnabled = !ExitClick.IsEnabled;
      

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

    }
}

