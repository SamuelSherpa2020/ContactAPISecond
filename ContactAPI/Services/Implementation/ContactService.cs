using ContactAPI.Data;
using ContactAPI.Models;
using ContactAPI.Repository.Interfaces;
using ContactAPI.Services.Interfaces;

namespace ContactAPI.Services.Implementation;

public class ContactService : IContactService
{
    private readonly IContactRepo<Contact> _contactRepo;
    public ContactService(IContactRepo<Contact> contactRepo)
    {
        _contactRepo = contactRepo;
      
    }

    public void Delete(Contact contact)
    {
        _contactRepo.Delete(contact);
    }

    public List<Contact> GetAll()
    {
        return _contactRepo.GetAll();
    }

    public Contact GetById(Guid id)
    {
        return _contactRepo.GetById(id);
    }

    public void Insert(Contact contact)
    {
        contact.FullName = contact.FullName + "AddService";
        //_dbcontext.Add(contact);
        //_dbcontext.SaveChanges();
        _contactRepo.Insert(contact);
        _contactRepo.Save();
    }

    public void Save()
    {
    }

    public void Update(Contact contact)
    {
        contact.FullName = contact.FullName + "EditService";
        //_dbcontext.Update(contact);
        //_dbcontext.SaveChanges();
        _contactRepo.Update(contact);
        _contactRepo.Save();
    }
}
