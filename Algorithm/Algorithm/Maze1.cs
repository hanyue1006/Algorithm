using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorithm.Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    [Description("迷宫1")]
    public class Maze1 : AlgorithmBase
    {
        public int[,] Maze { set; get; }

        public Stack<int> PathX { private set; get; }
        public Stack<int> PathY { private set; get; }

        public int EntryX { set; get; }
        public int EntryY { set; get; }

        public int OutX { set; get; }
        public int OutY { set; get; }
        public bool Flag { get; set; }

        public Maze1()
        {
            base.AlgorithmName = "单路径迷宫";
        }

        /// <summary>
        /// 
        /// </summary>
        public override void InitDefaultData()
        {
            PathX = new Stack<int>(36);
            PathY = new Stack<int>(36);
            EntryX = 1;
            EntryY = 1;
            OutX = 5;
            OutY = 5;
            Flag = false;
            this.Maze = new int[7, 7]
           {
               {2,2,2,2,2,2,2},
               {2,0,0,0,0,0,2},
               {2,0,2,0,2,0,2},
               {2,0,0,2,0,2,2},
               {2,2,0,2,0,2,2},
               {2,0,0,0,0,0,2},
               {2,2,2,2,2,2,2}
           };
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GetInitDataStr()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    sb.Append(Maze[i, j] + "  ");
                }
                sb.Append('\n');
            }

            this.InitDataStr = sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Caculate()
        {
            this.TryNext(EntryX, EntryY);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GetResultStr()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    sb.Append(Maze[i, j] + "  ");
                }
                sb.Append('\n');
            }

            this.ResultStr = sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void TryNext(int x, int y)
        {
            if (!this.Flag)
            {
                this.Maze[x, y] = 1;
            }

            if (x == OutX && y == OutY)
            {
                PathX.Push(x);
                PathY.Push(y);
                this.Flag = true;
            }

            if (!this.Flag)
            {
                ShowResult();
                PathX.Push(x);
                PathY.Push(y);

                if (this.Maze[x + 1, y] == 0)
                {
                    TryNext(x + 1, y);
                }
                if (this.Maze[x - 1, y] == 0)
                {
                    TryNext(x - 1, y);
                }
                if (this.Maze[x, y + 1] == 0)
                {
                    TryNext(x, y + 1);
                }
                if (this.Maze[x, y - 1] == 0)
                {
                    TryNext(x, y - 1);
                }
            }
           
            if (!this.Flag)
            {
                this.Maze[x, y] = 0;
                PathX.Pop();
                PathY.Pop();
            }
        }
    }
}
