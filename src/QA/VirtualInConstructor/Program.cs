public class Program
{
    public static void Main()
    {
        var bt = new BaseType("1");
        var dt = new DerivedType("2");
    }
}

class BaseType
{
    private string _name;
    public BaseType(string name)
    {
        _name = name;
        Console.WriteLine("ctor base");
        PrintName();
    }

    public virtual void PrintName()
    {
        Console.WriteLine("name base [" + _name + "]");
    }

}

class DerivedType : BaseType
{
    private string _name;
    public DerivedType(string name) : base(name)
    {
        _name = name;
        Console.WriteLine("ctor derived");
        PrintName();
    }

    public override void PrintName()
    {
        Console.WriteLine("name derived [" + _name + "]");
    }
}