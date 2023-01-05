using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Form2 : Form
    {
        public Random rnd = new Random();
        bool? Single_mode;
        int Num_of_opponents;        
        int Num_of_rerolls;
        string[] Player_Names = new string[6];
        static int Roll_Count;
        static List<Label> Dice_LB = new List<Label>();
        bool Game_over = false;
        int Player_id;           
        static bool Condition_state = false;
        static bool Clicked = false;
        List<Label> Players_LB = new List<Label>();
        static List<int> Players_LB_int = new List<int>() {0,1,2,3,4,5};               
        List<int> Yahtzee_Bonuses = new List<int> {0,0,0,0,0,0 };
        string Winner_Player = "";
        int Winner_Score = 0;
        bool Dice_1_Locked = false;
        bool Dice_2_Locked = false;
        bool Dice_3_Locked = false;
        bool Dice_4_Locked = false;
        bool Dice_5_Locked = false;


        public Form2(bool? Single_mode, int Num_of_opponents, int Num_of_rerolls, string[] Player_Names,int player_id)
        {
            this.Single_mode = Single_mode;
            this.Num_of_opponents = Num_of_opponents;            
            this.Num_of_rerolls = Num_of_rerolls;
            this.Player_Names = Player_Names;
            this.Player_id = player_id;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Roll_Count = 0;                    
            Clicked = false;
            Dice_LB.Add(Dice_1_LB);
            Dice_LB.Add(Dice_2_LB);
            Dice_LB.Add(Dice_3_LB);
            Dice_LB.Add(Dice_4_LB);
            Dice_LB.Add(Dice_5_LB);
            Players_LB.Add(Player_1_LB);
            Players_LB.Add(Player_2_LB);
            Players_LB.Add(Player_3_LB);
            Players_LB.Add(Player_4_LB);
            Players_LB.Add(Player_5_LB);
            Players_LB.Add(Player_6_LB);
             Dice_1_Locked = false;
             Dice_2_Locked = false;
             Dice_3_Locked = false;
             Dice_4_Locked = false;
             Dice_5_Locked = false;           
            int Dice_reset = 0;
            while (Dice_reset<Dice_LB.Count)
            {
                Dice_LB[Dice_reset].Text = "0";
                Dice_reset++;
            }

            for (int i = 0; i < Player_Names.Length; i++)
            {
                if (Player_Names[i]=="")
                {
                    Player_Names[i] = $"Player{i+1}";
                }
            }            

            Player_1_LB.Text = Player_Names[0];
            Player_2_LB.Text = Player_Names[1];
            Player_3_LB.Text = Player_Names[2];
            Player_4_LB.Text = Player_Names[3];
            Player_5_LB.Text = Player_Names[4];
            Player_6_LB.Text = Player_Names[5];

            if (Single_mode==true)
            {
                Player_2_LB.Visible = false;
                Player_3_LB.Visible = false;
                Player_4_LB.Visible = false;
                Player_5_LB.Visible = false;
                Player_6_LB.Visible = false;
            }
            else
            {
                switch (Num_of_opponents)
                {
                    case 1:
                        Player_3_LB.Visible = false;
                        Player_4_LB.Visible = false;
                        Player_5_LB.Visible = false;
                        Player_6_LB.Visible = false;
                        break;
                    case 2:
                        Player_4_LB.Visible = false;
                        Player_5_LB.Visible = false;
                        Player_6_LB.Visible = false;
                        break;
                    case 3:
                        Player_5_LB.Visible = false;
                        Player_6_LB.Visible = false;
                        break;
                    case 4:
                        Player_6_LB.Visible = false;
                        break;
                }                
            }

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Label Cell_label = new Label();
                    Cell_label.Text = "0";
                    Cell_label.TextAlign = ContentAlignment.MiddleCenter;                    
                    Cell_label.AutoSize = false;
                    Cell_label.ForeColor = Form.DefaultBackColor;                  
                    Cell_label.Dock = DockStyle.Fill;
                    Cell_label.Visible = true;
                    Cell_label.Click += Cell_label_Click;
                    Cell_label.ForeColorChanged += Cell_label_ForeColorChanged;                                        
                    Board_Panel.Controls.Add(Cell_label);                    
                }
            }            
        }

        private void Cell_label_ForeColorChanged(object? sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                Players_LB[i].ForeColor = Label.DefaultForeColor;
                if (Players_LB_int[i] == Player_id)
                {
                    Players_LB[i].ForeColor = Color.Orange;
                }
            }           
        }

        private void Cell_label_Click(object? sender, EventArgs e)
        {
            if (Clicked!=true)
            {
                if (sender is Label && (sender as Label).ForeColor == Color.Green)
                {
                    (sender as Label).ForeColor = Color.Black;
                    Clicked = true;
                    if ((sender as Label).ForeColor == Color.Black)
                    {
                        Reset_Unused_Category_Col();
                        Player_id++;                                             
                        if (Clicked == true)
                        {
                            Roll_BTN.Enabled = true;
                            Roll_Count = 0;
                        }
                        if (Player_id > Num_of_opponents)
                        {
                            Player_id = 0;
                        }                       
                    }
                }
            }
        }
        
       private void Conditions(int con_id, List<Label> list)
        {                       
            switch (con_id)
            {
                case 1:
                    list.RemoveAll(x => x.Text != "1");
                    break;
                case 2:
                    list.RemoveAll(x => x.Text != "2");
                    break;
                case 3:
                    list.RemoveAll(x => x.Text != "3");
                    break;
                case 4:
                    list.RemoveAll(x => x.Text != "4");
                    break;
                case 5:
                    list.RemoveAll(x => x.Text != "5");
                    break;
                case 6:
                    list.RemoveAll(x => x.Text != "6");
                    break;
                case 7:
                    int aces = list.Count(x => x.Text == "1");
                    int twos = list.Count(x => x.Text == "2");
                    int threes = list.Count(x => x.Text == "3");
                    int fours = list.Count(x => x.Text == "4");
                    int fives = list.Count(x => x.Text == "5");
                    int sixes = list.Count(x => x.Text == "6");

                    List<int> Greater_or_equals_3 = new List<int> { aces, twos, threes, fours, fives, sixes };

                    if (Greater_or_equals_3.Max() >= 3 || Greater_or_equals_3.Max()==5)
                    {                       
                        Condition_state = true;
                    }                    
                    break;
                case 8:
                    int aces_2 = list.Count(x => x.Text == "1");
                    int twos_2 = list.Count(x => x.Text == "2");
                    int threes_2 = list.Count(x => x.Text == "3");
                    int fours_2 = list.Count(x => x.Text == "4");
                    int fives_2 = list.Count(x => x.Text == "5");
                    int sixes_2 = list.Count(x => x.Text == "6");

                    List<int> Greater_or_equals_4 = new List<int> { aces_2, twos_2, threes_2, fours_2, fives_2, sixes_2 };
                    if (Greater_or_equals_4.Max() >= 4 || Greater_or_equals_4.Max()==5)
                    {
                        Condition_state = true;
                    }                    
                    break;
                case 9:
                    int aces_3 = list.Count(x => x.Text == "1");
                    int twos_3 = list.Count(x => x.Text == "2");
                    int threes_3 = list.Count(x => x.Text == "3");
                    int fours_3 = list.Count(x => x.Text == "4");
                    int fives_3 = list.Count(x => x.Text == "5");
                    int sixes_3 = list.Count(x => x.Text == "6");

                    List<int> Full_House = new List<int> { aces_3, twos_3, threes_3, fours_3, fives_3, sixes_3 };
                    if (Full_House.Max() == 3 && Full_House.Contains(2))
                    {
                        Condition_state = true;
                    }
                    else if (Full_House.Max()==5)
                    {
                        Condition_state = true;
                    }
                    break;
                case 10:
                    int aces_4 = list.Count(x => x.Text == "1");
                    int twos_4 = list.Count(x => x.Text == "2");
                    int threes_4 = list.Count(x => x.Text == "3");
                    int fours_4 = list.Count(x => x.Text == "4");
                    int fives_4 = list.Count(x => x.Text == "5");
                    int sixes_4 = list.Count(x => x.Text == "6");

                    List<int> Small_straight = new List<int>();
                    List<int> Small_straight_2 = new List<int> { aces_4, twos_4, threes_4, fours_4 , fives_4 , sixes_4 };
                    for (int i = 0; i < list.Count; i++)
                    {
                        Small_straight.Add(int.Parse(list[i].Text));
                    }
                    if (Small_straight_2.Max() == 5)
                    {
                        Condition_state = true;
                    }
                    else if (Small_straight.Contains(1)&& Small_straight.Contains(2)&& Small_straight.Contains(3)&& Small_straight.Contains(4))
                    {
                        Condition_state = true;
                    }
                    else if (Small_straight.Contains(2)&& Small_straight.Contains(3)&& Small_straight.Contains(4)&& Small_straight.Contains(5))
                    {
                        Condition_state = true;
                    }
                    else if (Small_straight.Contains(3)&& Small_straight.Contains(4)&& Small_straight.Contains(5)&& Small_straight.Contains(6))
                    {
                        Condition_state = true;
                    }                    
                    break;
                case 11:
                    int aces_5 = list.Count(x => x.Text == "1");
                    int twos_5 = list.Count(x => x.Text == "2");
                    int threes_5 = list.Count(x => x.Text == "3");
                    int fours_5 = list.Count(x => x.Text == "4");
                    int fives_5 = list.Count(x => x.Text == "5");
                    int sixes_5 = list.Count(x => x.Text == "6");

                    List<int> Large_straight = new List<int> { aces_5, twos_5, threes_5, fours_5, fives_5, sixes_5 };

                    int one_Counter_2 = 0;
                    for (int i = 0; i < Large_straight.Count; i++)
                    {
                        if (Large_straight[i]==1)
                        {
                            one_Counter_2++;
                        }
                    }
                    if (one_Counter_2 ==5 || Large_straight.Max()==5)
                    {
                        Condition_state = true;
                    }
                    break;
                case 12:
                    int aces_6 = list.Count(x => x.Text == "1");
                    int twos_6 = list.Count(x => x.Text == "2");
                    int threes_6 = list.Count(x => x.Text == "3");
                    int fours_6 = list.Count(x => x.Text == "4");
                    int fives_6 = list.Count(x => x.Text == "5");
                    int sixes_6 = list.Count(x => x.Text == "6");

                    List<int> Yahtzee = new List<int> { aces_6, twos_6, threes_6, fours_6, fives_6, sixes_6 };
                    if (Yahtzee.Max() == 5)
                        Condition_state = true;
                    if (Board_Panel.GetControlFromPosition(Player_id,13).Text=="50" && Board_Panel.GetControlFromPosition(Player_id, 13).ForeColor==Color.Black)
                    {
                        Yahtzee_Bonuses[Player_id]++;
                    }                    
                    break;
                case 13:
                    Condition_state = true;
                    break;               
            }
        }
        
        private string Lower_Sect_Text(int con_id, List<Label> list, bool con_state)
        {
            string Text = "0";
            switch (con_id)
            {
                case 7:
                    if (con_state==true)
                        Text = list.Sum(x => int.Parse(x.Text)).ToString();
                    break;
                case 8:
                    if (con_state == true)
                        Text = list.Sum(x => int.Parse(x.Text)).ToString();
                    break;
                case 9:
                    if (con_state == true)
                        Text = "25";
                    break;
                case 10:
                    if (con_state == true)
                        Text = "30";
                    break;
                case 11:
                    if (con_state == true)
                        Text = "40";
                    break;
                case 12:
                    if (con_state == true)
                        Text = "50";
                    break;
                case 13:                    
                        Text = list.Sum(x => int.Parse(x.Text)).ToString();
                    break;
            }

            return Text;
        }
        
        private void Category_Check_Upper_Sect()
        {
            int Upper_Counter = 0;
            int Upper_Sum = 0;
            for (int i = 0; i < 6; i++)
            {
                List<Label> Dice = new List<Label>(Dice_LB);

                Conditions(i+1,Dice);
                if (Board_Panel.GetControlFromPosition(Player_id, i).ForeColor != Color.Black)
                {
                    Board_Panel.GetControlFromPosition(Player_id, i).ForeColor = Color.Green;
                    Board_Panel.GetControlFromPosition(Player_id, i).Text = Dice.Sum(x => int.Parse(x.Text)).ToString();
                }                                
                Dice.Clear();
                if (Board_Panel.GetControlFromPosition(Player_id, i).ForeColor == Color.Black)
                {
                    Upper_Counter++;
                     Upper_Sum += int.Parse(Board_Panel.GetControlFromPosition(Player_id, i).Text);
                }
            }
            if (Upper_Counter==6)
            {               
                Board_Panel.GetControlFromPosition(Player_id, 6).Text = Upper_Sum.ToString();
                Board_Panel.GetControlFromPosition(Player_id, 6).ForeColor = Color.Blue;                
                if (Upper_Sum>=63)
                {
                    Board_Panel.GetControlFromPosition(Player_id, 7).Text = "35";
                    Board_Panel.GetControlFromPosition(Player_id, 7).ForeColor = Color.Blue;                    
                }
                else
                {
                    Board_Panel.GetControlFromPosition(Player_id, 7).Text = "0";
                    Board_Panel.GetControlFromPosition(Player_id, 7).ForeColor = Color.Blue;
                }
            }
        }
        
        private void Category_Check_Lower_Sect()
        {
           
            for (int i = 7; i < 14; i++)
            {
                Condition_state = false;
                List<Label> Dice = new List<Label>(Dice_LB);                
                Conditions(i,Dice);
                if (Board_Panel.GetControlFromPosition(Player_id, i + 1).ForeColor !=Color.Black)
                {
                    Board_Panel.GetControlFromPosition(Player_id, i + 1).ForeColor = Color.Green;
                    Board_Panel.GetControlFromPosition(Player_id, i + 1).Text = Lower_Sect_Text(i, Dice, Condition_state);
                }               
                Dice.Clear();                
            }           
        }        
        
        private void Reset_Unused_Category_Col()
        {
            int player_id = Player_id;
            player_id += 1;
            
            for (int i = 0; i < 15; i++)
            {                
                if (Board_Panel.GetControlFromPosition(player_id - 1, i).ForeColor == Color.Green)
                {
                    Board_Panel.GetControlFromPosition(player_id - 1, i).ForeColor = Form.DefaultBackColor;
                }
            }
        }       
        
        private void Grand_Total_Check()
        {
            int No_Green_Counter = 0;
            for (int i = 0; i < 15; i++)
            {
                if (Board_Panel.GetControlFromPosition(Player_id, i).ForeColor != Color.Green)
                {
                    No_Green_Counter++;
                }
            }
            if (No_Green_Counter == 15)
            {
              
                int Sum = 0;
                List<int> Sum_Li = new List<int>();
                for (int i = 0; i < Players_LB.Count; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        Sum += int.Parse(Board_Panel.GetControlFromPosition(i, j).Text);
                    }
                    Sum_Li.Add(Sum);
                    Sum_Li[i] -= int.Parse(Board_Panel.GetControlFromPosition(i, 6).Text);
                    Sum = 0;
                }

                int Max_Score = 0;
                string Max_Player = "";
                for (int i = 0; i < Players_LB.Count; i++)
                {
                    if (Sum_Li[i]==0)
                    {
                        Board_Panel.GetControlFromPosition(i, 15).ForeColor = Form.DefaultBackColor;
                    }
                    else
                    {
                        Board_Panel.GetControlFromPosition(i, 15).ForeColor = Color.Purple;
                        if (Board_Panel.GetControlFromPosition(i, 6).ForeColor == Form.DefaultBackColor)
                        {
                            Board_Panel.GetControlFromPosition(i, 6).ForeColor = Color.Blue;
                            Board_Panel.GetControlFromPosition(i, 7).ForeColor = Color.Blue;
                        }
                    }
                    Board_Panel.GetControlFromPosition(i, 15).Text = (Sum_Li[i] + (Yahtzee_Bonuses[i] * 100)).ToString();
                    for (int j = 0; j < Players_LB.Count; j++)
                    {
                        if (Sum_Li[i] + Yahtzee_Bonuses[i]*100> 0)
                        {
                            Max_Score=Sum_Li[i] + Yahtzee_Bonuses[i] * 100;
                            Max_Player = Players_LB[i].Text;
                        }
                    }
                    Winner_Score = Max_Score;
                    Winner_Player = Max_Player;
                    Game_over = true;
                }
            }
            Game_Over(Game_over);
        }

        private void Game_Over(bool game_over)
        {
            if (game_over==true)
            {                                
                MessageBox.Show($"The winner is {Winner_Player} with {Winner_Score} points!\nCongratulations, and thank you for playing!\n" +
                    $"Close the window to quit to the main menu","Game Over");
            }
        }

        private void Roll_BTN_Click(object sender, EventArgs e)
        {                       
            if (Roll_Count==Num_of_rerolls)
            {
                Roll_BTN.Enabled = false;
            }
            if (Dice_1_Locked==false)
            {
                Dice_1_LB.Text = rnd.Next(1, 7).ToString();
            }
            if (Dice_2_Locked == false)
            {
                Dice_2_LB.Text = rnd.Next(1, 7).ToString();
            }
            if (Dice_3_Locked == false)
            {
                Dice_3_LB.Text = rnd.Next(1, 7).ToString();
            }
            if (Dice_4_Locked == false)
            {
                Dice_4_LB.Text = rnd.Next(1, 7).ToString();
            }
            if (Dice_5_Locked==false)
            {
                Dice_5_LB.Text = rnd.Next(1, 7).ToString();
            }
            Roll_Count++;

            Category_Check_Upper_Sect();
            Category_Check_Lower_Sect();
            Grand_Total_Check();
            if (Clicked == true)
            {
                Clicked = false;                
            }

        }

        private void Dice_1_LB_Click(object sender, EventArgs e)
        {
            if (Dice_1_Locked == false)
            {
                Dice_1_Locked = true;
                Unlock_BTN.Enabled = true;                
                switch (int.Parse(Dice_1_LB.Text))
                {
                    case 1:
                        Dice_1_LB.Image = Properties.Resources.One_lock;
                        break;
                    case 2:
                        Dice_1_LB.Image = Properties.Resources.Two_lock;
                        break;
                    case 3:
                        Dice_1_LB.Image = Properties.Resources.Three_lock;
                        break;
                    case 4:
                        Dice_1_LB.Image = Properties.Resources.Four_lock;
                        break;
                    case 5:
                        Dice_1_LB.Image = Properties.Resources.Five_lock;
                        break;
                    case 6:
                        Dice_1_LB.Image = Properties.Resources.Six_lock;
                        break;
                }

            }
            else
            {
                Dice_1_Locked = false;                
                switch (int.Parse(Dice_1_LB.Text))
                {
                    case 1:
                        Dice_1_LB.Image = Properties.Resources.One;
                        break;
                    case 2:
                        Dice_1_LB.Image = Properties.Resources.Two;
                        break;
                    case 3:
                        Dice_1_LB.Image = Properties.Resources.Three;
                        break;
                    case 4:
                        Dice_1_LB.Image = Properties.Resources.Four;
                        break;
                    case 5:
                        Dice_1_LB.Image = Properties.Resources.Five;
                        break;
                    case 6:
                        Dice_1_LB.Image = Properties.Resources.Six;
                        break;
                }
            }

            
        }

        private void Dice_2_LB_Click(object sender, EventArgs e)
        {
            if (Dice_2_Locked == false)
            {
                Dice_2_Locked = true;
                Unlock_BTN.Enabled = true;                
                switch (int.Parse(Dice_2_LB.Text))
                {
                    case 1:
                        Dice_2_LB.Image = Properties.Resources.One_lock;
                        break;
                    case 2:
                        Dice_2_LB.Image = Properties.Resources.Two_lock;
                        break;
                    case 3:
                        Dice_2_LB.Image = Properties.Resources.Three_lock;
                        break;
                    case 4:
                        Dice_2_LB.Image = Properties.Resources.Four_lock;
                        break;
                    case 5:
                        Dice_2_LB.Image = Properties.Resources.Five_lock;
                        break;
                    case 6:
                        Dice_2_LB.Image = Properties.Resources.Six_lock;
                        break;
                }
            }
            else
            {
                Dice_2_Locked = false;                
                switch (int.Parse(Dice_2_LB.Text))
                {
                    case 1:
                        Dice_2_LB.Image = Properties.Resources.One;
                        break;
                    case 2:
                        Dice_2_LB.Image = Properties.Resources.Two;
                        break;
                    case 3:
                        Dice_2_LB.Image = Properties.Resources.Three;
                        break;
                    case 4:
                        Dice_2_LB.Image = Properties.Resources.Four;
                        break;
                    case 5:
                        Dice_2_LB.Image = Properties.Resources.Five;
                        break;
                    case 6:
                        Dice_2_LB.Image = Properties.Resources.Six;
                        break;
                }
            }
        }

        private void Dice_3_LB_Click(object sender, EventArgs e)
        {
            if (Dice_3_Locked == false)
            {
                Dice_3_Locked = true;                
                Unlock_BTN.Enabled = true;
                switch (int.Parse(Dice_3_LB.Text))
                {
                    case 1:
                        Dice_3_LB.Image = Properties.Resources.One_lock;
                        break;
                    case 2:
                        Dice_3_LB.Image = Properties.Resources.Two_lock;
                        break;
                    case 3:
                        Dice_3_LB.Image = Properties.Resources.Three_lock;
                        break;
                    case 4:
                        Dice_3_LB.Image = Properties.Resources.Four_lock;
                        break;
                    case 5:
                        Dice_3_LB.Image = Properties.Resources.Five_lock;
                        break;
                    case 6:
                        Dice_3_LB.Image = Properties.Resources.Six_lock;
                        break;
                }
            }
            else
            {
                Dice_3_Locked = false;                
                switch (int.Parse(Dice_3_LB.Text))
                {
                    case 1:
                        Dice_3_LB.Image = Properties.Resources.One;
                        break;
                    case 2:
                        Dice_3_LB.Image = Properties.Resources.Two;
                        break;
                    case 3:
                        Dice_3_LB.Image = Properties.Resources.Three;
                        break;
                    case 4:
                        Dice_3_LB.Image = Properties.Resources.Four;
                        break;
                    case 5:
                        Dice_3_LB.Image = Properties.Resources.Five;
                        break;
                    case 6:
                        Dice_3_LB.Image = Properties.Resources.Six;
                        break;
                }
            }
        }

        private void Dice_4_LB_Click(object sender, EventArgs e)
        {
            if (Dice_4_Locked == false)
            {
                Dice_4_Locked = true;                
                Unlock_BTN.Enabled = true;
                switch (int.Parse(Dice_4_LB.Text))
                {
                    case 1:
                        Dice_4_LB.Image = Properties.Resources.One_lock;
                        break;
                    case 2:
                        Dice_4_LB.Image = Properties.Resources.Two_lock;
                        break;
                    case 3:
                        Dice_4_LB.Image = Properties.Resources.Three_lock;
                        break;
                    case 4:
                        Dice_4_LB.Image = Properties.Resources.Four_lock;
                        break;
                    case 5:
                        Dice_4_LB.Image = Properties.Resources.Five_lock;
                        break;
                    case 6:
                        Dice_4_LB.Image = Properties.Resources.Six_lock;
                        break;
                }
            }
            else
            {
                Dice_4_Locked = false;                
                switch (int.Parse(Dice_4_LB.Text))
                {
                    case 1:
                        Dice_4_LB.Image = Properties.Resources.One;
                        break;
                    case 2:
                        Dice_4_LB.Image = Properties.Resources.Two;
                        break;
                    case 3:
                        Dice_4_LB.Image = Properties.Resources.Three;
                        break;
                    case 4:
                        Dice_4_LB.Image = Properties.Resources.Four;
                        break;
                    case 5:
                        Dice_4_LB.Image = Properties.Resources.Five;
                        break;
                    case 6:
                        Dice_4_LB.Image = Properties.Resources.Six;
                        break;
                }
            }
        }

        private void Dice_5_LB_Click(object sender, EventArgs e)
        {
            if (Dice_5_Locked == false)
            {
                Dice_5_Locked = true;                
                Unlock_BTN.Enabled = true;
                switch (int.Parse(Dice_5_LB.Text))
                {
                    case 1:
                        Dice_5_LB.Image = Properties.Resources.One_lock;
                        break;
                    case 2:
                        Dice_5_LB.Image = Properties.Resources.Two_lock;
                        break;
                    case 3:
                        Dice_5_LB.Image = Properties.Resources.Three_lock;
                        break;
                    case 4:
                        Dice_5_LB.Image = Properties.Resources.Four_lock;
                        break;
                    case 5:
                        Dice_5_LB.Image = Properties.Resources.Five_lock;
                        break;
                    case 6:
                        Dice_5_LB.Image = Properties.Resources.Six_lock;
                        break;
                }
            }
            else
            {
                Dice_5_Locked = false;                
                switch (int.Parse(Dice_5_LB.Text))
                {
                    case 1:
                        Dice_5_LB.Image = Properties.Resources.One;
                        break;
                    case 2:
                        Dice_5_LB.Image = Properties.Resources.Two;
                        break;
                    case 3:
                        Dice_5_LB.Image = Properties.Resources.Three;
                        break;
                    case 4:
                        Dice_5_LB.Image = Properties.Resources.Four;
                        break;
                    case 5:
                        Dice_5_LB.Image = Properties.Resources.Five;
                        break;
                    case 6:
                        Dice_5_LB.Image = Properties.Resources.Six;
                        break;
                }
            }

        }

        private void Unlock_BTN_Click(object sender, EventArgs e)
        {
            Dice_1_Locked = false;
            Dice_2_Locked = false;
            Dice_3_Locked = false;
            Dice_4_Locked = false;
            Dice_5_Locked = false;
            Dice_1_LB.ForeColor = Label.DefaultForeColor;
            Dice_2_LB.ForeColor = Label.DefaultForeColor;
            Dice_3_LB.ForeColor = Label.DefaultForeColor;
            Dice_4_LB.ForeColor = Label.DefaultForeColor;
            Dice_5_LB.ForeColor = Label.DefaultForeColor;
            switch (int.Parse(Dice_5_LB.Text))
            {
                case 1:
                    Dice_5_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_5_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_5_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_5_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_5_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_5_LB.Image = Properties.Resources.Six;
                    break;
            }
            switch (int.Parse(Dice_1_LB.Text))
            {
                case 1:
                    Dice_1_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_1_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_1_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_1_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_1_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_1_LB.Image = Properties.Resources.Six;
                    break;
            }
            switch (int.Parse(Dice_3_LB.Text))
            {
                case 1:
                    Dice_3_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_3_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_3_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_3_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_3_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_3_LB.Image = Properties.Resources.Six;
                    break;
            }
            switch (int.Parse(Dice_4_LB.Text))
            {
                case 1:
                    Dice_4_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_4_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_4_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_4_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_4_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_4_LB.Image = Properties.Resources.Six;
                    break;
            }
            switch (int.Parse(Dice_2_LB.Text))
            {
                case 1:
                    Dice_2_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_2_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_2_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_2_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_2_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_2_LB.Image = Properties.Resources.Six;
                    break;
            }
            Unlock_BTN.Enabled = false;
        }
        private void Dice_1_LB_TextChanged(object sender, EventArgs e)
        {
            
            switch (int.Parse(Dice_1_LB.Text))
            {
                case 1:
                    Dice_1_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_1_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_1_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_1_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_1_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_1_LB.Image = Properties.Resources.Six;
                    break;
            }
        }        

        private void Dice_2_LB_TextChanged(object sender, EventArgs e)
        {
            switch (int.Parse(Dice_2_LB.Text))
            {
                case 1:
                    Dice_2_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_2_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_2_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_2_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_2_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_2_LB.Image = Properties.Resources.Six;
                    break;
            }
        }

        private void Dice_3_LB_TextChanged(object sender, EventArgs e)
        {
            switch (int.Parse(Dice_3_LB.Text))
            {
                case 1:
                    Dice_3_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_3_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_3_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_3_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_3_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_3_LB.Image = Properties.Resources.Six;
                    break;
            }
        }

        private void Dice_4_LB_TextChanged(object sender, EventArgs e)
        {
            switch (int.Parse(Dice_4_LB.Text))
            {
                case 1:
                    Dice_4_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_4_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_4_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_4_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_4_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_4_LB.Image = Properties.Resources.Six;
                    break;
            }
        }

        private void Dice_5_LB_TextChanged(object sender, EventArgs e)
        {
            switch (int.Parse(Dice_5_LB.Text))
            {
                case 1:
                    Dice_5_LB.Image = Properties.Resources.One;
                    break;
                case 2:
                    Dice_5_LB.Image = Properties.Resources.Two;
                    break;
                case 3:
                    Dice_5_LB.Image = Properties.Resources.Three;
                    break;
                case 4:
                    Dice_5_LB.Image = Properties.Resources.Four;
                    break;
                case 5:
                    Dice_5_LB.Image = Properties.Resources.Five;
                    break;
                case 6:
                    Dice_5_LB.Image = Properties.Resources.Six;
                    break;
            }
        }
    }
}
