using _8het.Abstractions;
using _8het.Entities;
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
        List<Toy> _toys = new List<Toy>();

        private IToyFactory factory;

        Toy _nextToy;

        public IToyFactory Factory
        {
            get { return factory; }
            set { factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();  //Ezen a ponton a konstruktorban levő BallFactory példányt bármikor átírhatod CarFactory-ra, és akkor labdák helyett autók jelennek majd meg a felületen, de visszaírva továbbra is működni fog a BallFactory is.
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _toys.Add(ball);
            mainPanel.Controls.Add(ball);
            ball.Left = ball.Width * (-1);
            
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var item in _toys)
            {
                item.MoveToy();
                if (item.Left>maxPosition)
                {
                    maxPosition = item.Left;
                }
            }
            if (maxPosition>1000)
            {
                Toy ba = _toys.First(); //ua-> Ball ba =_balls[0];
                _toys.Remove(ba);
                //form vezérlői - controls, feladat megfogalmazása rossz
                mainPanel.Controls.Remove(ba);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
            ((BallFactory)Factory).Ballcolor = button3.BackColor;
        }

        void DisplayNext()
        {
            if (_nextToy != null)
            {
                this.Controls.Remove(_nextToy);
               
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Left = label1.Left + 100;
            _nextToy.Top = label1.Top;
            this.Controls.Add(_nextToy);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Fuchsia;
            Button button = (Button)sender;
            ColorDialog colord = new ColorDialog();
            colord.Color = button3.BackColor;

            if (colord.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = colord.Color;
            }
                   ;


        }
    }
}
