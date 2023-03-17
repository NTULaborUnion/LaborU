using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LaborU.Data;
using LaborU.Models.Entity;
using LaborU.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LaborU.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        public PeopleController(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Set<Contact>().ProjectTo<PeopleViewModel>(_mapper.ConfigurationProvider));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(PeopleViewModel model)
        {
            var identity = Request.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            _dbContext.Set<Contact>().Add(new Contact()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                CreatedUserId = Guid.Parse(identity)
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {

            return View(_dbContext.Set<Contact>().Where(w => w.Id == id).Select(s => new PeopleViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                IDNumber = s.IDNumber
            }).FirstOrDefault());
        }
        public IActionResult Update(PeopleViewModel model)
        {
            var people = _dbContext.Set<Contact>().Find(model.Id);
            people.Address = model.Address;
            people.Name = model.Name;
            people.Email = model.Email;
            people.IDNumber = model.IDNumber;
            _dbContext.Update(people);
            _dbContext.SaveChanges();
            return RedirectToAction("Edit", new { model.Id });
        }
    }
}
