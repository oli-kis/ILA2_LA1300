using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LA_1300_NumberGuesserGUI
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        int secretNumber;
        int guessCounter = 0;
        SoundPlayer player = new SoundPlayer(@"C:\Users\olivier\OneDrive - Alte Kantonsschule Aarau\Dokumente\BBBaden\Lernatelier Schneider\LA_1300\LA_1300_NumberGuesserGUI\LA_1300_NumberGuesserGUI\MonteWAV.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            secretNumber = random.Next(1, 101);
            player.Load();
        }

        private void tbxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            int guess = 0;
            if(!(int.TryParse(tbxNumber.Text, out guess)))
            {
                lblMSG.Text = "Sie können die Textbox nicht leer lassen";
                return; 
            }

            if (guess < 1 || guess > 100)
            {
                lblMSG.Text = "Geben Sie eine Zahl zwischen 1-100 ein";
                tbxNumber.Text = "";
                return;
            }

            if (guess < secretNumber)
            {
                lblMSG.Text = "Die gesuchte Zahl ist grösser";
                tbxNumber.Text = "";
            }

            if (guess > secretNumber)
            {
                lblMSG.Text = "Die gesuchte Zahl ist kleiner";
                tbxNumber.Text = "";
            }

            if (guess == secretNumber)
            {
                lblMSG.Text = "Gratulation Sie haben die Zahl erraten, bitte wählen Sie erneut spielen.";
                tbxNumber.ReadOnly = true;
                btnGuess.Enabled = false;
            }

            guessCounter++;
            lblGuessCounter.Text = "Versuche: " + guessCounter;
        }



        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secretNumber = random.Next(1, 101);
            btnGuess.Enabled = true;
            tbxNumber.ReadOnly = false;
            lblMSG.Text = "Geben Sie eine Zahl zwischen 1-100 ein";
            tbxNumber.Text = "";
            guessCounter = 0;
            lblGuessCounter.Text = "Versuche: 0";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                player.Play();
            }
            else
            {
                player.Stop();
            }
        }
    }
}
