using ContactAPI.Models;

namespace ContactAPI.Services.Interfaces;

public interface IContactService<T> where T : class
{
    public List<T> GetAll();
    public T GetById(Guid id);
    public void Insert(T obj);
    public void Update(T obj);
    public void Delete(T obj);
    public void Save();
}
