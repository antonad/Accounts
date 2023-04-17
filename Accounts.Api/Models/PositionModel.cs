using System.ComponentModel.DataAnnotations;

namespace Accounts.Api.Models
{
    public class PositionModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Range(1, 15)]
        public int Grade { get; set; }
    }
}
