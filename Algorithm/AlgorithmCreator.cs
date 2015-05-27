using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
   public static class AlgorithmCreator
    {

      public static Dictionary<string,Type> GetAllAlgorithmsName()
      {
          Type[] types= Assembly.Load("Algorithm").GetTypes();
          var subtype = types.Where(o => o.IsSubclassOf(typeof (AlgorithmBase)));

          return subtype.ToDictionary(type => type.CustomAttributes.First().ConstructorArguments.First().ToString());
      }

       public static AlgorithmBase GetAlgorithmInstance(Dictionary<string,Type> dic,string typeName )
       {
           return (AlgorithmBase) Activator.CreateInstance(dic[typeName],null);
       }
    }
}
