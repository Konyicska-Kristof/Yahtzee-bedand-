namespace Yahtzee
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.Play_BTN = new System.Windows.Forms.Button();
            this.Single_RB = new System.Windows.Forms.RadioButton();
            this.Multi_RB = new System.Windows.Forms.RadioButton();
            this.Gamemode_LB = new System.Windows.Forms.Label();
            this.Num_of_players_LB = new System.Windows.Forms.Label();
            this.Num_of_opponents_NUD = new System.Windows.Forms.NumericUpDown();
            this.Joker_rule_LB = new System.Windows.Forms.Label();
            this.Num_of_rerolls_LB = new System.Windows.Forms.Label();
            this.Num_of_rerolls_NUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Info_LB = new System.Windows.Forms.Label();
            this.Player_names_LB = new System.Windows.Forms.Label();
            this.Name_1_TB = new System.Windows.Forms.TextBox();
            this.Name_1_LB = new System.Windows.Forms.Label();
            this.Name_2_LB = new System.Windows.Forms.Label();
            this.Name_3_LB = new System.Windows.Forms.Label();
            this.Name_4_LB = new System.Windows.Forms.Label();
            this.Name_5_LB = new System.Windows.Forms.Label();
            this.Name_6_LB = new System.Windows.Forms.Label();
            this.Name_2_TB = new System.Windows.Forms.TextBox();
            this.Name_3_TB = new System.Windows.Forms.TextBox();
            this.Name_4_TB = new System.Windows.Forms.TextBox();
            this.Name_5_TB = new System.Windows.Forms.TextBox();
            this.Name_6_TB = new System.Windows.Forms.TextBox();
            this.Joker_TXTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Num_of_opponents_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_of_rerolls_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(329, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(135, 46);
            this.Title.TabIndex = 0;
            this.Title.Text = "Yahtzee";
            // 
            // Play_BTN
            // 
            this.Play_BTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Play_BTN.Location = new System.Drawing.Point(656, 281);
            this.Play_BTN.Name = "Play_BTN";
            this.Play_BTN.Size = new System.Drawing.Size(87, 39);
            this.Play_BTN.TabIndex = 1;
            this.Play_BTN.Text = "Play";
            this.Play_BTN.UseVisualStyleBackColor = true;
            this.Play_BTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // Single_RB
            // 
            this.Single_RB.AutoSize = true;
            this.Single_RB.Location = new System.Drawing.Point(21, 148);
            this.Single_RB.Name = "Single_RB";
            this.Single_RB.Size = new System.Drawing.Size(89, 19);
            this.Single_RB.TabIndex = 2;
            this.Single_RB.Text = "Singleplayer";
            this.Single_RB.UseVisualStyleBackColor = true;
            this.Single_RB.CheckedChanged += new System.EventHandler(this.Info_label);
            this.Single_RB.Click += new System.EventHandler(this.Single_RB_Click);
            // 
            // Multi_RB
            // 
            this.Multi_RB.AutoSize = true;
            this.Multi_RB.Location = new System.Drawing.Point(21, 185);
            this.Multi_RB.Name = "Multi_RB";
            this.Multi_RB.Size = new System.Drawing.Size(85, 19);
            this.Multi_RB.TabIndex = 3;
            this.Multi_RB.Text = "Multiplayer";
            this.Multi_RB.UseVisualStyleBackColor = true;
            this.Multi_RB.CheckedChanged += new System.EventHandler(this.Info_label);
            this.Multi_RB.Click += new System.EventHandler(this.Multi_RB_Click);
            // 
            // Gamemode_LB
            // 
            this.Gamemode_LB.AutoSize = true;
            this.Gamemode_LB.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Gamemode_LB.Location = new System.Drawing.Point(12, 103);
            this.Gamemode_LB.Name = "Gamemode_LB";
            this.Gamemode_LB.Size = new System.Drawing.Size(109, 25);
            this.Gamemode_LB.TabIndex = 4;
            this.Gamemode_LB.Text = "Gamemode";
            // 
            // Num_of_players_LB
            // 
            this.Num_of_players_LB.AutoSize = true;
            this.Num_of_players_LB.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Num_of_players_LB.Location = new System.Drawing.Point(180, 103);
            this.Num_of_players_LB.Name = "Num_of_players_LB";
            this.Num_of_players_LB.Size = new System.Drawing.Size(198, 25);
            this.Num_of_players_LB.TabIndex = 5;
            this.Num_of_players_LB.Text = "Number of opponents";
            // 
            // Num_of_opponents_NUD
            // 
            this.Num_of_opponents_NUD.Enabled = false;
            this.Num_of_opponents_NUD.InterceptArrowKeys = false;
            this.Num_of_opponents_NUD.Location = new System.Drawing.Point(217, 144);
            this.Num_of_opponents_NUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Num_of_opponents_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_of_opponents_NUD.Name = "Num_of_opponents_NUD";
            this.Num_of_opponents_NUD.ReadOnly = true;
            this.Num_of_opponents_NUD.Size = new System.Drawing.Size(120, 23);
            this.Num_of_opponents_NUD.TabIndex = 6;
            this.Num_of_opponents_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Num_of_opponents_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_of_opponents_NUD.ValueChanged += new System.EventHandler(this.Num_of_opponents_NUD_ValueChanged);
            this.Num_of_opponents_NUD.Click += new System.EventHandler(this.Info_label);
            // 
            // Joker_rule_LB
            // 
            this.Joker_rule_LB.AutoSize = true;
            this.Joker_rule_LB.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Joker_rule_LB.Location = new System.Drawing.Point(446, 103);
            this.Joker_rule_LB.Name = "Joker_rule_LB";
            this.Joker_rule_LB.Size = new System.Drawing.Size(94, 25);
            this.Joker_rule_LB.TabIndex = 7;
            this.Joker_rule_LB.Text = "Joker rule";
            // 
            // Num_of_rerolls_LB
            // 
            this.Num_of_rerolls_LB.AutoSize = true;
            this.Num_of_rerolls_LB.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Num_of_rerolls_LB.Location = new System.Drawing.Point(607, 103);
            this.Num_of_rerolls_LB.Name = "Num_of_rerolls_LB";
            this.Num_of_rerolls_LB.Size = new System.Drawing.Size(161, 25);
            this.Num_of_rerolls_LB.TabIndex = 12;
            this.Num_of_rerolls_LB.Text = "Number of rerolls";
            // 
            // Num_of_rerolls_NUD
            // 
            this.Num_of_rerolls_NUD.InterceptArrowKeys = false;
            this.Num_of_rerolls_NUD.Location = new System.Drawing.Point(623, 144);
            this.Num_of_rerolls_NUD.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Num_of_rerolls_NUD.Name = "Num_of_rerolls_NUD";
            this.Num_of_rerolls_NUD.ReadOnly = true;
            this.Num_of_rerolls_NUD.Size = new System.Drawing.Size(120, 23);
            this.Num_of_rerolls_NUD.TabIndex = 14;
            this.Num_of_rerolls_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Num_of_rerolls_NUD.Click += new System.EventHandler(this.Info_label);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Info";
            // 
            // Info_LB
            // 
            this.Info_LB.Location = new System.Drawing.Point(21, 281);
            this.Info_LB.Name = "Info_LB";
            this.Info_LB.Size = new System.Drawing.Size(300, 150);
            this.Info_LB.TabIndex = 16;
            // 
            // Player_names_LB
            // 
            this.Player_names_LB.AutoSize = true;
            this.Player_names_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Player_names_LB.Location = new System.Drawing.Point(348, 245);
            this.Player_names_LB.Name = "Player_names_LB";
            this.Player_names_LB.Size = new System.Drawing.Size(116, 25);
            this.Player_names_LB.TabIndex = 17;
            this.Player_names_LB.Text = "Player names";
            // 
            // Name_1_TB
            // 
            this.Name_1_TB.Location = new System.Drawing.Point(373, 278);
            this.Name_1_TB.Name = "Name_1_TB";
            this.Name_1_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_1_TB.TabIndex = 18;
            // 
            // Name_1_LB
            // 
            this.Name_1_LB.AutoSize = true;
            this.Name_1_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_1_LB.Location = new System.Drawing.Point(348, 276);
            this.Name_1_LB.Name = "Name_1_LB";
            this.Name_1_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_1_LB.TabIndex = 19;
            this.Name_1_LB.Text = "1";
            // 
            // Name_2_LB
            // 
            this.Name_2_LB.AutoSize = true;
            this.Name_2_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_2_LB.Location = new System.Drawing.Point(348, 301);
            this.Name_2_LB.Name = "Name_2_LB";
            this.Name_2_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_2_LB.TabIndex = 20;
            this.Name_2_LB.Text = "2";
            // 
            // Name_3_LB
            // 
            this.Name_3_LB.AutoSize = true;
            this.Name_3_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_3_LB.Location = new System.Drawing.Point(348, 326);
            this.Name_3_LB.Name = "Name_3_LB";
            this.Name_3_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_3_LB.TabIndex = 21;
            this.Name_3_LB.Text = "3";
            // 
            // Name_4_LB
            // 
            this.Name_4_LB.AutoSize = true;
            this.Name_4_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_4_LB.Location = new System.Drawing.Point(479, 276);
            this.Name_4_LB.Name = "Name_4_LB";
            this.Name_4_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_4_LB.TabIndex = 22;
            this.Name_4_LB.Text = "4";
            // 
            // Name_5_LB
            // 
            this.Name_5_LB.AutoSize = true;
            this.Name_5_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_5_LB.Location = new System.Drawing.Point(479, 301);
            this.Name_5_LB.Name = "Name_5_LB";
            this.Name_5_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_5_LB.TabIndex = 23;
            this.Name_5_LB.Text = "5";
            // 
            // Name_6_LB
            // 
            this.Name_6_LB.AutoSize = true;
            this.Name_6_LB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name_6_LB.Location = new System.Drawing.Point(479, 326);
            this.Name_6_LB.Name = "Name_6_LB";
            this.Name_6_LB.Size = new System.Drawing.Size(22, 25);
            this.Name_6_LB.TabIndex = 24;
            this.Name_6_LB.Text = "6";
            // 
            // Name_2_TB
            // 
            this.Name_2_TB.Enabled = false;
            this.Name_2_TB.Location = new System.Drawing.Point(373, 304);
            this.Name_2_TB.Name = "Name_2_TB";
            this.Name_2_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_2_TB.TabIndex = 25;
            // 
            // Name_3_TB
            // 
            this.Name_3_TB.Enabled = false;
            this.Name_3_TB.Location = new System.Drawing.Point(373, 329);
            this.Name_3_TB.Name = "Name_3_TB";
            this.Name_3_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_3_TB.TabIndex = 26;
            // 
            // Name_4_TB
            // 
            this.Name_4_TB.Enabled = false;
            this.Name_4_TB.Location = new System.Drawing.Point(507, 279);
            this.Name_4_TB.Name = "Name_4_TB";
            this.Name_4_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_4_TB.TabIndex = 27;
            // 
            // Name_5_TB
            // 
            this.Name_5_TB.Enabled = false;
            this.Name_5_TB.Location = new System.Drawing.Point(507, 304);
            this.Name_5_TB.Name = "Name_5_TB";
            this.Name_5_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_5_TB.TabIndex = 28;
            // 
            // Name_6_TB
            // 
            this.Name_6_TB.Enabled = false;
            this.Name_6_TB.Location = new System.Drawing.Point(507, 329);
            this.Name_6_TB.Name = "Name_6_TB";
            this.Name_6_TB.Size = new System.Drawing.Size(100, 23);
            this.Name_6_TB.TabIndex = 29;
            // 
            // Joker_TXTB
            // 
            this.Joker_TXTB.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Joker_TXTB.Location = new System.Drawing.Point(432, 141);
            this.Joker_TXTB.Name = "Joker_TXTB";
            this.Joker_TXTB.ReadOnly = true;
            this.Joker_TXTB.Size = new System.Drawing.Size(121, 31);
            this.Joker_TXTB.TabIndex = 31;
            this.Joker_TXTB.Text = "Free choice";
            this.Joker_TXTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Joker_TXTB.Click += new System.EventHandler(this.Info_label);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Joker_TXTB);
            this.Controls.Add(this.Name_6_TB);
            this.Controls.Add(this.Name_5_TB);
            this.Controls.Add(this.Name_4_TB);
            this.Controls.Add(this.Name_3_TB);
            this.Controls.Add(this.Name_2_TB);
            this.Controls.Add(this.Name_6_LB);
            this.Controls.Add(this.Name_5_LB);
            this.Controls.Add(this.Name_4_LB);
            this.Controls.Add(this.Name_3_LB);
            this.Controls.Add(this.Name_2_LB);
            this.Controls.Add(this.Name_1_LB);
            this.Controls.Add(this.Name_1_TB);
            this.Controls.Add(this.Player_names_LB);
            this.Controls.Add(this.Info_LB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Num_of_rerolls_NUD);
            this.Controls.Add(this.Num_of_rerolls_LB);
            this.Controls.Add(this.Joker_rule_LB);
            this.Controls.Add(this.Num_of_opponents_NUD);
            this.Controls.Add(this.Num_of_players_LB);
            this.Controls.Add(this.Gamemode_LB);
            this.Controls.Add(this.Multi_RB);
            this.Controls.Add(this.Single_RB);
            this.Controls.Add(this.Play_BTN);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Yahtzee - Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Num_of_opponents_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_of_rerolls_NUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Title;
        private Button Play_BTN;
        private RadioButton Single_RB;
        private RadioButton Multi_RB;
        private Label Gamemode_LB;
        private Label Num_of_players_LB;
        private NumericUpDown Num_of_opponents_NUD;
        private Label Joker_rule_LB;
        private Label Num_of_rerolls_LB;
        private NumericUpDown Num_of_rerolls_NUD;
        private Label label2;
        private Label Info_LB;
        private Label Player_names_LB;
        private TextBox Name_1_TB;
        private Label Name_1_LB;
        private Label Name_2_LB;
        private Label Name_3_LB;
        private Label Name_4_LB;
        private Label Name_5_LB;
        private Label Name_6_LB;
        private TextBox Name_2_TB;
        private TextBox Name_3_TB;
        private TextBox Name_4_TB;
        private TextBox Name_5_TB;
        private TextBox Name_6_TB;
        private TextBox Joker_TXTB;
    }
}