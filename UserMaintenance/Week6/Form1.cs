using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week6.Entities;

namespace Week6
{
    public partial class Form1 : Form
    {
        List<Tick> ticks;
        PortfolioEntities port = new PortfolioEntities();
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();

        public Form1()
        {
            InitializeComponent();
            ticks = port.Tick.ToList();
            dataGridView1.DataSource = ticks; //select * from tick
            CreatePortfolio();
        }

        void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
    }
}
