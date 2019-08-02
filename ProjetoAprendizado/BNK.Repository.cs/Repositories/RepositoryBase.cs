using BNK.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;


namespace BNK.Repository.cs.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public void Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Post(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Put(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
