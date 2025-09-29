namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // apply repository pattern
        Task<TEntity?> GetByIDAsync(int id);
        Task AddNewAsync(TEntity entity);
        Task<bool> DeleteAsync(int ID);
        Task<bool> UpdateAsync(TEntity entity);
        Task<IQueryable<TEntity>?> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAsync(ISepecification<TEntity> sepecification);
        Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<TEntity> sepecification);


    }
}
