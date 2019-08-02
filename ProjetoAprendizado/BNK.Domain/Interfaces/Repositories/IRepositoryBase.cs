using System.Collections.Generic;

namespace BNK.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Post(TEntity obj);
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        void Put(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();

    }
}
