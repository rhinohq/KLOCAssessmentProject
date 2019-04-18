using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLOCAssessmentProject.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }

        [MaxLength(50)]
        public string County { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }

        public int Age { get; set; } = 18;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}