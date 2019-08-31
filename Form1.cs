using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyscig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = pictureBox1.Width - pictureBox2.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = pictureBox1.Width - pictureBox3.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = pictureBox1.Width - pictureBox4.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = pictureBox1.Width - pictureBox5.Width,
                MyRandom = MyRandomizer
            };

            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };
            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };
            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };
            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].ClearBet();
            }
            minimumBetLabel.Text = "Minimalny zakład to: " + numericUpDownZl.Minimum + "zł";
            
        }

        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandomizer = new Random();
        int radioButtion = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                bool win = GreyhoundArray[i].Run();
                if (win == true)
                {
                    timer1.Enabled = false;
                    for (int j = 0; j < 3; j++)
                    {
                        GuyArray[j].Collect(i);
                        GuyArray[j].ClearBet();
                    }
                    MessageBox.Show("Wygrał" + i);
                    for (int k = 0; k < 4; k++)
                    {
                        GreyhoundArray[k].TakeStartingPosition();
                    }
                }                
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Joe";
            radioButtion = 0;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Bob";
            radioButtion = 1;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = "Al";
            radioButtion = 2;
        }

        private void stawiaButton_Click(object sender, EventArgs e)
        {
            GuyArray[radioButtion].PlaceBet((int)numericUpDownZl.Value, (int)numericUpDownChart.Value);
        }
    }
}
