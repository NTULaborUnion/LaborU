using System.Linq;
using LaborU.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaborU.Controllers.API;

[Route("api/[controller]")]
[Authorize]
public class ContactsController : Controller
{
    private ApplicationDbContext _dbContext;

    public ContactsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("NonAssigned")]
    public IActionResult GetNonAssignedContacts(string searchText = "")
    {
        return Ok(_dbContext.Contact.Where(w => !w.UserId.HasValue)
            .Where(w => string.IsNullOrEmpty(searchText) || w.Name.Contains(searchText) ||
                        w.Email.Contains(searchText) || w.IDNumber.Contains(searchText) || w.Phone.Contains(searchText))
            .Select(s => new
            {
                s.Id,
                s.Name
            }));
    }
}