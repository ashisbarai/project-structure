using System;

namespace Architecture.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
    }
}