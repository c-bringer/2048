using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class MainForm : Form
    {
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
            lbScore.Text = "0";
            Init(3);
        }

        private void Init(int cases = 1)
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            int count = 0;

            while (count != cases)
            {
                int x = random.Next(0, 4);
                int y = random.Next(0, 4);

                if (TabLabel[x, y].Text == "")
                {
                    int nb = random.Next(1, 11);

                    if (nb >= 1 && nb <= 6)
                    {
                        TabLabel[x, y].Text = "2";
                    }
                    else
                    {
                        TabLabel[x, y].Text = "4";
                    }

                    count++;
                }
            }

            ColorUpdate();
        }

        private void ColorUpdate()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    switch(TabLabel[i, j].Text)
                    {
                        case "":
                            TabLabel[i, j].BackColor = Color.CadetBlue;
                            break;
                        case "2":
                            TabLabel[i, j].BackColor = Color.Silver;
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "4":
                            TabLabel[i, j].BackColor = Color.Gray;
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "8":
                            TabLabel[i, j].BackColor = Color.FromArgb(64, 64, 64);
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "16":
                            TabLabel[i, j].BackColor = Color.Black;
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "32":
                            TabLabel[i, j].BackColor = Color.Yellow;
                            TabLabel[i, j].ForeColor = Color.Silver;
                            break;
                        case "64":
                            TabLabel[i, j].BackColor = Color.FromArgb(192, 192, 0);
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "128":
                            TabLabel[i, j].BackColor = Color.Olive;
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "256":
                            TabLabel[i, j].BackColor = Color.Gold;
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "512":
                            TabLabel[i, j].BackColor = Color.FromArgb(64, 64, 0);
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "1024":
                            TabLabel[i, j].BackColor = Color.FromArgb(255, 128, 0);
                            TabLabel[i, j].ForeColor = Color.White;
                            break;
                        case "2048":
                            TabLabel[i, j].BackColor = Color.FromArgb(192, 64, 0);
                            TabLabel[i, j].ForeColor = Color.FromArgb(255, 255, 192);
                            break;
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool result = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    result = Up();
                    break;
                case Keys.Down:
                    result = Down();
                    break;
                case Keys.Left:
                     result = Left();
                    break;
                case Keys.Right:
                    result = Right();
                    break;
            }

            if(result)
            {
                if (!Get2048())
                {
                    if (IsFull())
                    {
                        DialogResult dialog = MessageBox.Show("You Lose !!! Do you want to play again ?", "Loser", MessageBoxButtons.YesNo);
                        if(dialog == DialogResult.Yes)
                        {
                            GameReset();
                        } else
                        {
                            Application.Exit();
                        }
                    } else
                    {
                        Init();
                    }
                }
            }
        }

        private bool IsFull()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool isFull = false;
            int casesNotEmpty = 0;

            for(int i = 0; i < 4; i ++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(TabLabel[i, j].Text != "")
                    {
                        casesNotEmpty++;
                    }
                }
            }

            if(casesNotEmpty == 16)
            {
                isFull = true;
            }

            return isFull;
        }

        private bool Get2048()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool get2048 = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (TabLabel[i, j].Text == "2048")
                    {
                        DialogResult dialog = MessageBox.Show("You Win !!! Do you want to play again ?", "Winner", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            GameReset();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
            }

            return get2048;
        }

        private bool Up()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool modif = true;

            while (modif)
            {
                modif = false;

                for(int j = 0; j < 4; j++)
                {
                    for(int i = 1; i < 4; i++)
                    {
                        if(TabLabel[i, j].Text != "" && TabLabel[i - 1, j].Text == "")
                        {
                            TabLabel[i - 1, j].Text = TabLabel[i, j].Text;
                            TabLabel[i, j].Text = "";
                            modif = true;
                        }
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if((TabLabel[i, j].Text == TabLabel[i - 1, j].Text) && TabLabel[i, j].Text != "")
                        {
                            TabLabel[i - 1, j].Text = (int.Parse(TabLabel[i, j].Text) * 2).ToString();
                            TabLabel[i, j].Text = "";
                            Score(Convert.ToInt32(TabLabel[i - 1, j].Text));
                        }
                    }
                }
            }

            modif = true;

            ColorUpdate();
            return modif;
        }

        private bool Down()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool modif = true;

            while (modif)
            {
                modif = false;

                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (TabLabel[i, j].Text != "" && TabLabel[i + 1, j].Text == "")
                        {
                            TabLabel[i + 1, j].Text = TabLabel[i, j].Text;
                            TabLabel[i, j].Text = "";
                            modif = true;
                        }
                    }
                }

                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if ((TabLabel[i, j].Text == TabLabel[i + 1, j].Text) && TabLabel[i, j].Text != "")
                        {
                            TabLabel[i + 1, j].Text = (int.Parse(TabLabel[i, j].Text) * 2).ToString();
                            TabLabel[i, j].Text = "";
                            Score(Convert.ToInt32(TabLabel[i + 1, j].Text));
                        }
                    }
                }
            }

            modif = true;

            ColorUpdate();
            return modif;
        }

        private bool Left()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool modif = true;

            while (modif)
            {
                modif = false;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (TabLabel[i, j].Text != "" && TabLabel[i, j - 1].Text == "")
                        {
                            TabLabel[i, j - 1].Text = TabLabel[i, j].Text;
                            TabLabel[i, j].Text = "";
                            modif = true;
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if ((TabLabel[i, j].Text == TabLabel[i, j - 1].Text) && TabLabel[i, j].Text != "")
                        {
                            TabLabel[i, j - 1].Text = (int.Parse(TabLabel[i, j].Text) * 2).ToString();
                            TabLabel[i, j].Text = "";
                            Score(Convert.ToInt32(TabLabel[i, j - 1].Text));
                        }
                    }
                }
            }

            modif = true;

            ColorUpdate();
            return modif;
        }

        private bool Right()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };
            bool modif = true;

            while (modif)
            {
                modif = false;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (TabLabel[i, j].Text != "" && TabLabel[i, j + 1].Text == "")
                        {
                            TabLabel[i, j + 1].Text = TabLabel[i, j].Text;
                            TabLabel[i, j].Text = "";
                            modif = true;
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((TabLabel[i, j].Text == TabLabel[i, j + 1].Text) && TabLabel[i, j].Text != "")
                        {
                            TabLabel[i, j + 1].Text = (int.Parse(TabLabel[i, j].Text) * 2).ToString();
                            TabLabel[i, j].Text = "";
                            Score(Convert.ToInt32(TabLabel[i, j + 1].Text));
                        }
                    }
                }
            }

            modif = true;

            ColorUpdate();
            return modif;
        }

        private void Score(int value)
        {
            int currentScore = Convert.ToInt32(lbScore.Text);
            int newScore = currentScore + value;

            lbScore.Text = newScore.ToString();
        }

        private void GameReset()
        {
            Label[,] TabLabel = new Label[4, 4]
            {
                {lb0, lb1, lb2, lb3 },
                {lb4, lb5, lb6, lb7 },
                {lb8, lb9, lb10, lb11 },
                {lb12, lb13, lb14, lb15 }
            };

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    TabLabel[i, j].Text = "";
                }
            }

            lbScore.Text = "0";
            Init(3);
            ColorUpdate();
        }
    }
}
