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
    public partial class Settings : Form
    {
        private MainWindow _mainWindow;

        public Settings(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            bindSettings();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (validateSettings())
            {
                updateSettings();
            }

            _mainWindow.Show();
            this.Hide();
        }

        private void bindSettings()
        {
            var settings = SettingsManager.Load();

            SoundOn.Checked = settings.SoundOn;
            Difficulty.SelectedItem = settings.Difficulty;

            Reveal.SelectedItem = settings.MouseBindings.ContainsKey("Reveal") ? settings.MouseBindings["Reveal"] : null;
            Flag.SelectedItem = settings.MouseBindings.ContainsKey("Flag") ? settings.MouseBindings["Flag"] : null;
            Question.SelectedItem = settings.MouseBindings.ContainsKey("Question") ? settings.MouseBindings["Question"] : null;
        }

        private bool validateSettings()
        {
            // 1. Проверка сложности
            var validDifficulties = new List<string> { "Light", "Medium", "Hard" };
            if (!validDifficulties.Contains(Difficulty.SelectedItem?.ToString()))
            {
                MessageBox.Show("Выберите корректную сложность: Light, Medium или Hard.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Проверка уникальности биндингов мыши
            var selectedButtons = new List<string>
            {
                Reveal.SelectedItem?.ToString(),
                Flag.SelectedItem?.ToString(),
                Question.SelectedItem?.ToString()
            };

            // Проверка на null или пустые
            if (selectedButtons.Any(b => string.IsNullOrEmpty(b)))
            {
                MessageBox.Show("Пожалуйста, выберите кнопки для всех действий (Reveal, Flag, Question).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка уникальности
            if (selectedButtons.Distinct().Count() != selectedButtons.Count)
            {
                MessageBox.Show("Каждое действие должно иметь уникальную кнопку мыши.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void updateSettings()
        {
            // Получаем текущие настройки из менеджера
            var settings = SettingsManager.Load();

            // Обновляем значения из формы
            settings.SoundOn = SoundOn.Checked;
            settings.Difficulty = Difficulty.SelectedItem.ToString();
            settings.MouseBindings["Reveal"] = Reveal.SelectedItem.ToString();
            settings.MouseBindings["Flag"] = Flag.SelectedItem.ToString();
            settings.MouseBindings["Question"] = Question.SelectedItem.ToString();

            // Сохраняем настройки
            SettingsManager.Save(settings);
        }
    }
}
