namespace MediatorApp.Models
{
    public class Book<T>: IBaseEntity<T>
    {
        public T Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        
    }
}
