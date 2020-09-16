using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G__Marching_Sqaure
{
    public static class StaticRandomNumber
    {
        private static Random rnd = new Random();
        public static int GetRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
