using System.Drawing;
using System.Windows.Forms;

namespace G__Marching_Sqaure
{
    public class Draw
    {
        public Graphics Graphics { get; set; }
        public Color Color { get; set; }
        public Pen Pen { get; set; }
        public int Thickness { get; set; }

        public Draw()
        {
            Color = Color.Blue;
            Thickness = 2;
            Pen = new Pen(Color, Thickness);
        }

        public void DrawLine(Line line)
        {
            Graphics.DrawLine(Pen, (float)line.Start.X, (float)line.Start.Y, (float)line.End.X, (float)line.End.Y);
        }
    }
}
