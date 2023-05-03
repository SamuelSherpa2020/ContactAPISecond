using ContactAPI.Models;

namespace ContactAPI.Services.Interfaces;

public interface IContactService
{
    public List<Contact> GetAll();
    public Contact GetById(Guid id);
    public void Insert(Contact contact);
    public void Update(Contact contact);
    public void Delete(Contact contact);
    public void Save();
}
