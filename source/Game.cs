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
    public partial class Game : Form
    {
        public Graphics graphics;

        private MainWindow _mainWindow;

        private MinesweeperGame _game;

        // Хранит биндинги кнопок мыши из настроек
        private Dictionary<string, string> _mouseBindings;

        public Game(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
            graphics = this.CreateGraphics();

            loadMouseBindings();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _mainWindow.Show();
            this.Close();
        }

        private void loadMouseBindings()
        {
            var settings = SettingsManager.Load();
            _mouseBindings = settings.MouseBindings ?? new Dictionary<string, string>()
            {
                { "Reveal", "Left" },
                { "Flag", "Right" },
                { "Question", "Middle" }
            };
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _game?.Dispose();
            _game = new MinesweeperGame(SettingsManager.Load().Difficulty, this, new Point(10, 10), SettingsManager.Load().SoundOn);

            _game.Start();
            _game.DrawField();
        }

        private void Game_MouseDown(object sender, MouseEventArgs e)
        {
            string clickedButton = e.Button.ToString(); // "Left", "Right", "Middle", "XButton1", "XButton2"

            if (_mouseBindings.TryGetValue("Reveal", out string revealBtn) && revealBtn == clickedButton)
            {
                _game.HandleCell(e.X, e.Y);
            }
            else if (_mouseBindings.TryGetValue("Flag", out string flagBtn) && flagBtn == clickedButton)
            {
                _game.SetFlag(e.X, e.Y);
            }
            else if (_mouseBindings.TryGetValue("Question", out string questionBtn) && questionBtn == clickedButton)
            {
                _game.SetQuestion(e.X, e.Y);
            }
        }
    }
}
