﻿using _6Het.Entities;
using _6Het.MnbServiceReference;
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
using System.Xml;

namespace _6Het
{
    public partial class Form1 : Form
    {


        BindingList<RateData> Rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();
            string xmlstring= Consume();
            LoadXml(xmlstring);
            dataGridView1.DataSource = Rates;

        }

      
        void LoadXml( string input)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(input);
            foreach(XmlElement item in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date = DateTime.Parse(item.GetAttribute("date"));
                Rates.Add(r);
            }
        }


        string Consume()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();
            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";
            var response= mnbService.GetExchangeRates(request);
            string result= response.GetExchangeRatesResult;
            return result;
        }
    }
}
