using ContactAPI.Models;
using ContactAPI.Repository.Interfaces;
using ContactAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ContactUsingRepoController : Controller
{
    private readonly IContactRepo<Contact> contactRepo;
    private readonly IContactService contactService;
    public ContactUsingRepoController(IContactRepo<Contact> contactRepo,IContactService contactService)
    {
        this.contactRepo = contactRepo;
        this.contactService = contactService;
    }

    //Using IContactRepo
    [HttpGet]
    public async Task<IActionResult> GetContactsRepo()
    {
        return Ok(contactRepo.GetAll());
    }

    [Route("usingService")]
    [HttpGet]
    public IActionResult GetContactsSerivceRepo()
    {
        return Ok(contactService.GetAll());
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetContactRepo([FromRoute] Guid id)
    {
        var contact = contactRepo.GetById(id);
        if (contact != null)
        {
            return Ok(contact);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddContactRepo(AddContactRequest addContactRequest)
    {
        var contact = new Contact()
        {
            Id = Guid.NewGuid(),
            Address = addContactRequest.Address,
            Email = addContactRequest.Email,
            FullName = addContactRequest.FullName,
            Phone = addContactRequest.Phone,
        };

        //await dbContext.AddAsync(contact);
        //await dbContext.SaveChangesAsync();
        contactRepo.Insert(contact);
        contactRepo.Save();
        return Ok(contact);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContactRepo([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
    {
        var contact = contactRepo.GetById(id);
        if (contact != null)
        {
            contact.FullName = updateContactRequest.FullName;
            contact.Address = updateContactRequest.Address;
            contact.Email = updateContactRequest.Email;
            contact.Phone = updateContactRequest.Phone;
            contactRepo.Update(contact);
            contactRepo.Save();

            return Ok(contact);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContactRepo([FromRoute] Guid id)
    {
        var contact = contactRepo.GetById(id);
        if (contact != null)
        {
            //dbContext.Contacts.Remove(contact);
            //await dbContext.SaveChangesAsync();
            contactRepo.Delete(contact);
            contactRepo.Save();
            return Ok(contact);
        }
        return NotFound();
    }
}
