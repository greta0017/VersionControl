﻿using _8het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8het
{
    public partial class Form1 : Form
    {
        List<Ball> _balls = new List<Ball>();

        private BallFactory factory;

        public BallFactory Factory
        {
            get { return factory; }
            set { factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            mainPanel.Controls.Add(ball);
            ball.Left = ball.Width * (-1);
            
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var item in _balls)
            {
                item.MoveBall();
                if (item.Left>maxPosition)
                {
                    maxPosition = item.Left;
                }
            }
            if (maxPosition>1000)
            {
                Ball ba = _balls.First(); //ua-> Ball ba =_balls[0];
                _balls.Remove(ba);
                //form vezérlői - controls, feladat megfogalmazása rossz
                mainPanel.Controls.Remove(ba);
            }
        }
    }
}
