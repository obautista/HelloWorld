using System.ComponentModel.DataAnnotations;

namespace Model
{
    public abstract class ModelId
    {
        [Required]
        public int Id { get; set; }
    }
}
