Foo obj1 = new Foo();
obj1.Write();

Bar obj2 = new Bar();
obj2.Write();

Foo obj3 = new Bar();
obj3.Write();

Console.ReadLine();

public class Foo
{
    public virtual void Write()
    {
        Console.WriteLine("Class Foo");
    }
}

public class Bar : Foo
{
    public override void Write()
    {
        Console.WriteLine("Class Bar");
    }
}
