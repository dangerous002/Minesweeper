using System;
using System.IO;
using System.Text.Json;

namespace Minesweeper
{
    public static class RecordManager
    {
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "records.json");
        private static RecordSet _recordSet;

        public static RecordSet Records
        {
            get
            {
                if (_recordSet == null)
                    _recordSet = Load();
                return _recordSet;
            }
        }

        public static void Save()
        {
            string json = JsonSerializer.Serialize(_recordSet, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static RecordSet Load()
        {
            if (!File.Exists(FilePath))
            {
                var empty = new RecordSet();
                _recordSet = empty;
                Save(); // создаём файл с пустыми рекордами
                return empty;
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                _recordSet = JsonSerializer.Deserialize<RecordSet>(json) ?? new RecordSet();
                return _recordSet;
            }
            catch
            {
                _recordSet = new RecordSet(); // если файл повреждён или невалиден
                return _recordSet;
            }
        }

        public static void Reset()
        {
            _recordSet = new RecordSet();
            Save();
        }
    }

    public class RecordSet
    {
        public RecordData Light { get; set; } = new RecordData();
        public RecordData Medium { get; set; } = new RecordData();
        public RecordData Hard { get; set; } = new RecordData();
    }

    public class RecordData
    {
        public int Time { get; set; } = int.MaxValue;
        public double ThreeBV { get; set; } = 0;
        public double ThreeBVPerSecond { get; set; } = 0;
        public double IOE { get; set; } = 0;
    }
}