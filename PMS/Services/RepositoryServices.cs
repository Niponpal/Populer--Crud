
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS.DataBase;

namespace PMS.Services;

public class RepositoryServices<TEntity, IModel> : IRepositoryServices<TEntity, IModel> where TEntity : class, new() where IModel : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public RepositoryServices(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _dbSet=context.Set<TEntity>();
    }

    private  DbSet<TEntity> _dbSet { get; }

    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entity=await _dbSet.ToListAsync(cancellationToken);
        if (entity == null) return null;
        var getAllasync=_mapper.Map<IEnumerable<IModel>>(entity);
        return  getAllasync;
    }

    public async Task<IModel> GetByDeltedAsync(int id, CancellationToken cancellationToken)
    {
        var entity=await _dbSet.FindAsync(id, cancellationToken);
        if (entity == null) return null;
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        var delatedAsync=_mapper.Map<TEntity,IModel>(entity);
        return delatedAsync;
    }

    public async Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        var getByidAsync = _mapper.Map<TEntity,IModel>(entity);
        return getByidAsync;
    }

    public async Task<IModel> InsertAsync(int id, IModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<IModel,TEntity>(model);
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        var inserAsync=_mapper.Map<TEntity,IModel>(entity);
        return inserAsync;
    }

    public async Task<IModel> UpdatedAsync(int id, IModel model, CancellationToken cancellationToken)
    {
            var entity= await _dbSet.FindAsync(id);
            if(entity == null) return null;
           _mapper.Map(model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        var updateAsync = _mapper.Map<TEntity, IModel>(entity);
        return updateAsync;
    }
}
