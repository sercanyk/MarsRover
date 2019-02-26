using MarsRover.Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Engine.Plateau
{
    public class Dimension : IDimension
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void SetDimension(int width, int height)
        {
            Width = width;
            Height = height;
            CheckDimension();
        }

        private void CheckDimension()
        {
            bool isValid = Width < 0 && Height < 0;
            if (isValid)
                throw new InvalidDimension();
        }
    }
}
