using System.Linq;

namespace H571H2_HFT_2021222.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);        
        void Delete(int id);

    }
}