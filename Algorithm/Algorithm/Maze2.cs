using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Algorithm.Algorithm
{
    /// <summary>
    /// 迷宫2
    /// </summary>
    [Description("多路径迷宫")]
    public class Maze2 : AlgorithmBase
    {

        public int[,] Maze { set; get; }

        public Stack<int> PathX { private set; get; }
        public Stack<int> PathY { private set; get; }

        public int EntryX { set; get; }
        public int EntryY { set; get; }

        public int OutX { set; get; }
        public int OutY { set; get; }
        public bool Flag { get; set; }

        public List<int[,]> Record { private set; get; }

        public Maze2()
        {
            base.AlgorithmName = "迷宫2";
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
            OutX = 7;
            OutY = 7;
            Flag = false;
            this.Record = new List<int[,]>();
            this.InitMaze();
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
            
            for (int i = 0; i < this.Record.Count; i++)
            {
                this.InitMaze();
                var intse = this.Record[i];
                Console.WriteLine("Path " + i + " :  \n");
                for (int j = 0; j < intse.GetLength(0); j++)
                {
                    this.Maze[intse[j, 0], intse[j, 1]] = 1;
                }
                this.ShowResult();
            }

            // 显示最短路径
            this.InitMaze();
            int minNum = int.MaxValue;
            int[,] minPath = new int[,] { };
            foreach (var intse in this.Record)
            {
                if (intse.GetLength(0) < minNum)
                {
                    minNum = intse.GetLength(0);
                    minPath = intse;
                }
            }
            Console.WriteLine("The MinPath  :  \n");
            for (int i = 0; i < minPath.GetLength(0); i++)
            {
                this.Maze[minPath[i, 0], minPath[i, 1]] = 1;
            }
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
                //ShowResult();
                PathX.Push(x);
                PathY.Push(y);
            }

            if (x == OutX && y == OutY)
            {
                PathX.Push(x);
                PathY.Push(y);
                this.SetRecord(PathX.ToArray(), PathY.ToArray());
                PathX.Pop();
                PathY.Pop();
                //this.Flag = true;
            }

            if (!this.Flag)
            {
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

                this.Maze[x, y] = 0;
                PathX.Pop();
                PathY.Pop();
            }
        }

        private void SetRecord(int[] xInts, int[] yiInts)
        {
            int count = xInts.Length;
            int[,] result = new int[count, 2];

            for (int i = 0; i < count; i++)
            {
                result[i, 0] = xInts[i];
                result[i, 1] = yiInts[i];
            }

            this.Record.Add(result);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitMaze()
        {
            this.Maze = new int[9, 9]
           {
               {2,2,2,2,2,2,2,2,2},
               {2,0,0,0,0,0,0,0,2},
               {2,0,2,2,0,2,2,0,2},
               {2,0,2,0,0,2,0,0,2},
               {2,0,2,0,2,0,2,0,2},
               {2,0,0,0,0,0,2,0,2},
               {2,2,0,2,2,0,2,2,2},
               {2,0,0,0,0,0,0,0,2},
               {2,2,2,2,2,2,2,2,2}
           };
        }
    }
}
