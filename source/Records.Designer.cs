namespace Minesweeper
{
    partial class Records
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Records));
            this.Title = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LightRecords = new System.Windows.Forms.Label();
            this.MediumRecords = new System.Windows.Forms.Label();
            this.HardRecords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Permanent Marker", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(131, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(127, 39);
            this.Title.TabIndex = 1;
            this.Title.Text = "Records";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Permanent Marker", 14.25F);
            this.ExitButton.Location = new System.Drawing.Point(138, 420);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(95, 33);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Permanent Marker", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Light";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Permanent Marker", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Medium";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Permanent Marker", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hard";
            // 
            // LightRecords
            // 
            this.LightRecords.AutoSize = true;
            this.LightRecords.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightRecords.Location = new System.Drawing.Point(73, 121);
            this.LightRecords.Name = "LightRecords";
            this.LightRecords.Size = new System.Drawing.Size(19, 27);
            this.LightRecords.TabIndex = 6;
            this.LightRecords.Text = "1";
            // 
            // MediumRecords
            // 
            this.MediumRecords.AutoSize = true;
            this.MediumRecords.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumRecords.Location = new System.Drawing.Point(67, 228);
            this.MediumRecords.Name = "MediumRecords";
            this.MediumRecords.Size = new System.Drawing.Size(25, 27);
            this.MediumRecords.TabIndex = 7;
            this.MediumRecords.Text = "2";
            this.MediumRecords.Click += new System.EventHandler(this.MediumRecords_Click);
            // 
            // HardRecords
            // 
            this.HardRecords.AutoSize = true;
            this.HardRecords.Font = new System.Drawing.Font("Permanent Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardRecords.Location = new System.Drawing.Point(68, 330);
            this.HardRecords.Name = "HardRecords";
            this.HardRecords.Size = new System.Drawing.Size(24, 27);
            this.HardRecords.TabIndex = 8;
            this.HardRecords.Text = "3";
            this.HardRecords.Click += new System.EventHandler(this.HardRecords_Click);
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 465);
            this.Controls.Add(this.HardRecords);
            this.Controls.Add(this.MediumRecords);
            this.Controls.Add(this.LightRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Records";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LightRecords;
        private System.Windows.Forms.Label MediumRecords;
        private System.Windows.Forms.Label HardRecords;
    }
}