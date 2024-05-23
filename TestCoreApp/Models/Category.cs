using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
   
        public string? Description { get; set; }
        public ICollection<Food>? Foods { get; set; }



    }
}
