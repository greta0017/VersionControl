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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Fajlbutton;
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                FullName = textbox1.Text,
                
            };
            users.Add(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            if (sav.ShowDialog()==DialogResult.OK)
            {
                // label1.Text=sav.FileName;
                StreamWriter str = new StreamWriter(sav.FileName);
               
                foreach (var user in users)
                {
                    str.WriteLine(user.ID.ToString() +";"+user.FullName.ToString()) ;
                }
                str.Close();
            }


            
        }
    }
}
