using System;
using System.ComponentModel.DataAnnotations;
using Accounts.Entities.Interfaces;

namespace Accounts.Entities
{
    public class Position: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

        public ICollection<EmployeeToPostion> EmployeeToPostions { get; set; }
    }
}
