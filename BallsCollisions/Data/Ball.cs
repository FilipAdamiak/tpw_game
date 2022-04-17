using System;

namespace Data
{
    public class Ball 
    {
        private int _x;
        private int _y;
        private double _radius;

        public Ball() { }

        public Ball(int x, int y, double radius)
        {
            _x = x; 
            _y = y;
            _radius = radius;
        }

        public int X
        { 
            get { return _x; } 
            set { _x = value; } 
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Radius
        { 
            get { return _radius; } 
            set { _radius = value; } 
        }

    }
}
