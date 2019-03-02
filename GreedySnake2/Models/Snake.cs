using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GreedySnake.Models
{
    public class Snake:ObservableCollection<Block>, INotifyPropertyChanged
    {
        private int defaultBlocksCount;
        const int DefaultBlocksCount = 3;
        public event PropertyChangedEventHandler PropertyChanged;

        public Position Location
        {
            get
            {
                return this[0].Position;
            }
        }
        public Snake(Position defaultPosition, int blocksCount = DefaultBlocksCount)
        {
            if (blocksCount < DefaultBlocksCount)
            {
                throw new Exception("body's length must be above 2");
            }
            this.defaultBlocksCount = blocksCount;
            for (int i = 0; i < blocksCount; i++)
            {
                Block block = new Block()
                {
                    Position = new Position(defaultPosition.X - i, defaultPosition.Y)
                };
                this.Add(block);
            }
            this[0].IsHead = true;
        }
        public void Eat(Food food)
        {
            this[0].IsHead = false;
            Block block = new Block()
            {
                Position = food.Position,
            };
            this.Insert(0, block);
            this[0].IsHead = true;
        }
        public void Move(Position p)
        {
            int lastIndex = this.Count - 1;
            this[0].IsHead = false;
            Block last = this[lastIndex];
            last.Position = p;
            this.RemoveAt(lastIndex);
            this.Insert(0, last);
            last.IsHead = true;
        }
    }
}
