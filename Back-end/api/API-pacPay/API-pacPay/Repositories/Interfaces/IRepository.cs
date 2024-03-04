using API_pacPay.models;

namespace API_pacPay.Repositories.Interfaces;

public interface IRepository<T> where T : Entity
{

    Task Add(T entity);

    Task<T> GetId(int id);

    Task<IEnumerable<T>> GetAll();
    Task Update(T entity);
    Task Delete(int id);  

}
