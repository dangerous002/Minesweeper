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
    public partial class Records : Form
    {
        private MainWindow _mainWindow;

        public Records(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            RecordSet recordsSet = RecordManager.Load();
            LightRecords.Text = $"Time: {recordsSet.Light.Time / 1000}   3BV: {recordsSet.Light.ThreeBV} \n3BV/s: {recordsSet.Light.ThreeBVPerSecond}   IOE: {recordsSet.Light.IOE}";
            MediumRecords.Text = $"Time: {recordsSet.Medium.Time / 1000}   3BV: {recordsSet.Medium.ThreeBV} \n3BV/s: {recordsSet.Medium.ThreeBVPerSecond}   IOE: {recordsSet.Medium.IOE}";
            HardRecords.Text = $"Time: {recordsSet.Hard.Time / 1000}   3BV: {recordsSet.Hard.ThreeBV} \n3BV/s: {recordsSet.Hard.ThreeBVPerSecond}   IOE: {recordsSet.Hard.IOE}";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _mainWindow.Show();
            this.Close();
        }

        private void HardRecords_Click(object sender, EventArgs e)
        {

        }

        private void MediumRecords_Click(object sender, EventArgs e)
        {

        }
    }
}
