using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
         * j = yVector = Height = Rows = 5 = Getlength(0)
         * i = xVector = Width = Cols = 7 = Getlength(1)  
         */

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int height = 256;
            int width = height;
            double resolution = 10;
            double threshold = 0;

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

            /////////////////////SIN-COS/////////////////////////////
            //threshold = 0.9;
            //double[,] example = new double[height, width];
            //for (int j = 0; j < height; j++)
            //{
            //    for (int i = 0; i < width; i++)
            //    {
            //        double example_l = Math.Sin(i / resolution) * Math.Cos(j / resolution);
            //        example[j, i] = example_l;
            //    }
            //}
            /////////////////////SIN-COS/////////////////////////////


            ///////////////////////CSV////////////////////////
            threshold = 0.5;
            string[,] data = CSV_ToArray("data.csv", ",");
            height = data.GetLength(0);
            width = data.GetLength(1);
            double[,] example = new double[height, width];
            example = ToDouble(data);
            ///////////////////////CSV////////////////////////

            List<Line> collection = MarchingSquare.marching_square(x, y, example, threshold);

            Graphics g = this.CreateGraphics();

            Draw rect = new Draw();
            rect.Graphics = g;

            foreach (var item in collection)
            {
                rect.DrawLine(item);
            }
        }

        public string[,] CSV_ToArray(string path, string separator = ";")
        {
            // check if the file exists
            if (!File.Exists(path))
                throw new FileNotFoundException("The CSV specified was not found.");

            // temporary list to store information
            List<string[]> temp = new List<string[]>();

            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                while (!reader.EndOfStream)
                {
                    // read the line
                    string line = reader.ReadLine();

                    // if you need to give some changes on the inforation
                    // do it here!
                    string[] values = line.Split(separator.ToCharArray());

                    // add to the temporary list
                    temp.Add(values);
                }
            }

            // convert te list to array, which it will be a string[][]
            return ImperativeConvert(temp.ToArray());
        }

        string[,] ImperativeConvert(string[][] source)
        {
            string[,] result = new string[source.Length, source[0].Length];

            for (int i = 0; i < source.Length; i++)
            {
                for (int k = 0; k < source[0].Length; k++)
                {
                    result[i, k] = source[i][k];
                }
            }

            return result;
        }

        /*
         * j = yVector = Height = Rows = 5 = Getlength(0)
         * i = xVector = Width = Cols = 7 = Getlength(1)  
         */
        double[,] ToDouble(string[,]data)
        {
            int height = data.GetLength(0);
            int width = data.GetLength(1);

            double[,] exxx = new double[height, width];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    exxx[j, i] = Convert.ToDouble(data[j, i]); 
                }
            }

            return exxx;
        }
    }
}