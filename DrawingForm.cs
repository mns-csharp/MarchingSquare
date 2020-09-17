using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace G__Marching_Sqaure
{    
    public partial class DrawingForm : System.Windows.Forms.Form
    {
        public DrawingForm()
        {
            InitializeComponent();
        }

        /*
         * 
           j = yVector = Height = Rows = 5 = Getlength(0)
           i = xVector = Width = Cols = 7 = Getlength(1)  
             
             */

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int height = 500;
            int width = 250;
            double[,] example = new double[height, width];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double example_l = Math.Sin(i / 100.0) * Math.Cos(j / 100.0);
                    example[j, i] = example_l;
                }
            }

            int[] x = new int[width];
            int[] y = new int[height];

            for (int i = 0; i < width; i++)
            {
                x[i] = i;
            }

            for (int j = 0; j < height; j++)
            {
                y[j] = j;
            }

            List<Line> collection = MarchingSquare.marching_square(x, y, example, threshold:0.9);

            Graphics g = this.CreateGraphics();

            Draw rect = new Draw();
            rect.Graphics = g;

            foreach (var item in collection)
            {
                rect.DrawLine(item);
            }
        }
    }
}