using API_pacPay.Domain.models;
using API_pacPay.infraestrutura;
using API_pacPay.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_pacPay.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : Entity
{

    protected readonly BankContext _bankContext;

    public BaseRepository(BankContext bankContext)
    {
        _bankContext = bankContext;
    }

    public async Task Add(T entity)
    {
         await _bankContext.Set<T>().AddAsync(entity);
        await _bankContext.SaveChangesAsync();

    }
    public async Task<T> GetId(int id)
    {
        return await _bankContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _bankContext.Set<T>().ToListAsync();
    }


    public async Task Delete(int id)
    {
        var entity = await GetId(id);
        _bankContext.Set<T>().Remove(entity);
        await _bankContext.SaveChangesAsync();
    }

  
  
    public  Task Update(T entity)
    {
        throw  new NotImplementedException();
    }

   
}
