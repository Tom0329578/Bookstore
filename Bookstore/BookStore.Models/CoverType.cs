using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [MaxLength(50, ErrorMessage = "{0} mag maximaal {1} tekens bevatten")]
        [Display(Name = "Naam")]
        public string Name { get; set; }
        [Display(Name = "Aanmaakdatum")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
