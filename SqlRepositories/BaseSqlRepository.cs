using System;
using System.Data.Common;

namespace SqlRepositories
{
    public abstract class BaseSqlRepository
    {
        protected readonly DbConnection _connection;
        public BaseSqlRepository(DbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
    }
}