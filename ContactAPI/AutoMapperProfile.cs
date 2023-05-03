using AutoMapper;
using ContactAPI.Models;

namespace ContactAPI;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Contact, ContactDto>();
    }
}
