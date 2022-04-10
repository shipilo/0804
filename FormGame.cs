using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _0804
{
    public partial class FormGame : Form
    {
        private static Random random;
        private static DirectoryInfo directory;
        private static List<string> images;
        private Button[] buttons;
        private PictureBox[] pictures;
        private DateTime timePrevious;
        private DateTime timeCurrent;
        private DateTime timePause;
        private bool isGaming;
        private bool isStarted;

        private const int maxScore = 18;
        private const int waitingCount1 = 14;
        private const int waitingCount2 = 6;
        private int counter = 0;
        private int chosenTag1 = -1;
        private int chosenTag2 = -1;
        private int score = 0;
        private int seconds = 0;

        public List<string> logins;
        public List<int> scores;
        public List<int> times;

        public FormGame()
        {
            InitializeComponent();
            random = new Random();
            directory = new DirectoryInfo(Environment.CurrentDirectory);
            isGaming = false;
            isStarted = false;
            images = new List<string>()
            {
                "1.png",
                "2.png",
                "3.png",
                "4.png",
                "5.png",
                "6.png",
                "7.png",
                "8.png",
                "9.png",
                "10.png",
                "11.png",
                "12.png",
                "13.png",
                "14.png",
                "15.png",
                "16.png",
                "17.png",
                "18.png",
                "1.png",
                "2.png",
                "3.png",
                "4.png",
                "5.png",
                "6.png",
                "7.png",
                "8.png",
                "9.png",
                "10.png",
                "11.png",
                "12.png",
                "13.png",
                "14.png",
                "15.png",
                "16.png",
                "17.png",
                "18.png"
            };
            buttons = new Button[]
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16,
                button17,
                button18,
                button19,
                button20,
                button21,
                button22,
                button23,
                button24,
                button25,
                button26,
                button27,
                button28,
                button29,
                button30,
                button31,
                button32,
                button33,
                button34,
                button35,
                button36
            };
            pictures = new PictureBox[]
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10,
                pictureBox11,
                pictureBox12,
                pictureBox13,
                pictureBox14,
                pictureBox15,
                pictureBox16,
                pictureBox17,
                pictureBox18,
                pictureBox19,
                pictureBox20,
                pictureBox21,
                pictureBox22,
                pictureBox23,
                pictureBox24,
                pictureBox25,
                pictureBox26,
                pictureBox27,
                pictureBox28,
                pictureBox29,
                pictureBox30,
                pictureBox31,
                pictureBox32,
                pictureBox33,
                pictureBox34,
                pictureBox35,
                pictureBox36
            };
            logins = new List<string>();
            scores = new List<int>();
            times = new List<int>();            
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].Tag = i;
                buttons[i].Tag = i;
            }

            if (File.Exists("data.txt"))
            {
                StreamReader sr = new StreamReader("data.txt");
                string[] data = sr.ReadToEnd().Trim().Split();
                sr.Close();
                foreach (string line in data)
                {
                    string[] items = line.Split('#');
                    logins.Add(items[0]);
                    scores.Add(Convert.ToInt32(items[1]));
                    times.Add(Convert.ToInt32(items[2]));
                }
            }
        }

        private static void Swap(List<string> array, int i1, int i2, string value1, string value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }

        private void timerForTimer_Tick(object sender, EventArgs e)
        {
            timeCurrent = DateTime.Now;
            seconds = (int)(timeCurrent - timePrevious).TotalSeconds;
            lSeconds1.Text = (seconds % 60 % 10).ToString();
            lSeconds2.Text = (seconds % 60 / 10 % 10).ToString();
            lMinutes1.Text = (seconds / 60 % 10).ToString();
            lMinutes2.Text = (seconds / 600 % 10).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lMinutes2.Focus();
            if (chosenTag1 > 0 && chosenTag2 > 0)
            {
                timerForWaiting2.Stop();
                buttons[chosenTag1].Visible = true;
                buttons[chosenTag2].Visible = true;
                chosenTag1 = -1;
                chosenTag2 = -1;
                counter = 0;
            }
            if ((chosenTag1 == -1 || chosenTag2 == -1) && isGaming || !isStarted)
            {
                int tag = Convert.ToInt32((sender as Button).Tag);
                buttons[tag].Visible = false;
                if (!isStarted)
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        int odd = random.Next(images.Count);
                        Swap(images, i, odd, images[i], images[odd]);
                    }
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (File.Exists(directory.Parent.Parent.FullName + "\\Images\\" + images[i]))
                        {
                            pictures[i].BackgroundImage = new Bitmap(directory.Parent.Parent.FullName + "\\Images\\" + images[i]);
                        }
                    }
                    isStarted = true;
                    isGaming = true;
                    timePrevious = DateTime.Now;
                    bStopPlay.Visible = true;
                    timerForTimer.Start();
                }
                if (chosenTag1 == -1)
                {
                    chosenTag1 = tag;
                    timerForWaiting1.Start();
                }
                else
                {
                    chosenTag2 = tag;
                    timerForWaiting1.Stop();
                    counter = 0;
                    if (!images[tag].Equals(images[chosenTag1]))
                    {
                        timerForWaiting2.Start();
                    }
                    else
                    {
                        chosenTag1 = -1;
                        chosenTag2 = -1;
                        score++;
                        lScore.Text = score.ToString();
                        if (score == maxScore)
                        {
                            timerForTimer.Stop();
                            scores.Add(score);
                            times.Add(seconds);
                            bStopPlay.Visible = false;
                        }
                    }
                } 
            }
        }

        private void timerForWaiting1_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == waitingCount1)
            {
                timerForWaiting1.Stop();
                buttons[chosenTag1].Visible = true;
                chosenTag1 = -1;
                counter = 0;
            }
        }

        private void timerForWaiting2_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == waitingCount2)
            {
                timerForWaiting2.Stop();
                buttons[chosenTag1].Visible = true;
                buttons[chosenTag2].Visible = true;
                chosenTag1 = -1;
                chosenTag2 = -1;
                counter = 0;
            }
        }

        private void bGame_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")
            {
                lMessage.Visible = true;
            }
            else
            {
                logins.Add(tbLogin.Text);
                tbLogin.Text = "";
                lMessage.Visible = false;
                panelMenu.Visible = false;
            }
        }

        private void bMenu_Click(object sender, EventArgs e)
        {
            if (score != maxScore)
            {
                timerForTimer.Stop();
                scores.Add(score);
                times.Add(seconds);
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visible = true;
            }
            isGaming = false;
            isStarted = false;
            bStopPlay.Text = "Пауза";
            bStopPlay.Visible = false;
            panelMenu.Visible = true;
            lMinutes2.Text = "0";
            lMinutes1.Text = "0";
            lSeconds2.Text = "0";
            lSeconds1.Text = "0";
            lScore.Text = "0";
            score = 0;
            seconds = 0;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            if (score != maxScore)
            {
                timerForTimer.Stop();
                scores.Add(score);
                times.Add(seconds);
            }
            string data = "";
            for (int i = 0; i < logins.Count; i++)
            {
                data += logins[i] + "#" + scores[i] + "#" + times[i] + "\n";
            }
            StreamWriter sw = new StreamWriter("data.txt");
            sw.Write(data);
            sw.Close();
            if (sender != null) this.Close();
        }

        private void bRating_Click(object sender, EventArgs e)
        {
            FormRating rating = new FormRating(this.Location, this);
            rating.Show();
        }

        private void bStopPlay_Click(object sender, EventArgs e)
        {
            if (isGaming)
            {
                timerForTimer.Stop();
                isGaming = false;
                bStopPlay.Text = "Продолжить";
                timePause = DateTime.Now;
            }
            else
            {
                isGaming = true;
                bStopPlay.Text = "Пауза";
                timePrevious += DateTime.Now - timePause;
                timePause = new DateTime();
                timerForTimer.Start();
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            bExit_Click(null, null);
        }
    }
}
