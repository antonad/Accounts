using System;
using Accounts.Dto.Interfaces;

namespace Accounts.Dto
{
    public class EmployeeDto: IMappedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}