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
            double[,] example = new double[,] {
                                                
                                                { 0,0, 0, 0, 0, 0,0 },
                                                { 0,0, 0, 1, 1, 0,0 },
                                                { 0,0, 0, 1, 1, 0,0 },
                                                { 0,0, 0, 0, 1, 0,0 },
                                                { 0,0, 0, 0, 0, 0,0 }};

            int[] x = new int[] {0, 50, 100, 150, 200, 250, 300};
            int[] y = new int[] {0, 50, 100, 150, 200 };

            List<Line> collection = MarchingSquare.marching_square(x, y, example, threshold:2);

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