using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheUniversity.Models
{
    public class SchoolAdministrator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolAdministratorID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length cannot exceed 100 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
