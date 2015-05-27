using System;

namespace Algorithm
{
    /// <summary>
    /// 帕斯卡三角形
    /// </summary>
    class Algorithm1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowNum"></param>
        public Algorithm1(int rowNum)
        {
            for (int i = 1; i <= rowNum; i++)
            {
                Console.Write("{0}  ",this.GetCurrencyNum(rowNum,i));
            }
        }

        /// <summary>
        /// 获取当前位置的数
        /// </summary>
        /// <param name="row">行号</param>
        /// <param name="n">第几个数</param>
        /// <returns></returns>
        private int GetCurrencyNum(int row, int n)
        {
            if (n > row)
            {
                return 0;
            }
            if (n == 0 && row == 0)
            {
                return 1;
            }
            return this.GetCurrencyNum(row - 1, n - 1) + this.GetCurrencyNum(row - 1, n);
        }
    }
}
