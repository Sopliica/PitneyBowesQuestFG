using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using PitneyBowesQuestFG.DB;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace PitneyBowesQuestFG.Repository_Service;

public class Repository<TModel> : IRepository<TModel> where TModel : class, IEntity<int>  
{
    protected readonly InMemoryDBContext _context;
    protected readonly DbSet<TModel> _set;
    public Repository(InMemoryDBContext context)
    {
        _context = context;
        _set = context.Set<TModel>();
    }

    public virtual async Task<TModel> Create(TModel model)
    {
        await _set.AddAsync(model);
        await Save();
        return model;
    }

    public virtual async Task Delete(TModel model)
    {
////////////////////hm
        _set.Remove(model);
        await Save();
    }

    public virtual async Task<IQueryable<TModel>> FindBy(Expression<Func<TModel, bool>> predicate)
    {
        IQueryable<TModel> result = _set.Where(predicate);
        return result;
    }

    public virtual async Task<IQueryable<TModel>> GetAll()
    {
        return _set;
    }
    public virtual async Task<TModel> GetSingle(int id)
    {
        return await _set.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<TModel> Update(TModel model)
    {
        try
        {
           _context.Entry(model).State = EntityState.Modified;
           await Save();
        }
        catch (Exception)
        {
///////////////////////hm
            throw;
        }
        return model;
    }
    public virtual async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
