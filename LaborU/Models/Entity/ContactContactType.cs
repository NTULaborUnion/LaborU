using System;

namespace LaborU.Models.Entity;

public class ContactContactType
{
    public Guid ContactId { get; set; }
    public int TypeId { get; set; }
    public virtual Contact Contact { get; set; }
    public virtual ContactType Type { get; set; }
}