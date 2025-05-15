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
    public partial class Developer : Form
    {
        private MainWindow _mainWindow;

        public Developer(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;   
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainWindow.Show();
        }
    }
}
