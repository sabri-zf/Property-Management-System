namespace Infrastructure.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        // apply repository pattern
        Task<T?> GetByIDAsync(int id);
        Task<bool> AddNewAsync(T entity);
        Task<bool> DeleteAsync(int ID);
        Task<bool> UpdateAsync(T entity);
        Task<List<T>?> GetAllAsync();

    }
}
