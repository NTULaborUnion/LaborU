using AutoMapper;
using LaborU.Models.Entity.Identity;
using LaborU.Models.ViewModels;

namespace LaborU.Mappers;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<LaborUUser, UserViewModel>();
    }
}