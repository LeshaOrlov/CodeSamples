namespace StackApp
{
    public interface IStack<T>
    {
        T Peek();
        T Pull();
        void Push(T item);
    }
}