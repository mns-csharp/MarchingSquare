using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G__Marching_Sqaure
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(double x1, double y1, double x2, double y2)
        {
            Start = new Point(x1, y1);
            End = new Point(x2, y2);
        }

        public Line(Point p, Point q)
        {
            Start = p;
            End = q;
        }
    }
}
