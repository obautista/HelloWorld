using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User : ModelId
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
