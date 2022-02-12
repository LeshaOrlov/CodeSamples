namespace MediatorApp.Models
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
