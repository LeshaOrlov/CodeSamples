public class Program
{
    public static void Main()
    {
        var collection = new MyCollection();

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }
}

public class MyCollection
{
    public List<int> Data = new List<int> { 1, 2, 3, 4, 5 };

    public MyEnumerator GetEnumerator()
    {
        return new MyEnumerator(this);
    }
}

public class MyEnumerator
{
    private MyCollection _myCollection;
    private int _pointer = -1;

    public MyEnumerator(MyCollection collection)
    {
        _myCollection = collection;
    }

    public int Current
    {
        get
        {
            return _myCollection.Data[_pointer];
        }
    }

    public bool MoveNext()
    {
        return ++_pointer < _myCollection.Data.Count;
    }
}