namespace Common.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T t);

        void Update(T t);

        void Delete(int id);
    }
}
