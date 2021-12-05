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
using Tizedik.Entities;

namespace Tizedik
{
    public partial class Form1 : Form
    {

        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        List<int> ferfiak = new List<int>();
        List<int> nok = new List<int>();

        Random random = new Random(1234);

        public Form1()
        {
            InitializeComponent();

            Population = Elso(@"C:\Temp\nép.csv");
            BirthProbabilities = Masodik(@"C:\Temp\születés.csv");
            DeathProbabilities = Harmadik(@"C:\Temp\halál.csv");

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public List<Person> Elso(string a)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(a, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> Masodik(string a)
        {
            List<BirthProbability> population = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(a, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return population;
        }
        public List<DeathProbability> Harmadik(string a)
        {
            List<DeathProbability> population = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(a, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public void Evek()
        {
            richTextBox1.Clear();
            ferfiak.Clear();
            nok.Clear();

            for (int ev = 2005; ev < numericUpDown1.Value; ev++)
            {
                for (int nep = 0; nep < Population.Count(); nep++)
                {
                    SimStep(ev, Population[nep]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();

                ferfiak.Add(nbrOfMales);
                nok.Add(nbrOfFemales);
               

               // Console.WriteLine(
                //string.Format("Év:{0} Fiúk:{1} Lányok:{2}", ev, nbrOfMales, nbrOfFemales));
            }

            DisplayResults();
        }

        public void SimStep(int ev, Person p)
        {
            

            if (p.IsAlive == false) return;
            int kora = ev - p.BirthYear;

            double halal = (from x in DeathProbabilities
                            where x.Age==kora
                            select x.P).FirstOrDefault();

            
            if (random.NextDouble()<halal)
            {
                p.IsAlive = false;
                return;
            }
            if (p.Gender == Gender.Male) return;

            double szulet =(from x in BirthProbabilities
                            where x.Age == kora
                            select x.P).FirstOrDefault();

            if (random.NextDouble()<szulet)
            {
                Person uj = new Person();

                uj.BirthYear = ev;
                uj.IsAlive = true;
                uj.NbrOfChildren = 0;
                uj.Gender = (Gender)random.Next(1, 3);

                Population.Add(uj);
            }
            
        }

        public void DisplayResults()
        {
            for (int i =2005; i < numericUpDown1.Value; i++)
            {
                int szamlalo = i - 2005;

                richTextBox1.Text += "Szimulációs év: " + i + "\n" +
                    "\t" + ferfiak[szamlalo] + "\n" +
                    "\t" + nok[szamlalo] + "\n";

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Evek();
        }
    }
}
