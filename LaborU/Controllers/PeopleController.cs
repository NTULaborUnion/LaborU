using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LaborU.Data;
using LaborU.Models.Entity;
using LaborU.Models.ViewModels;

namespace LaborU.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _dbContext;
        public PeopleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Peoples.Select(s => new PeopleViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                IDNumber = s.IDNumber
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(PeopleViewModel model)
        {
            var identity = Request.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            _dbContext.Peoples.Add(new People()
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

            return View(_dbContext.Peoples.Where(w => w.Id == id).Select(s => new PeopleViewModel()
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
            var people = _dbContext.Peoples.Find(model.Id);
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
