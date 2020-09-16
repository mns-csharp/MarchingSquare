using System;
using System.Collections.Generic;

namespace G__Marching_Sqaure
{
    public class MarchingSquare
    {
        public static List<Line> marching_square(int[] xVector, int[] yVector, double[,] Data, int threshold)
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

                        double a = Data[j + 1, i];
                        double b = Data[j + 1, i + 1];
                        double c = Data[j, i + 1];
                        double d = Data[j, i];

                        squares[j,i].A_data = a;//A
                        squares[j,i].B_data = b;//B
                        squares[j,i].C_data = c;//C
                        squares[j,i].D_data = d;// D

                        Point A = new Point(xVector[i], yVector[j + 1]);//A
                        Point B = new Point(xVector[i + 1], yVector[j + 1]);//B
                        Point C = new Point(xVector[i + 1], yVector[j]);//C
                        Point D = new Point(xVector[i], yVector[j]);//D

                        squares[j,i].SetA(A);
                        squares[j,i].SetB(B);
                        squares[j,i].SetC(C);
                        squares[j,i].SetD(D);

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
