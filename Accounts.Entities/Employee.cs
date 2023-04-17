using System;
using System.ComponentModel.DataAnnotations;
using Accounts.Entities.Interfaces;

namespace Accounts.Entities
{
    public class Employee: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }

        public ICollection<EmployeeToPostion> EmployeeToPostions { get; set; }
    }
}
