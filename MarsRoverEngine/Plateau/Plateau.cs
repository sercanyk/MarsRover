using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Plateau
{
    public class Plateau : IPlateau
    {
        IDimension _dimension;

        public Plateau(IDimension dimension)
        {
            _dimension = dimension;
        }

        public void SetSize(int x, int y)
        {
            _dimension.SetDimension(x, y);
        }

        public IDimension GetSize()
        {
            return _dimension;
        }
    }
}
