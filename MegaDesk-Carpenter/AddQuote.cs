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
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MainMenu MM = (MainMenu)Tag;
            MM.Show();
            Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_validating(object sender, CancelEventArgs e)
        {
           
        }

        private void lastNameBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        //controls the type of chars that can be used in this textbox reference - https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
        private void widthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
           
        }

        private void depthBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        //controls the type of chars that can be used in this textbox
        private void depthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void drawersBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void surfaceOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void shippingOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void submitQuoteButton_Click(object sender, EventArgs e)
        {
            
            string firstName;
            firstName = firstNameBox.Text;
            
            string lastName;
            lastName = lastNameBox.Text;

            float width = float.Parse(widthBox.Text);
            float depth = float.Parse(depthBox.Text);
            int drawers = int.Parse(drawersBox.Text);
            int surfaceIndex = surfaceOptionsBox.SelectedIndex;
            int shippingIndex = shippingOptionsBox.SelectedIndex;
            float surfaceArea = width * depth;

            //check if first name field is filled in
            if (string.IsNullOrWhiteSpace(firstNameBox.Text))
            {
                MessageBox.Show("Oops you forgot to enter a first Name!");
                return;
            }
            //check if last name field is filled in
            if (string.IsNullOrWhiteSpace(lastNameBox.Text))
            {
                MessageBox.Show("Oops you forgot to enter a last Name!");
                return;
            }
            //check if width field is filled in
            if (string.IsNullOrWhiteSpace(widthBox.Text))
            {
                MessageBox.Show("Oops you forgot to enter a last Name!");
                return;
            }
            if (!float.TryParse(widthBox.Text, out width))
            {
                MessageBox.Show("Oops you forgot to enter a width!");
                return;
            }
            //check if depth field is filled in
            if (!float.TryParse(depthBox.Text, out depth))
            {
                MessageBox.Show("Oops you forgot to enter a depth!");
                return;
            }
            //check if drawers field is filled in
            if (!int.TryParse(drawersBox.Text, out drawers))
            {
                MessageBox.Show("Oops you forgot to enter how many drawers!");
                return;
            }
            //check if surface field is filled in
            if (string.IsNullOrWhiteSpace(surfaceOptionsBox.Text))
            {
                MessageBox.Show("Oops you forgot to enter a surface material!");
                return;
            }
            //check if shipping field is filled in
            if (string.IsNullOrWhiteSpace(shippingOptionsBox.Text))
            {
                MessageBox.Show("Oops you forgot to enter a shipping option!");
                return;
            }

            /*
            try
            {
                int.Parse(widthBox.Text);
            }
            catch
            {
                MessageBox.Show("numbers only.");
            }
            */

            Desk newDesk = new Desk(width, depth, drawers, surfaceIndex);
            DeskQuote newDeskQuote = new DeskQuote(newDesk, firstName, lastName, surfaceArea,shippingIndex);

            string quote = "$" + newDeskQuote.Quote();
            //displayQuoteLabel.Text = "$" + newDeskQuote.Quote();
           //testSurfacelabel.Text = "$" + newDeskQuote.PriceSurface();

            DisplayQuote DQ = new DisplayQuote(/*displayQuoteLabel.Text*/quote);
            DQ.Show();
            //Close();

        }

        private void AddQuote_Load(object sender, EventArgs e)
        {

        }
    }
}
