using System;
using System.Collections;

public class MyList
{
    private int[] data = { 1, 2, 3, 4, 5 };

    public IEnumerator GetEnumerator()
    {
        int i = 0;
        while (i < data.Length)
        {
            yield return data[i]; // no needs for implement IEumerator
            i++;
        }
    }

    //...
}

class Program
{
    static void Main(string[] args)
    {
        // (1) foreach Iteration
        var list = new MyList();

        foreach (var item in list)
        {
            Console.WriteLine(item); // 1 2 3 4 5 
        }

        // (2) Iteration by hand
        IEnumerator it = list.GetEnumerator();
        it.MoveNext();
        Console.WriteLine(it.Current);  // 1
        it.MoveNext();
        Console.WriteLine(it.Current);  // 2
    }
}

//==========================================================

public static class GalaxyClass
{
    public class Galaxy
    {
        public String Name { get; set; }
        public int MegaLightYears { get; set; }
    }

    public class Galaxies
    {

        public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy // generic IEnumerable
        {
            get
            {
                yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
            }
        }
    }

    public static void ShowGalaxies()
    {
        var theGalaxies = new Galaxies();
        foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
        {
            Debug.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
        }
    }
}

// yield return <something> . something should be inherited from object type 
// yield return can't be used in try/catch
// yield break can be used in try/catch but not in finally