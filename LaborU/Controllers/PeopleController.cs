using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborU.Data;
using LaborU.Models.ViewModels;

namespace LaborU.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _dbContext;
        PeopleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Peoples.Select(s=>new PeopleViewModel()
            {

            }));
        }
    }
}
