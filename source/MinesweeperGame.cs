using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Minesweeper.Properties;
using System.Media;

namespace Minesweeper
{

    internal class MinesweeperGame : IDisposable
    {
        private Game _parentForm;

        private static System.Timers.Timer _timer;
        private int _time = 0;
        private int _timerInterval = 10;

        private int _cellSize = 48;
        private Point _startPoint;

        private int _rowCount;
        private int _columnCount;
        private int _mineCount;

        private Cell[,] _field;

        private bool _running = false;
        private bool _firstClick = true;

        private int _3BV;
        private double _3BVs;
        private double _IOE;
        private int _totalClicks = 0;

        private bool _soundOn;

        private string _difficulty;

        public MinesweeperGame(string gameDifficulty, Game parentForm, Point startPoint, bool soundOn)
        {
            this._parentForm = parentForm;
            this._startPoint = startPoint;
            this._soundOn = soundOn;
            this._difficulty = gameDifficulty;

            switch (gameDifficulty)
            {
                case "Light":
                    this._rowCount = 8;
                    this._columnCount = 8;
                    this._mineCount = 10;
                    break;
                case "Medium":
                    this._rowCount = 12;
                    this._columnCount = 12;
                    this._mineCount = 30;
                    break;
                case "Hard":
                    this._rowCount = 16;
                    this._columnCount = 16;
                    this._mineCount = 50;
                    break;
                default:
                    this._rowCount = 12;
                    this._columnCount = 12;
                    this._mineCount = 30;
                    break;
            }

            _parentForm.graphics.Clear(_parentForm.BackColor);
            initalizeField();

            _3BV = calculate3BV();
        }

        private void initalizeField()
        {
            _field = new Cell[_rowCount, _columnCount];
            Random rand = new Random();
            HashSet<(int, int)> minePositions = new HashSet<(int, int)>();

            // Расстановка мин
            while (minePositions.Count < _mineCount)
            {
                int r = rand.Next(_rowCount);
                int c = rand.Next(_columnCount);
                minePositions.Add((r, c));
            }

            // Инициализация ячеек: все скрыты, тип Unknown
            for (int r = 0; r < _rowCount; r++)
            {
                for (int c = 0; c < _columnCount; c++)
                {
                    bool isMine = minePositions.Contains((r, c));
                    _field[r, c] = new Cell(isMine, CellType.unknown);
                }
            }
        }

        private void SetTimer()
        {
            _timer = new System.Timers.Timer(_timerInterval);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _time += _timerInterval;

            try
            {
                _parentForm.Invoke(new Action(() =>
                    {
                        _parentForm.Time.Text = $"Time: {_time / 1000.0:F2}";
                        _parentForm.Mines.Text = $"Mines: {_mineCount}";
                    }));
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void Start()
        {
            SetTimer();
            _running = true;
        }

        public void DrawField()
        {
            int posX = _startPoint.X;
            int posY = _startPoint.Y;

            for (int row = 0; row < _rowCount; row++)
            {
                posX = _startPoint.X;
                for (int column = 0; column < _columnCount; column++)
                {
                    switch (_field[row, column].Type)
                    {
                        case CellType.unknown:
                            _parentForm.graphics.DrawImage(Resources.unknown, new Point(posX, posY));
                            break;
                        case CellType._1:
                            _parentForm.graphics.DrawImage(Resources._1, new Point(posX, posY));
                            break;
                        case CellType._2:
                            _parentForm.graphics.DrawImage(Resources._2, new Point(posX, posY));
                            break;
                        case CellType._3:
                            _parentForm.graphics.DrawImage(Resources._3, new Point(posX, posY));
                            break;
                        case CellType._4:
                            _parentForm.graphics.DrawImage(Resources._4, new Point(posX, posY));
                            break;
                        case CellType._5:
                            _parentForm.graphics.DrawImage(Resources._5, new Point(posX, posY));
                            break;
                        case CellType._6:
                            _parentForm.graphics.DrawImage(Resources._6, new Point(posX, posY));
                            break;
                        case CellType._7:
                            _parentForm.graphics.DrawImage(Resources._7, new Point(posX, posY));
                            break;
                        case CellType._8:
                            _parentForm.graphics.DrawImage(Resources._8, new Point(posX, posY));
                            break;
                        case CellType.bomb:
                            _parentForm.graphics.DrawImage(Resources.bomb, new Point(posX, posY));
                            break;
                        case CellType.bomb_exploded:
                            _parentForm.graphics.DrawImage(Resources.bomb_exploded, new Point(posX, posY));
                            break;
                        case CellType.empty:
                            _parentForm.graphics.DrawImage(Resources.empty, new Point(posX, posY));
                            break;
                        case CellType.flag:
                            _parentForm.graphics.DrawImage(Resources.flag, new Point(posX, posY));
                            break;
                        case CellType.question:
                            _parentForm.graphics.DrawImage(Resources.question, new Point(posX, posY));
                            break;
                        default:
                            break;

                    }

                    posX += _cellSize;
                }
                posY += _cellSize;
            }
        }

        public void HandleCell(int posX, int posY)
        {
            if (!_running) return;

            int column = getCellPosition(posX, posY)[0];
            int row = getCellPosition(posX, posY)[1];

            if (!IsInBounds(row, column))
                return;

            _totalClicks++;

            if (_firstClick)
            {
                if (_soundOn) SoundManager.PlaySound("Reveal");

                ensureSafeFirstClick(row, column);
                _firstClick = false;
                return;
            }
                

            var cell = _field[row, column];

            if (cell.Type == CellType.flag)
            {
                if (checkWin())
                    win();
                
                return;
            }
                

            switch (cell.Type)
            {
                case CellType._1:
                case CellType._2:
                case CellType._3:
                case CellType._4:
                case CellType._5:
                case CellType._6:
                case CellType._7:
                case CellType._8:
                    int expectedFlags = (int)cell.Type; // _1 → 0, _2 → 1, и т.д.
                    expectedFlags += 1; // корректировка из-за enum (_1 = 0)

                    int actualFlags = CountFlagsAround(row, column);
                    if (actualFlags == expectedFlags)
                    {
                        if (_soundOn) SoundManager.PlaySound("Reveal");

                        for (int dr = -1; dr <= 1; dr++)
                        {
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                int r = row + dr;
                                int c = column + dc;

                                if (IsInBounds(r, c))
                                {
                                    var neighbor = _field[r, c];

                                    if (neighbor.Type == CellType.unknown)
                                    {
                                        if (neighbor.Mine)
                                        {
                                            neighbor.Type = CellType.bomb_exploded;
                                            death();
                                            DrawField();

                                            return;
                                        }
                                        else
                                        {
                                            RevealRecursive(r, c);

                                            if (checkWin())
                                                win();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                default:
                    if (cell.Mine)
                    {
                        cell.Type = CellType.bomb_exploded;
                        death();
                        DrawField();
                        return;
                    }

                    if (_soundOn) SoundManager.PlaySound("Reveal");

                    RevealRecursive(row, column);

                    if (checkWin())
                        win();

                    break;
            }

            DrawField();
        }

        public void SetFlag(int posX, int posY)
        {
            if (!_running) return;

            int column = getCellPosition(posX, posY)[0];
            int row = getCellPosition(posX, posY)[1];

            if (IsInBounds(row, column))
            {
                if (_soundOn) SoundManager.PlaySound("Set");

                _totalClicks++;

                if (_field[row, column].Type == CellType.unknown || _field[row, column].Type == CellType.question)
                    _field[row, column].Type = CellType.flag;
                else if (_field[row, column].Type == CellType.flag)
                    _field[row, column].Type = CellType.unknown;
                else
                    return;
            }

            this.DrawField();

            if (checkWin())
                win();

            return;
        }

        public void SetQuestion(int posX, int posY)
        {
            if (!_running) return;

            int column = getCellPosition(posX, posY)[0];
            int row = getCellPosition(posX, posY)[1];

            if (IsInBounds(row, column))
            {
                if (_soundOn) SoundManager.PlaySound("Set");

                _totalClicks++;

                if (_field[row, column].Type == CellType.unknown || _field[row, column].Type == CellType.flag)
                    _field[row, column].Type = CellType.question;
                else if (_field[row, column].Type == CellType.question)
                    _field[row, column].Type = CellType.unknown;
                else
                    return;
            }

            this.DrawField();

            if (checkWin())
                win();

            return;
        }

        private void ensureSafeFirstClick(int row, int column)
        {
            // Определим все координаты вокруг (включая саму ячейку)
            List<(int, int)> safeZone = new List<(int, int)>();
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int r = row + dr;
                    int c = column + dc;
                    if (IsInBounds(r, c))
                        safeZone.Add((r, c));
                }
            }

            // Удалим все мины из safeZone
            int minesToRelocate = 0;
            foreach (var (r, c) in safeZone)
            {
                if (_field[r, c].Mine)
                {
                    _field[r, c].Mine = false;
                    minesToRelocate++;
                }
            }

            // Переносим мины в другие безопасные места
            Random rand = new Random();
            while (minesToRelocate > 0)
            {
                int r = rand.Next(_rowCount);
                int c = rand.Next(_columnCount);

                if (!_field[r, c].Mine && !safeZone.Contains((r, c)))
                {
                    _field[r, c].Mine = true;
                    minesToRelocate--;
                }
            }

            // Раскрываем центральную и соседние клетки
            foreach (var (r, c) in safeZone)
            {
                RevealRecursive(r, c);
            }
        }

        public void Dispose()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }

        private List<int> getCellPosition(int posX, int posY)
        {
            return new List<int> { (posX - _startPoint.X) / _cellSize, (posY - _startPoint.Y) / _cellSize };
        }

        private void RevealRecursive(int row, int column)
        {
            if (!IsInBounds(row, column))
                return;

            var cell = _field[row, column];

            if (cell.Type != CellType.unknown)
                return;

            int minesAround = CountMinesAround(row, column);

            if (minesAround == 0)
            {
                cell.Type = CellType.empty;

                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        if (dRow != 0 || dCol != 0)
                            RevealRecursive(row + dRow, column + dCol);
                    }
                }
            }
            else
            {
                cell.Type = (CellType)Enum.Parse(typeof(CellType), $"_{minesAround}");
            }

            if (checkWin())
                win();
        }

        private bool IsInBounds(int row, int column)
        {
            return row >= 0 && column >= 0 && row < _field.GetLength(0) && column < _field.GetLength(1);
        }

        private int CountMinesAround(int row, int column)
        {
            int count = 0;
            for (int dRow = -1; dRow <= 1; dRow++)
            {
                for (int dCol = -1; dCol <= 1; dCol++)
                {
                    if (dRow == 0 && dCol == 0)
                        continue;

                    int r = row + dRow;
                    int c = column + dCol;

                    if (IsInBounds(r, c) && _field[r, c].Mine)
                        count++;
                }
            }
            return count;
        }

        private void discoverTrueField()
        {
            for (int row = 0; row < _rowCount; row++)
                for (int column = 0; column < _columnCount; column++)
                    if (_field[row, column].Mine && _field[row, column].Type != CellType.bomb_exploded)
                        _field[row, column].Type = CellType.bomb;
        }

        private void death()
        {
            if (_soundOn) SoundManager.PlaySound("Explosion");

            discoverTrueField();
            DrawField();
            _timer.Stop();
            _running = false;

            _parentForm.graphics.DrawString($"Ты взорвался :(", new Font("Permanent Marker", 20, FontStyle.Bold), new SolidBrush(Color.Black), new Point(10, _parentForm.Height - 110));
        }

        private void win()
        {
            if (_soundOn) SoundManager.PlaySound("Victory");

            _timer.Stop();
            _running = false;

            _3BVs = Math.Round((Convert.ToDouble(_3BV) / (Convert.ToDouble(_time) / 1000.0)), 2);
            _IOE = Math.Round(((Convert.ToDouble(_3BV) / _totalClicks) * 100), 2);

            _parentForm.graphics.DrawString($"3BV: {_3BV}   3BV/s: {_3BVs}  IOE: {_IOE}", new Font("Permanent Marker", 20, FontStyle.Bold), new SolidBrush(Color.Black), new Point(10, _parentForm.Height - 90));

            checkRecord();
        }


        private void checkRecord()
        {
            var records = RecordManager.Records;
            RecordData currentRecord;

            if (_difficulty == "Light")
                currentRecord = records.Light;
            else if (_difficulty == "Medium")
                currentRecord = records.Medium;
            else if (_difficulty == "Hard")
                currentRecord = records.Hard;
            else
                return;

            var beaten = new List<string>();

            // Сравниваем и обновляем рекорды
            if (_time < currentRecord.Time)
            {
                currentRecord.Time = _time;
                beaten.Add("Time");
            }
            if (_3BV > currentRecord.ThreeBV)
            {
                currentRecord.ThreeBV = _3BV;
                beaten.Add("3BV");
            }
            if (_3BVs > currentRecord.ThreeBVPerSecond)
            {
                currentRecord.ThreeBVPerSecond = _3BVs;
                beaten.Add("3BV/s");
            }
            if (_IOE > currentRecord.IOE)
            {
                currentRecord.IOE = _IOE;
                beaten.Add("IOE");
            }

            // Если есть новые рекорды — сохраняем и показываем сообщение
            if (beaten.Count > 0)
            {
                RecordManager.Save();
                string message = "New records: " + string.Join(", ", beaten);
                _parentForm.graphics.DrawString(message, new Font("Permanent Marker", 20, FontStyle.Bold), new SolidBrush(Color.Black), new Point(10, _parentForm.Height - 130));
            }
        }

        private int CountFlagsAround(int row, int column)
        {
            int count = 0;
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int r = row + dr;
                    int c = column + dc;

                    if (IsInBounds(r, c) && _field[r, c].Type == CellType.flag)
                        count++;
                }
            }
            return count;
        }

        private bool checkWin()
        {
            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _columnCount; col++)
                {
                    var cell = _field[row, col];

                    if (cell.Mine)
                    {
                        // Если мина не помечена флагом — проигрыш
                        if (cell.Type != CellType.flag)
                            return false;
                    }
                    else
                    {
                        // Если не мина, но клетка не открыта — проигрыш
                        if (cell.Type == CellType.unknown || cell.Type == CellType.flag)
                            return false;
                    }
                }
            }

            return true;
        }

        private int calculate3BV()
        {
            bool[,] visited = new bool[_rowCount, _columnCount];
            int threeBV = 0;

            // 1. Считаем все пустые "вспышки" (ячейки без мин вокруг)
            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _columnCount; col++)
                {
                    if (!visited[row, col] && !_field[row, col].Mine)
                    {
                        int minesAround = CountMinesAround(row, col);
                        if (minesAround == 0)
                        {
                            // Новая пустая область
                            revealFor3BV(row, col, visited);
                            threeBV++;
                        }
                    }
                }
            }

            // 2. Считаем числовые клетки, которые не попали в "вспышки"
            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _columnCount; col++)
                {
                    if (!visited[row, col] && !_field[row, col].Mine)
                    {
                        int minesAround = CountMinesAround(row, col);
                        if (minesAround > 0)
                        {
                            threeBV++;
                            visited[row, col] = true;
                        }
                    }
                }
            }

            return threeBV;
        }

        private void revealFor3BV(int row, int col, bool[,] visited)
        {
            if (!IsInBounds(row, col)) return;
            if (visited[row, col]) return;
            if (_field[row, col].Mine) return;

            visited[row, col] = true;

            int minesAround = CountMinesAround(row, col);
            if (minesAround == 0)
            {
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        if (dRow != 0 || dCol != 0)
                            revealFor3BV(row + dRow, col + dCol, visited);
                    }
                }
            }
        }
    }

    enum CellType
    {
        _1,
        _2,
        _3, 
        _4, 
        _5, 
        _6, 
        _7,
        _8,
        bomb,
        bomb_exploded,
        empty,
        flag,
        question,
        unknown,
    }

    class Cell
    {
        public bool Mine;
        public CellType Type;

        public Cell(bool mine, CellType type)
        {
            this.Mine = mine;
            this.Type = type;
        }
    }
}
