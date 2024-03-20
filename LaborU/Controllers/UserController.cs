using AutoMapper;
using AutoMapper.QueryableExtensions;
using LaborU.Data;
using LaborU.Models.Entity.Identity;
using LaborU.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaborU.Controllers;

public class UserController : Controller
{ 
    private ApplicationDbContext _dbContext;
    private IMapper _mapper;
    public UserController(ApplicationDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public IActionResult Index()
    {
        return View(_dbContext.Set<LaborUUser>().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider));
    }
}