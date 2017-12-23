using System.Collections.Generic;

namespace RepositoryBase
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> Get(PagingInfo pagingInfo);


    }
}
