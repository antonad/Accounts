using System.ComponentModel.DataAnnotations;

namespace Accounts.Api.Models
{
    public class EmployeeModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [Required]
        public List<PositionModel> Positions { get; set; }
    }
}
