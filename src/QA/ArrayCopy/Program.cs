internal class CopyTo_CloneExmpl
{
    static void Main(string[] args)
    {
        A[] aArray1 = new A[]
        {
                new A{Name = "1"},
                new A{Name = "2"},
        };

        A[] aArray2 = new A[6];

        aArray1.CopyTo(aArray2, 0);
        aArray2[0].Name = "Changed";

        A[] aArray3 = (A[])aArray1.Clone();

        aArray3[1].Name = "Changed2";

        foreach (A a in aArray1)
        {
            Console.WriteLine(a.Name);
        }
    }
}

public class A
{
    public string Name { get; set; }
}