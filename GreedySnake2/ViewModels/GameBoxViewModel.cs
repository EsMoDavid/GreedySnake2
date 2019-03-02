using GreedySnake.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GreedySnake.ViewModels
{
    public class GameBoxViewModel:INotifyPropertyChanged
    {
        private int height = 30;
        private int width = 30;
        private bool isDead = false;
        Direction? lastDirection;
        DispatcherTimer timerInterval;
        Random rnd;
        List<int> totalCells;

        public ArrowKeyCommand ArrowKeyCommand
        {
            get;private set;
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (this.width != value)
                {
                    this.width = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Width)));
                }
            }
        }
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (this.height != value)
                {
                    this.height = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Height)));
                }
            }
        }
        public bool IsDead
        {
            get
            {
                return this.isDead;
            }
            set
            {
                if (this.isDead != value)
                {
                    this.isDead = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckIfDead)));
                }
            }
        }
        public Food CurrentFood { get; private set; }
        public Snake Snake { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
     
        public GameBoxViewModel()
        {
            int width = this.Width;
            int height = this.Height;
            int totalCount = width * height;
            this.totalCells = new List<int>(totalCount);
            this.CurrentFood = new Food();
            for (int i = 0; i < totalCount; i++)
            {
                totalCells.Add(i);
            }
            this.rnd = new Random();
            this.timerInterval = new DispatcherTimer();
            this.timerInterval.Interval = TimeSpan.FromMilliseconds(200);
            this.timerInterval.Tick += TimerInterval_Tick;
            this.Snake = new Snake(new Position(width / 2, height / 2));
            this.ArrowKeyCommand = new ArrowKeyCommand();
        }

        public void StartGame()
        {
            this.GenerateFood();
            this.timerInterval.Start();
        }
        public void StopGame()
        {
            this.timerInterval.Stop();
        }
        public void AcceptedKey(Key key)
        {
            switch (key)
            {
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                    var direction = this.KeyToDirection(key);
                    if (!this.IsOpposite(direction.Value))
                    {
                        this.lastDirection = direction;
                    }
                    break;
                default:
                    break;
            }
        }
        private void TimerInterval_Tick(object sender, EventArgs e)
        {
            if (this.lastDirection.HasValue)
            {
                this.MoveSnake(this.lastDirection.Value);
            }
        }

        private bool IsOpposite(Direction target)
        {
            if (!this.lastDirection.HasValue)
            {
                return false;
            }
            return (target == Direction.Left && this.lastDirection == Direction.Right)
                || (target == Direction.Right && this.lastDirection == Direction.Left)
                || (target == Direction.Up && this.lastDirection == Direction.Down)
                || (target == Direction.Down && this.lastDirection == Direction.Up);
        }

        private void MoveSnake(Direction direction)
        {
            Position target = this.GetTargetPosition(this.Snake.Location, direction);
            if (this.CurrentFood.Position == target)
            {
                this.Snake.Eat(this.CurrentFood);
                this.GenerateFood();
            }
            else if (CheckIfDead(target))
            {
                this.StopGame();
            }
            else
            {
                this.Snake.Move(target);
                this.lastDirection = direction;
            }
        }
        private bool CheckIfDead(Position target)
        {
            bool isOutofBounds = target.X < 0 || target.Y < 0 || target.X >= this.Width || target.Y >= this.Height;
            if (isOutofBounds)
            {
                return true;
            }
            else
            {
                var body = this.Snake.FirstOrDefault(x => x.Position == target);
                return body != null && body!=this.Snake[this.Snake.Count-1];
            }
        }
        private Position GetTargetPosition(Position p, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    p = new Position(p.X - 1, p.Y);
                    break;
                case Direction.Up:
                    p = new Position(p.X, p.Y - 1);
                    break;
                case Direction.Right:
                    p = new Position(p.X + 1, p.Y);
                    break;
                case Direction.Down:
                    p = new Position(p.X, p.Y + 1);
                    break;
                default:
                    break;
            }
            return p;
        }
        private Direction? KeyToDirection(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    return Direction.Up;
                case Key.Down:
                    return Direction.Down;
                case Key.Left:
                    return Direction.Left;
                case Key.Right:
                    return Direction.Right;
            }
            return null;
        }
        private void GenerateFood()
        {
            int totalCount = this.Width * this.Height;
            List<int> availableCells = this.totalCells.ToList();
            List<Block> blocks = this.Snake.ToList();
            availableCells.RemoveAll(i =>
            {
                var block = blocks.FirstOrDefault(b => b.Position.Y * this.Width + b.Position.X == i);
                var result = block != null;
                if (result)
                {
                    blocks.Remove(block);
                }
                return result;
            });

            int rndIndex = this.rnd.Next(0, availableCells.Count);
            int position = availableCells[rndIndex];
            int x = position % this.Width;
            int y = position / this.Height;
            this.CurrentFood.Position = new Position(x, y);
        }
    }
}

