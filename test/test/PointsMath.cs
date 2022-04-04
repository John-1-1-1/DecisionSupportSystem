using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class PointsMath
    {

        public static double LenSegment(Node g, Point point)
        {
            return Math.Sqrt(
                Math.Pow(g.x - point.X, 2) +
                Math.Pow(g.y - point.Y, 2));
        }
        
    }
}
