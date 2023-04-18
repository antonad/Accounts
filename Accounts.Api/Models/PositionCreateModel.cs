using System.ComponentModel.DataAnnotations;

namespace Accounts.Api.Models
{
    public class PositionCreateModel
    {
        /// <summary>
        /// Position name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Position grade
        /// </summary>
        [Required]
        [Range(1, 15)]
        public int Grade { get; set; }
    }
}
