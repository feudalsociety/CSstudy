using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSstudy
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple= true)] 
    class History : System.Attribute
    {
        private string programmer;
        public double Version { get; set; }
        public string Changes { get; set; }

        public History(string programmer)
        {
            this.programmer = programmer;
            Version = 1.0;
            Changes = "First Release";
        }

        public string Programmer { get { return programmer; } }
    }

    [History("Sean", Version = 0.1, Changes = "2020-11-01")]
    [History("Bob", Version= 0.2, Changes = "2020-12-03")]
    class Myclass
    {
        public void Func()
        {
            Console.WriteLine("Func");
        }
    }
}
