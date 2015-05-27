using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Algorithm.Algorithm
{
    /// <summary>
    /// 骑士游行
    /// </summary>
    [Description("骑士游行")]
    public class KnightTour : AlgorithmBase
    {
        private int[,] Checkerboard { set; get; }

        private int[] StepX { set; get; }
        private int[] StepY { set; get; }

        private int StartX { set; get; }
        private int StartY { set; get; }

        public Stack<Point> Path { private set; get; }

        public List<Point> Record { private set; get; }

        public override void InitDefaultData()
        {
            this.Path = new Stack<Point>();
            this.Record = new List<Point>();
            this.Checkerboard = new int[9, 9];
            this.StepX = new[] { 1, 1, 2, 2, -1, -1, -2, -2 };
            this.StepY = new[] { 2, -2, 1, -1, 2, -2, 1, -1 };
            this.StartX = 0;
            this.StartY = 0;
        }

        protected override void GetInitDataStr()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Checkerboard.GetLength(0); i++)
            {
                for (int j = 0; j < Checkerboard.GetLength(1); j++)
                {
                    sb.Append(Checkerboard[i, j] + "  ");
                }
                sb.Append('\n');
            }

            this.ResultStr = sb.ToString();
        }

        public override void Caculate()
        {
            Point p = new Point(this.StartX, this.StartY);
            this.TryNext(ref p);
        }

        protected override void GetResultStr()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Checkerboard.GetLength(0); i++)
            {
                for (int j = 0; j < Checkerboard.GetLength(1); j++)
                {
                    sb.Append(Checkerboard[i, j] + "  ");
                }
                sb.Append('\n');
            }

            this.ResultStr = sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void TryNext(ref Point p)
        {
            if (p.X < 0 || p.Y < 0 || p.X > 8 || p.Y > 8 || (Path.Contains(p)))
            {
                p = Path.Peek();
                //Checkerboard[p.X, p.Y] = 0;
                return;
            }

            Path.Push(p);

            Checkerboard[p.X, p.Y] = 1;

            this.ShowResult();

            int i = 0;
            while (true)
            {
                p.X += StepX[i];
                p.Y += StepY[i];

                TryNext(ref p);
                i++;
                if (i == StepX.Length)
                {
                    p = Path.Pop();
                    Checkerboard[p.X, p.Y] = 0;
                    return;
                }
            }


            //if (this.Checkerboard.)
            //{
            //    return;
            //}
        }


        //private void SetRecord(int[] xInts, int[] yiInts)
        //{
        //    int count = xInts.Length;
        //    int[,] result = new int[count, 2];

        //    for (int i = 0; i < count; i++)
        //    {
        //        result[i, 0] = xInts[i];
        //        result[i, 1] = yiInts[i];
        //    }

        //    this.Record.Add(result);
        //}
    }
}

