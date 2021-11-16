﻿using _8het.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8het.Entities
{

    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        public Ball(Color szin)
        {
            BallColor = new SolidBrush(szin);
        }
      
        public override void DrawImage(Graphics graph) 
        {
            graph.FillEllipse(BallColor, 0, 0, Width, Height);
        }

   
    }
}
