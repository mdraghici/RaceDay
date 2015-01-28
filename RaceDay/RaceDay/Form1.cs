using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceDay
{
    public partial class Form1 : Form
    {
        Guy[] Guy = new Guy[3];
        Greyhound[] Dog = new Greyhound[4];
        Random Randomizer = new Random();
       
        public Form1()
        {
            InitializeComponent();
            Guy[0] = new Guy() { Name = "Joe", Cash = 50, MyBet = null, MyLabel = label1, MyRadioButton = radioButton1 };
            Guy[0].ClearBet();
            Guy[1] = new Guy() { Name = "Bob", Cash = 75, MyBet = null, MyLabel = label2, MyRadioButton = radioButton2 };
            Guy[1].ClearBet();
            Guy[2] = new Guy() { Name = "Al", Cash = 45, MyBet = null, MyLabel = label3, MyRadioButton = radioButton3 };
            Guy[2].ClearBet();
            label6.Text = "Minimum bet is " + BetAmountSelect.Minimum + "$";
            Dog[0] = new Greyhound() { MyPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RacetrackLength = pictureBox1.Width, Randomizer = Randomizer };
            Dog[0].ReturnToStart();
            Dog[1] = new Greyhound() { MyPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RacetrackLength = pictureBox1.Width, Randomizer = Randomizer };
            Dog[1].ReturnToStart();
            Dog[2] = new Greyhound() { MyPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RacetrackLength = pictureBox1.Width, Randomizer = Randomizer };
            Dog[2].ReturnToStart();
            Dog[3] = new Greyhound() { MyPictureBox = pictureBox5, StartingPosition = pictureBox5.Left, RacetrackLength = pictureBox1.Width, Randomizer = Randomizer };
            Dog[3].ReturnToStart();
         
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            label4.Text = "Joe";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            label4.Text = "Bob";
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            label4.Text = "Al";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //place Joe's bet
            if (radioButton1.Checked)
            {
                if (Guy[0].PlaceBet((int)BetAmountSelect.Value, (int)DogNumberSelect.Value))
                {
                    Guy[0].UpdateLabels();
                }
            }
            //place Ben's bet
            if (radioButton2.Checked)
            {
                if (Guy[1].PlaceBet((int)BetAmountSelect.Value, (int)DogNumberSelect.Value))
                {
                    Guy[1].UpdateLabels();
                }
            }
            //place Al's bet
            if (radioButton3.Checked)
            {
                if (Guy[2].PlaceBet((int)BetAmountSelect.Value, (int)DogNumberSelect.Value))
                {
                    Guy[2].UpdateLabels();
                }
            }
       


        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            PlaceBet.Enabled = false;
            StartRace.Enabled = false;
            bool IsAWinner = false;
            int WinnerDog = 0;
            bool GameOver = true;
            while (!IsAWinner)
            {

                for (int i = 0; i <= 3; i++)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);

                    if (Dog[i].Run())
                    {
                        IsAWinner = true;
                        WinnerDog = i+1;
                        break; 
                    }
                }
            }
            MessageBox.Show("Dog " + (WinnerDog) + " has won!");
            for (int i = 0; i <= 3; i++)
            {
                Dog[i].ReturnToStart();
            }
            for (int i = 0; i <= 2; i++)
            {
                Guy[i].Collect(WinnerDog);
            }

            for (int i = 0; i <= 2; i++)
            {
                if (Guy[i].Cash > 0)
                {
                    GameOver = true;
                }
            }
            if (!GameOver)
            {
                PlaceBet.Enabled = true;
                StartRace.Enabled = true;
            }
            else
            {
                MessageBox.Show("Game Over!");
            }
        }


    }
}
