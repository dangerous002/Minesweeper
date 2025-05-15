using System;
using System.Media;
using System.IO;
using Minesweeper.Properties;

namespace Minesweeper
{
    public static class SoundManager
    {
        public static void PlaySound(string name)
        {
            Stream soundStream = null;

            switch (name)
            {
                case "Reveal":
                    soundStream = Resources.Reveal;  // Имя ресурса в Resources.resx
                    break;
                case "Set":
                    soundStream = Resources.Set;
                    break;
                case "Explosion":
                    soundStream = Resources.Explosion;
                    break;
                case "Victory":
                    soundStream = Resources.Victory;
                    break;
                default:
                    throw new ArgumentException($"Sound '{name}' not found.");
            }

            if (soundStream == null)
                throw new Exception($"Sound stream for '{name}' is null.");

            using (var player = new SoundPlayer(soundStream))
            {
                player.Play();
            }
        }
    }
}