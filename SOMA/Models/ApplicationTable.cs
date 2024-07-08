using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOMA.Models
{
    public class ApplicationTable
    {
        public int Id { get; set; }

        // Foreign key for UsersTable
        [Required]
        public int UserId { get; set; }
        
        // Navigation property
        public UsersTable ? User { get; set; }  

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

       

        [Required]
        [Display(Name = "Application Level")]
        public string? ApplicantionLevel { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string? CourseName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "P.O. Box cannot be longer than 100 characters.")]
        [Display(Name = "P.O. Box")]
        public string? POBOX { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Applicant Region cannot be longer than 100 characters.")]
        [Display(Name = "Applicant Region")]
        public string? ApplicantRegion { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Religion cannot be longer than 50 characters.")]
        public string? Religion { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string? MaritalStatus { get; set; }
    }
}
