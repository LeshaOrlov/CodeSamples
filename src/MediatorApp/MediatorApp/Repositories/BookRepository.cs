using MediatorApp.Models;

namespace MediatorApp.Repositories
{
    public class BaseMongoRepository<T, T2> where T : IBaseEntity<T2>
    {
        public BaseRepository()
        {

        } 

        public T GetAll()
        {
            return new T();
        }

        public T GetById(T2 id)
        {
            return new T();
        }

        public create()
    }
}
