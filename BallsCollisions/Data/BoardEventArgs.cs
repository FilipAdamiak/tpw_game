using System;
using System.Collections.ObjectModel;


namespace Data
{
    public class BoardEventArgs : EventArgs
    {
        public readonly ObservableCollection<BallEntity> Balls;
        public readonly BallEntity sender;
        public BoardEventArgs(ObservableCollection<BallEntity> balls, BallEntity senderBall)
        {
            this.Balls = balls;
            this.sender = senderBall;
        }
    }
}
