using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.EntityModels.Interfaces;

namespace LeisureTimeSystem.Models.EntityModels.AbstractClasses
{
    public class NameableObject : INameableObject
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
