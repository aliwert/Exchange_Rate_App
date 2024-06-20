using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Exchange_Rate_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlfolder = new XmlDocument();
            xmlfolder.Load(today);

            string dollarbuy = xmlfolder.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDllrBuy.Text = dollarbuy;


            string dollarsel = xmlfolder.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDllrSell.Text = dollarsel;


            string eurobuy = xmlfolder.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroBuy.Text = eurobuy;

            string eurosell = xmlfolder.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSell.Text = eurosell;
        }

        private void BtnDollarBuy_Click(object sender, EventArgs e)
        {
            TxtExchangeRate.Text = LblDllrBuy.Text;
        }

        private void BtnDollarSell_Click(object sender, EventArgs e)
        {
            TxtExchangeRate.Text = LblDllrSell.Text;
        }

        private void BtnEuroBuy_Click(object sender, EventArgs e)
        {
            TxtExchangeRate.Text = LblEuroBuy.Text;
        }

        private void BtnEuroSell_Click(object sender, EventArgs e)
        {
            TxtExchangeRate.Text = LblEuroSell.Text;
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            double exchange, amount, sum;
            exchange = Convert.ToDouble(TxtExchangeRate.Text);
            amount = Convert.ToDouble(TxtAmount.Text);
            sum = exchange * amount;
            TxtSum.Text = sum.ToString();
        }

        private void BtnSell2_Click(object sender, EventArgs e)
        {
            double exchange = Convert.ToDouble(TxtExchangeRate.Text);
            int amount = Convert.ToInt32(TxtAmount.Text);
            int sum = Convert.ToInt32(amount / exchange);
            TxtSum.Text = sum.ToString();
            double remainder = amount % exchange;
            TxtReaminder.Text = remainder.ToString();
        }

    }
}
