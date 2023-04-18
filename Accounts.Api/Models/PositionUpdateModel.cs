using System.ComponentModel.DataAnnotations;

namespace Accounts.Api.Models
{
    public class PositionUpdateModel
    {
        /// <summary>
        /// Position id
        /// </summary>
        [Required]
        public int Id { get; set; }

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
