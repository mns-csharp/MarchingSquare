﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G__Marching_Sqaure
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
