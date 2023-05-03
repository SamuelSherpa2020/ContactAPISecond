using AutoMapper;
using ContactAPI.Data;
using ContactAPI.Models;
using ContactAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    private readonly ContactApiDbContext dbContext;
    private readonly IMapper _mapper;
   
    public ContactsController(ContactApiDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this._mapper = mapper;
       
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        return Ok(await dbContext.Contacts.ToListAsync());
    }

    [HttpGet]
    [Route("api/trying")]
    public IActionResult GetAllContacts()
    {
        return Ok(dbContext.Contacts.Select(x=>_mapper.Map<ContactDto>(x)));
    }
     
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetContact([FromRoute] Guid id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);
        if (contact != null)
        {
            return Ok(contact);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
    {
        var contact = new Contact()
        {
            Id = Guid.NewGuid(),
            Address = addContactRequest.Address,
            Email = addContactRequest.Email,
            FullName = addContactRequest.FullName,
            Phone = addContactRequest.Phone,
        };

        await dbContext.AddAsync(contact);
        await dbContext.SaveChangesAsync();
        return Ok(contact);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
    {
        var contact = dbContext.Contacts.Find(id);
        if (contact != null)
        {
            contact.FullName = updateContactRequest.FullName;
            contact.Address = updateContactRequest.Address;
            contact.Email = updateContactRequest.Email;
            contact.Phone = updateContactRequest.Phone;
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }
        return NotFound();
    }
      
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);
        if (contact != null)
        {
            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        return NotFound();
    }



  
}
