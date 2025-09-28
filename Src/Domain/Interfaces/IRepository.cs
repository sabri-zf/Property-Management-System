namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // apply repository pattern
        Task<TEntity?> GetByIDAsync(int id);
        Task AddNewAsync(TEntity entity);
        Task<bool> DeleteAsync(int ID);
        Task<bool> UpdateAsync(TEntity entity);

    }
}
