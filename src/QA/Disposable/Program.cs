var s = new S();

using (s)
{
    Console.WriteLine(s.GetDispose());
}
Console.WriteLine(s.GetDispose());

public struct S : IDisposable
{
    private bool dispose;
    public void Dispose()
    {
        dispose = true;
    }
    public bool GetDispose()
    {
        return dispose;
    }
}
