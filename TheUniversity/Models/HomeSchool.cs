using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheUniversity.Models
{
    public class HomeSchool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomeSchoolID { get; set; }

        public int AdministratorID { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Length cannot be longer than 150 characters.")]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        public SchoolAdministrator Administrator { get; set; }
    }
}
