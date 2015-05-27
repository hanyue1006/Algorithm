using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Type> allAlgorithm = AlgorithmCreator.GetAllAlgorithmsName();

            Console.WriteLine("--------------------** AllAlgorithm **--------------------");
            int count = 0;
            foreach (var type in allAlgorithm)
            {
                Console.WriteLine(count + " : " + type.Key);
                count++;
            }
            Console.WriteLine("Please Input Algorithm Number：");

            ConsoleKeyInfo key = Console.ReadKey();
            int index;
            if (!int.TryParse(key.KeyChar.ToString(),out index))
            {
                return;
            }
            string[] names = allAlgorithm.Keys.ToArray();
            AlgorithmBase algorithm = AlgorithmCreator.GetAlgorithmInstance(allAlgorithm, names[index]);
            algorithm.InitDefaultData();
            algorithm.ShowInitDefaultData();
            algorithm.Caculate();
            algorithm.ShowResult();
        }
    }
}
