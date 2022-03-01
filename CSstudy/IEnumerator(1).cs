public interface IEnumerator
{
    object Current { get; }
    bool MoveNext();
    void Reset();
}

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

// there is also generic version of IEnumerable / IEnumerator

// function that returns IEnumerable / IEnumerator should not have ref / out parameters
// and also can't be used in lambda expressions

// Simple business object.
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}

// implements IEnumerable so that it can be used with ForEach syntax.
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator(); // upcasting
    }

    public PeopleEnum GetEnumerator() 
    {
        return new PeopleEnum(_people);
    }

    // in one go
    // public IEnumerator GetEnumerator()
    // {
    //     return new PeopleEnum(_people);
    // }
}

// When you implement IEnumerable, you must also implement IEnumerator.
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    // Enumerators are positioned before the first element, until the first MoveNext() call.
    int position = -1; 

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current; // upcasting
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class App
{
    static void Main()
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);

        // IEnumerator enumerator = peopleList.GetEnumerator();
        // while (enumerator.MoveNext())
        //     Console.WriteLine(Current.firstName + " " + Current.lastName);
    }
}