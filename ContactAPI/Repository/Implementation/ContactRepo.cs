using ContactAPI.Data;
using ContactAPI.Models;
using ContactAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactAPI.Repository.Implementation;

public class ContactRepo<T> : IContactRepo<T> where T : class
{
    private readonly ContactApiDbContext _dbContext;
    private DbSet<T> table;

    public ContactRepo(ContactApiDbContext dbContext)
    {
        this._dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public void Delete(T obj)
    {
        //_dbContext.Remove(contact);
        table.Remove(obj);
    }

    public List<T> GetAll()
    {
        //return _dbContext.Contacts.ToList();
        return table.ToList();
    }

    public T GetById(Guid id)
    {
        return table.Find(id);
        //return _dbContext.Contacts.Where(x => x.Id== id).FirstOrDefault();
    }

    public void Insert(T obj)
    {
        //_dbContext.Add(contact);
        table.Add(obj);
    }

    public void Save()
    {
        //_dbContext.SaveChanges();
        _dbContext.SaveChanges();
    }

    public void Update(T obj)
    {
        //_dbContext.Update(contact);
        //_dbContext.SaveChanges();
        table.Attach(obj);
        _dbContext.Entry(obj).State = EntityState.Modified;
    }
}
