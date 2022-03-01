using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Predicate<T> same as Func<T, bool>
            Predicate<int> p = delegate (int n)
            {
                return n >= 0;
            };

            bool res = p(-1);
            System.Console.WriteLine("{0}", res);

            Predicate<string> p2 = s => s.StartsWith("A");
            res = p2("Apple");
            System.Console.WriteLine("{0}", res);
        }
    }
}