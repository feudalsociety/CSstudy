class Program
{
    static IEnumerable Number()
    {
        int num = 0;

        while (true)
        {
            num++;
            yield return num;

            if (num >= 100)
            {
                yield break;
            }
        }
    }

    static void Main(string[] args)
    {
        foreach (var tmp in Number())
        {
            Console.Write(tmp + " ");
        }
    }
}

// compiler auto creates IEnumerable/IEnumerator when using yield keyword. starts with the index -1