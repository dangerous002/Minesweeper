using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Minesweeper
{
    public class GameSettings
    {
        public bool SoundOn { get; set; } = true;
        public string Difficulty { get; set; } = "Light";
        public Dictionary<string, string> MouseBindings { get; set; } = new Dictionary<string, string>();
    }

    public static class SettingsManager
    {
        public static string ConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public static GameSettings Load()
        {
            if (!File.Exists(ConfigPath))
            {
                var defaultSettings = new GameSettings
                {
                    SoundOn = true,
                    Difficulty = "Light",
                    MouseBindings = new Dictionary<string, string>
                    {
                        { "Reveal", "Left" },
                        { "Question", "Middle" },
                        { "Flag", "Right" },
                    }
                };

                Save(defaultSettings);
                return defaultSettings;
            }

            string json = File.ReadAllText(ConfigPath);
            return JsonSerializer.Deserialize<GameSettings>(json);
        }

        public static void Save(GameSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
        }
    }
}