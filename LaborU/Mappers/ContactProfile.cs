using AutoMapper;
using LaborU.Models.Entity;
using LaborU.Models.ViewModels;

namespace LaborU.Mappers;

public class ContactProfile:Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, PeopleViewModel>();
    }
}