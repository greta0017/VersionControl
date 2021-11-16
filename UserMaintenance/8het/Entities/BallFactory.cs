using _8het.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8het.Entities
{
    public class BallFactory : IToyFactory 
    {
        public Color Ballcolor;
        public Toy CreateNew()
        {
            Ball ball = new Ball(Ballcolor);
            return ball;
        }
    }
}
