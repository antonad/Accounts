using System;
using Accounts.Dto.Interfaces;

namespace Accounts.Dto
{
    public class PositionDto: IMappedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}