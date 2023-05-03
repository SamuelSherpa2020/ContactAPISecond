using ContactAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ContactAPI.Repository.Interfaces;

public interface IContactRepo<T> where T : class
{
    public List<T> GetAll();
    public T GetById(Guid id);
    public void Insert(T obj);
    public void Update(T obj);
    public void Delete(T obj);
    public void Save();
}
