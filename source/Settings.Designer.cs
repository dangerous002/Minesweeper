namespace Minesweeper
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Title = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SoundOn = new System.Windows.Forms.CheckBox();
            this.Difficulty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Reveal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Flag = new System.Windows.Forms.ComboBox();
            this.SetFlag = new System.Windows.Forms.Label();
            this.Question = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Permanent Marker", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(131, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(143, 41);
            this.Title.TabIndex = 1;
            this.Title.Text = "Settings";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Permanent Marker", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(149, 467);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 43);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SoundOn
            // 
            this.SoundOn.AutoSize = true;
            this.SoundOn.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.SoundOn.Location = new System.Drawing.Point(122, 73);
            this.SoundOn.Name = "SoundOn";
            this.SoundOn.Size = new System.Drawing.Size(163, 34);
            this.SoundOn.TabIndex = 3;
            this.SoundOn.Text = "sound on/off";
            this.SoundOn.UseVisualStyleBackColor = true;
            // 
            // Difficulty
            // 
            this.Difficulty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Difficulty.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.Difficulty.FormattingEnabled = true;
            this.Difficulty.Items.AddRange(new object[] {
            "Light",
            "Medium",
            "Hard"});
            this.Difficulty.Location = new System.Drawing.Point(122, 154);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(163, 38);
            this.Difficulty.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.label1.Location = new System.Drawing.Point(153, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Difficulty";
            // 
            // Reveal
            // 
            this.Reveal.AutoCompleteCustomSource.AddRange(new string[] {
            "Light"});
            this.Reveal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reveal.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.Reveal.FormattingEnabled = true;
            this.Reveal.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right"});
            this.Reveal.Location = new System.Drawing.Point(199, 267);
            this.Reveal.Name = "Reveal";
            this.Reveal.Size = new System.Drawing.Size(122, 38);
            this.Reveal.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Reveal";
            // 
            // Flag
            // 
            this.Flag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Flag.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.Flag.FormattingEnabled = true;
            this.Flag.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right"});
            this.Flag.Location = new System.Drawing.Point(199, 327);
            this.Flag.Name = "Flag";
            this.Flag.Size = new System.Drawing.Size(122, 38);
            this.Flag.TabIndex = 8;
            // 
            // SetFlag
            // 
            this.SetFlag.AutoSize = true;
            this.SetFlag.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetFlag.Location = new System.Drawing.Point(101, 330);
            this.SetFlag.Name = "SetFlag";
            this.SetFlag.Size = new System.Drawing.Size(54, 27);
            this.SetFlag.TabIndex = 9;
            this.SetFlag.Text = "flag";
            // 
            // Question
            // 
            this.Question.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Question.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.Question.FormattingEnabled = true;
            this.Question.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right"});
            this.Question.Location = new System.Drawing.Point(199, 387);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(122, 38);
            this.Question.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "question";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Permanent Marker", 15.75F);
            this.label4.Location = new System.Drawing.Point(117, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mouse bingings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(409, 520);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.SetFlag);
            this.Controls.Add(this.Flag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Reveal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.SoundOn);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox SoundOn;
        private System.Windows.Forms.ComboBox Difficulty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Reveal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Flag;
        private System.Windows.Forms.Label SetFlag;
        private System.Windows.Forms.ComboBox Question;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}