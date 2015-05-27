using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// 算法基类
    /// </summary>
    public abstract class AlgorithmBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string AlgorithmName { get;protected set; }

        /// <summary>
        /// 
        /// </summary>
        protected string InitDataStr { set; get; }

        /// <summary>
        /// 
        /// </summary>
        protected string ResultStr { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void InitDefaultData();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void GetInitDataStr();

        /// <summary>
        /// 
        /// </summary>
        public abstract void Caculate();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void GetResultStr();

        /// <summary>
        /// 
        /// </summary>
        public void ShowInitDefaultData()
        {
            this.GetInitDataStr();
            Console.WriteLine('\n' + "--------------------**  AlgorithmName : " + AlgorithmName + "  **--------------------");
            Console.WriteLine();
            Console.WriteLine("--------------------**  InitData  **--------------------");
            Console.WriteLine('\n' + InitDataStr + '\n');
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowResult()
        {
            this.GetResultStr();
            Console.WriteLine();
            Console.WriteLine("--------------------**  Result    **--------------------");
            Console.WriteLine('\n' + ResultStr + '\n');
            Console.WriteLine("--------------------**    End      **--------------------");
            Console.ReadKey();
        }
    }
}
