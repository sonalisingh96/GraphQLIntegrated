using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Key]
        [RegularExpression("^(?:ISBN(?:-13)?:?)?(?=[0-9]{13}$|(?=(?:[0-9]+[-]){4})[-0-9]{17}$)97[89][-]?[0-9]{1,5}[-]?[0-9]+[-]?[0-9]+[-]?[0-9]$", ErrorMessage = "ISBN number is invalid")]
        public string Isbn { get; set; }
        
    }
}
