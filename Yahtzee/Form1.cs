using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Yahtzee
{
    public partial class Form1 : Form
    {

        public bool? Single_mode;
        public int Num_of_opponents;        
        public int Num_of_rerolls;        
        public string[] Player_Names = new string[6];

        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {                       
            Info_LB.Text = "Click on each component to gather more information about them.";                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num_of_opponents = (int)Num_of_opponents_NUD.Value;
            Num_of_rerolls = (int)Num_of_rerolls_NUD.Value;
            Input_name();            
            if (Single_mode==null)
            {
                MessageBox.Show("You didn't select a gamemode!","Error");
            }            
            else
            {
                Form Frm2 = new Form2(Single_mode,Num_of_opponents, Num_of_rerolls,Player_Names,0);
                Frm2.Show();                                
            }                      
        }        

        private void Info_label(object sender, EventArgs e)
        {
            List<string> Info_text = new List<string>();
            var sr = new StreamReader(@"..\..\..\sources\INFO.txt");          

            while(!sr.EndOfStream)
            {
                Info_text.Add(sr.ReadLine());
            }
            sr.Close();

            if (Single_RB.Focused==true)
            {
                Info_LB.Text = Info_text[0];
                Num_of_opponents_NUD.Enabled = false;
            }
            else if (Multi_RB.Focused==true)
            {
                Info_LB.Text = Info_text[1];
            }
            else if (Num_of_opponents_NUD.Focused==true)
            {
                Info_LB.Text = Info_text[2].Replace('N', '\n');
            }
            else if (Joker_TXTB.Focused == true)
            {
                Info_LB.Text = Info_text[3].Replace('#', '\n');
            }
            else if (Num_of_rerolls_NUD.Focused == true)
            {
                Info_LB.Text = Info_text[4];
            }

            if (Single_RB.Checked==false)
            {
                Num_of_opponents_NUD.Enabled = true;
            }
        }

        private void Input_name()
        {
            Player_Names[0] = Name_1_TB.Text;
            Player_Names[1]=Name_2_TB.Text;
            Player_Names[2] = Name_3_TB.Text;
            Player_Names[3] = Name_4_TB.Text;
            Player_Names[4] = Name_5_TB.Text;
            Player_Names[5]=Name_6_TB.Text;            
        }       

        private void Single_RB_Click(object sender, EventArgs e)
        {
            Single_mode = true;
            Num_of_opponents_NUD.Minimum = 0;
            Num_of_opponents_NUD.Value = 0;
        }

        private void Multi_RB_Click(object sender, EventArgs e)
        {
            Single_mode = false;
            Num_of_opponents_NUD.Minimum = 1;
            Num_of_opponents_NUD.Value = 1;
            Name_2_TB.Enabled = true;
        }

        private void Num_of_opponents_NUD_ValueChanged(object sender, EventArgs e)
        {
            switch (Num_of_opponents_NUD.Value)
            {
                case 0:
                    Name_2_TB.Enabled = false;
                    Name_3_TB.Enabled = false;
                    Name_4_TB.Enabled = false;
                    Name_5_TB.Enabled = false;
                    Name_6_TB.Enabled = false;
                    break;
                case 1:
                    Name_2_TB.Enabled = true;
                    Name_3_TB.Enabled = false;
                    Name_4_TB.Enabled = false;
                    Name_5_TB.Enabled = false;
                    Name_6_TB.Enabled = false;
                    break;
                case 2:
                    Name_2_TB.Enabled = true;
                    Name_3_TB.Enabled = true;
                    Name_4_TB.Enabled = false;
                    Name_5_TB.Enabled = false;
                    Name_6_TB.Enabled = false;
                    break;
                case 3:
                    Name_2_TB.Enabled = true;
                    Name_3_TB.Enabled = true;
                    Name_4_TB.Enabled = true;
                    Name_5_TB.Enabled = false;
                    Name_6_TB.Enabled = false;
                    break;
                case 4:
                    Name_2_TB.Enabled = true;
                    Name_3_TB.Enabled = true;
                    Name_4_TB.Enabled = true;
                    Name_5_TB.Enabled = true;
                    Name_6_TB.Enabled = false;
                    break;
                case 5:
                    Name_2_TB.Enabled = true;
                    Name_3_TB.Enabled = true;
                    Name_4_TB.Enabled = true;
                    Name_5_TB.Enabled = true;
                    Name_6_TB.Enabled = true;
                    break;
            }
        }
    }
}