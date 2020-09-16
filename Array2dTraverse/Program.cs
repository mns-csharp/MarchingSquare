using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2dTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2d = new int[,] 
            {
                { 1,  2,  3,  4,  5,  6,  7},
                { 8,  9, 10, 11, 12, 13, 14},
                {15, 16, 17, 18, 19, 20, 21},
                {22, 23, 24, 25, 26, 27, 28},
                {29, 30, 31, 32, 33, 34, 35},
            };

            int xWidth = array2d.GetLength(1);
            int yHeight = array2d.GetLength(0);

            for (int j = 0; j < yHeight; j++)
            {
                for (int i = 0; i < xWidth; i++)
                {
                    Console.Write(array2d[j, i] + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}
