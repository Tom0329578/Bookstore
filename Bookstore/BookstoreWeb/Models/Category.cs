using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "{0} mag maximaal {1} tekens bevatten")]
        [Display(Name = "Naam")]
        public string Name { get; set; }
        [Display(Name = "Volgnummer")]
        public int DisplayOrder { get; set; }
        [Display(Name = "Aanmaakdatum")]
        public DateTime CreatedDateTime { get; set; }
    }
}
