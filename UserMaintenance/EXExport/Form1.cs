using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace EXExport
{
    public partial class Form1 : Form
    {
        
        List<Flat> li; 
        RealEstateEntities real = new RealEstateEntities();  //példányosítás
          

        public Form1()
        {
            InitializeComponent();
            // Console.WriteLine(li.Count);
            // li = new List<Flat>(); //zárójel!!!

            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void LoadData()
        {
            li = real.Flats.ToList();
        }

    }
}
