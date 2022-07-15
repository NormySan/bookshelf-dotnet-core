using System.Threading.Tasks;

namespace Bookshelf.Domain.Common
{
    public interface IRepository<TEntity>
    {
        public Task<TEntity?> GetByIdAsync(int id);

        public Task<TEntity> Add(TEntity entity);

        public Task<TEntity> Update(TEntity entity);
    }
}
