using System;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Entities
{
    public class EmployeeToPostion
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
