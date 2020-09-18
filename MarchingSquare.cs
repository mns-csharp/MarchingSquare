using System;
using System.Collections.Generic;

namespace G__Marching_Sqaure
{
    public class MarchingSquare
    {
        public static List<Line> marching_square(int[] xVector, int[] yVector, double[,] Data, double threshold)
        {
            List<Line> linesList = new List<Line>();

            int Height = Data.GetLength(0);//rows count
            int Width = Data.GetLength(1);//cols count

            if (Width == xVector.Length && Height == yVector.Length)
            {
                Square[,] squares = new Square[Height - 1, Width - 1];

                int sqHeight = squares.GetLength(0);//rows count
                int sqWidth = squares.GetLength(1);//cols count

                for (int j = 0; j < sqHeight; j++)//rows
                {
                    for (int i = 0; i < sqWidth; i++)//cols
                    {
                        squares[j,i] = new Square();

                        double a = Data[j, i];
                        double b = Data[j, i + 1];
                        double c = Data[j + 1, i + 1];
                        double d = Data[j + 1, i];

                        Point A = new Point(xVector[j], yVector[i]);//A
                        Point B = new Point(xVector[j], yVector[i + 1]);//B
                        Point C = new Point(xVector[j + 1], yVector[i+1]);//C
                        Point D = new Point(xVector[j+1], yVector[i]);//D

                        squares[j,i].A_data = a;//A
                        squares[j,i].B_data = b;//B
                        squares[j,i].C_data = c;//C
                        squares[j,i].D_data = d;// D

                        squares[j,i].A = A;
                        squares[j,i].B = B;
                        squares[j,i].C = C;
                        squares[j,i].D = D;

                        IEnumerable<Line> list = squares[j,i].GetLines(threshold);

                        linesList.AddRange(list);
                    }
                }
            }
            else
            {
                throw new Exception("dimension mismatch!");
            }

            return linesList;
        }
    }
}
