using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User : ModelId
    {

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
