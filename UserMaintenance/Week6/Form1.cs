﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6
{
    public partial class Form1 : Form
    {
        List<Tick> ticks;
        PortfolioEntities port = new PortfolioEntities();
        public Form1()
        {
            InitializeComponent();
            ticks = port.Tick.ToList();
            dataGridView1.DataSource = ticks; //select * from tick

        }
    }
}
