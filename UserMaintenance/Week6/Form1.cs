using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<decimal> nyereségekRendezve = new List<decimal>();
        public Form1()
        {
            InitializeComponent();
            ticks = port.Tick.ToList();
            dataGridView1.DataSource = ticks; //select * from tick
            CreatePortfolio();

            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            nyereségekRendezve = (from x in Nyereségek  //var nem kell az elejére mert form 1 szinten létrehozva
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
        }

        void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio) //portolion megy végig
            {
                var last = (from x in ticks // ticks táblából kérdez le
                            where item.Index == x.Index.Trim() //trim előtte utána lévő space-ket kivágja
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume; //value t megnövelem az egyenlőség utáni szöveggel
            }
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            if (sav.ShowDialog()==DialogResult.OK)
            {
                
                StreamWriter str = new StreamWriter(sav.FileName);
                str.WriteLine("Időszak;Nyereség");
                for (int i = 0; i < nyereségekRendezve.Count(); i++)
                {
                    str.WriteLine(i+";"+nyereségekRendezve[i]); //x.ik időszak értéke
                }
               

            } 
        }
    }
}
