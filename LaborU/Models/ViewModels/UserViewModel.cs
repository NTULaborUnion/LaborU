using System;
using System.Collections.Generic;

namespace LaborU.Models.ViewModels;

public class UserViewModel
{
    public string Email { get; set; }
    public IEnumerable<Guid> ContactIds { get; set; } = new List<Guid>();
}