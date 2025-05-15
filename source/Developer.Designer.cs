namespace Minesweeper
{
    partial class Developer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Developer));
            this.DeveloperInfo = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeveloperInfo
            // 
            this.DeveloperInfo.AutoSize = true;
            this.DeveloperInfo.Font = new System.Drawing.Font("Orbitron", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeveloperInfo.Location = new System.Drawing.Point(74, 101);
            this.DeveloperInfo.Name = "DeveloperInfo";
            this.DeveloperInfo.Size = new System.Drawing.Size(240, 176);
            this.DeveloperInfo.TabIndex = 0;
            this.DeveloperInfo.Text = "Разработчик\r\nБланк А.В., группа 2407з\r\n\r\nПреподователь\r\nПравова М.Ю.\r\n\r\nВКИ НГУ\r\n" +
    "Новосибирск, 2025\r\n";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Permanent Marker", 20.25F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(117, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(157, 39);
            this.Title.TabIndex = 1;
            this.Title.Text = "Developer";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Permanent Marker", 14.25F);
            this.ExitButton.Location = new System.Drawing.Point(145, 376);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(93, 44);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Developer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 451);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.DeveloperInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Developer";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DeveloperInfo;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ExitButton;
    }
}