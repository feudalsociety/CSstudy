using System;
using System.Collections;
namespace ConsoleEnum
{
    public class cars : IEnumerator, IEnumerable  
    {
        private car[] carlist;
        int position = -1;

        //Create internal array in constructor.
        public cars()
        {
            carlist = new car[6]
            {
               new car("Ford",1992),
               new car("Fiat",1988),
               new car("Buick",1932),
               new car("Ford",1932),
               new car("Dodge",1999),
               new car("Honda",1977)
            };
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;  
        }

        public bool MoveNext()
        {
            position++;
            return (position < carlist.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return carlist[position]; }
        }
    }
}