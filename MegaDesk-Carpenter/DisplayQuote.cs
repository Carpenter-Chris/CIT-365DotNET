using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Carpenter
{
    public partial class DisplayQuote : Form
    {
        public DisplayQuote()
        {
            InitializeComponent();
        }

        //reference for sending data from addQuote - https://www.codeproject.com/Articles/14122/Passing-Data-Between-Forms
        public DisplayQuote(string quote)
        {
            InitializeComponent();
            displayQuoteLabel.Text = quote;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();
            Close();
        }

        private void backToAdd_Click(object sender, EventArgs e)
        {
            AddQuote AQ = new AddQuote();
            AQ.Show();
            Close();
        }
    }
}
