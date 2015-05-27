using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// 三色旗
    /// </summary>
    [Description("三色旗")]
    public class ThreeColorFlags : AlgorithmBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] Data { get; set; }

        public ThreeColorFlags()
        {
            base.AlgorithmName = "三色旗";
        }

        /// <summary>
        /// 
        /// </summary>
        public override void InitDefaultData()
        {
            this.Data = new string[] { "r", "w", "b", "w", "w", "b", "r", "b", "w", "r", "r" };
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GetInitDataStr()
        {
            this.InitDataStr = string.Join(",", this.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Caculate()
        {
            int length = this.Data.Length;
            int rflag = length - 1;
            int bflag = 0;
            for (int i = 0; i < length; i++)
            {
                if (this.Data[i] == "r")
                {
                    while (this.Data[rflag] == "r")
                    {
                        rflag--;
                    }
                    if (i <= rflag)
                    {
                        this.Swap(ref  this.Data[i], ref  this.Data[rflag]);
                    }
                }
                if (this.Data[i] == "b")
                {
                    while (this.Data[bflag] == "b")
                    {
                        bflag++;
                    }
                    this.Swap(ref  this.Data[i], ref  this.Data[bflag]);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void GetResultStr()
        {
            this.ResultStr = string.Join(",", this.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }
    }
}
