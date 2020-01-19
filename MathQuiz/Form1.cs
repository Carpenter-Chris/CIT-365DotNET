using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Random object called randomizer
        //generate random numbers.
        Random randomizer = new Random();

        //ints used for addition problem
        int addend1;
        int addend2;

        //ints used for sub problem
        int minuend;
        int subtrahend;

        //ints used for multi problem
        int multiplicand;
        int multiplier;

        //ints used for div problem
        int dividend;
        int divisor;

        //This int keeps track of the remaining time.
        int timeLeft;

        public void StartTheQuiz()
        {
            //generate random numbers
            //.Next(#), the # indicates what the range is from 0 to number - 1.
            //our range with .Next(51) is 0 - 50.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //convert numbers to strings to be displayed
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control
            //this step makes sure the value is zero before adding any values to it. 
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //fill in the multi problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //fill in the div problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

            //display date
            dateLabel.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        public Form1()
        {
            InitializeComponent();
        }

        //double clicked the "start quiz" button to get this click event handler
        private void startButton_Click(object sender, EventArgs e)
        {
            //calls method
            StartTheQuiz();
            //disables the button during the quiz
            startButton.Enabled = false;
        }

        //added the timer from the design tool bar, double clicked the time to produce this Tick event handler
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //Display the new time left by updating the 'Time Left' label
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                //change the background color of the timer when its at 5 secs or less.
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }

                //check answers and play a sound if they are correct

            }
            else
            {
                //If user ran out of time, stop the timer, show a message box, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = default(Color);
            }
        }

        //check the user answer
        //returns true if the answer is correct, else false
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                &&(minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sumSound(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                System.Media.SoundPlayer correctSound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
                correctSound.Play();
            }
            
        }

        private void subSound(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                System.Media.SoundPlayer correctSound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
                correctSound.Play();
            }
            
        }

        private void multiSound(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                System.Media.SoundPlayer correctSound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
                correctSound.Play();
            }
            
        }

        private void divSound(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                System.Media.SoundPlayer correctSound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
                correctSound.Play();
            }
            
        }
    }
}
