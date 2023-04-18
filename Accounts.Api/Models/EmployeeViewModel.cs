using System.ComponentModel.DataAnnotations;

namespace Accounts.Api.Models
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// Employee id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Employee name
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Employee surname
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        [Required]
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// List of employee positions
        /// </summary>
        [Required]
        public List<PositionViewModel> Positions { get; set; }
    }
}
