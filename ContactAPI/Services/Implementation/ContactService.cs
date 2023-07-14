using ContactAPI.Data;
using ContactAPI.Models;
using ContactAPI.Repository.Interfaces;
using ContactAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Services.Implementation;

public class ContactService<T> : IContactService<T> where T:class
{
    private readonly IContactRepo<T> _contactRepo;
    
    public ContactService(IContactRepo<T> contactRepo)
    {
        _contactRepo = contactRepo;
      
    }

    public void Delete(T contact)
    {
        _contactRepo.Delete(contact);
    }

    public List<T> GetAll()
    {
        return _contactRepo.GetAll();
    }

    public T GetById(Guid id)
    {
        return _contactRepo.GetById(id);
    }

    public void Insert(T obj)
    {
        Contact contact = new();
        if(contact == obj)
        {
            contact.FullName = contact.FullName + "InsertService";
        }
        //_dbcontext.Add(contact);
        //_dbcontext.SaveChanges();
        _contactRepo.Insert(obj);
        _contactRepo.Save();
    }

    public void Save()
    {
        _contactRepo.Save();
    }

    public void Update(T obj)
    {
        Contact contact = new();
        if(contact == obj)
        {
            contact.FullName = contact.FullName + "EditService";
        }
        contact.FullName = contact.FullName + "EditService";
        //_dbcontext.Update(contact);
        //_dbcontext.SaveChanges();
        
        _contactRepo.Update(obj);
        _contactRepo.Save();
    }
}
