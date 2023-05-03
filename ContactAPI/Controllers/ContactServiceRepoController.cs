using ContactAPI.Models;
using ContactAPI.Repository.Implementation;
using ContactAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactServiceRepoController : Controller
{
    private readonly IContactService _contactService;
    public ContactServiceRepoController(IContactService contactService)
    {
        _contactService = contactService;
    }
    //Using IContactRepo
    [HttpGet]
    public async Task<IActionResult> GetContactsRepo()
    {
        return Ok(_contactService.GetAll());
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetContactRepo([FromRoute] Guid id)
    {
        var contact = _contactService.GetById(id);
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
        _contactService.Insert(contact);
        _contactService.Save();
        return Ok(contact);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContactRepo([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
    {
        var contact = _contactService.GetById(id);
        if (contact != null)
        {
            contact.FullName = updateContactRequest.FullName;
            contact.Address = updateContactRequest.Address;
            contact.Email = updateContactRequest.Email;
            contact.Phone = updateContactRequest.Phone;
            _contactService.Update(contact);

            return Ok(contact);
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContactRepo([FromRoute] Guid id)
    {
        var contact = _contactService.GetById(id);
        if (contact != null)
        {
            //dbContext.Contacts.Remove(contact);
            //await dbContext.SaveChangesAsync();
            _contactService.Delete(contact);
            _contactService.Save();
            return Ok(contact);
        }
        return NotFound();
    }
}
