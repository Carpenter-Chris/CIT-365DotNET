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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        //reference for navigation buttons - https://www.c-sharpcorner.com/code/3700/form-navigation-in-c-sharp-windows-form-application.aspx
        private void addQuoteButton_Click(object sender, EventArgs e)
        {
            /*
            AddQuote AQ = new AddQuote();
            AQ.Show();
            this.Hide();
            */
            AddQuote AQ = new AddQuote();
            AQ.Tag = this;
            AQ.Show(this);
            Hide();
        }

        private void viewQuotesButton_Click(object sender, EventArgs e)
        {
            ViewAllQuotes VAQ = new ViewAllQuotes();
            VAQ.Tag = this;
            VAQ.Show(this);
            Hide();
        }

        private void searchQuotesButton_Click(object sender, EventArgs e)
        {
            SearchQuotes SQ = new SearchQuotes();
            SQ.Tag = this;
            SQ.Show(this);
            Hide();
        }

        //exit button reference - https://stackoverflow.com/questions/9586664/using-exit-button-to-close-a-winform-program
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
