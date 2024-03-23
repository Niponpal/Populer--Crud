namespace PMS.Services
{
    public interface IRepositoryServices<TEntityi,IModel> where TEntityi : class,new() where IModel : class
    {

        Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IModel> GetByDeltedAsync(int id,CancellationToken cancellationToken);
        Task<IModel> UpdatedAsync(int id, IModel model,CancellationToken cancellationToken);
        Task<IModel> InsertAsync(int id,IModel model,CancellationToken cancellationToken);
    }
}
