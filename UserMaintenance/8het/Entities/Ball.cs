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
      
        public override void DrawImage(Graphics graph) 
        {
            graph.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

   
    }
}
