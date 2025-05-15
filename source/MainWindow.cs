using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainWindow : Form
    {
        Developer DeveloperForm;
        Settings SettingsForm;
        Records RecordsForm;
        Game GameForm;

        public MainWindow()
        {
            InitializeComponent();

            var gameSettings = SettingsManager.Load();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeveloperButton_Click(object sender, EventArgs e)
        {
            DeveloperForm = new Developer(this);
            DeveloperForm.Show();
            this.Hide();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm = new Settings(this);
            SettingsForm.Show();
            this.Hide();
        }

        private void RecordsButton_Click(object sender, EventArgs e)
        {
            RecordsForm = new Records(this);
            RecordsForm.Show();
            this.Hide();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameForm = new Game(this);
            GameForm.Show();
            this.Hide();
        }
    }
}
