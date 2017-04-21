using LeisureTimeSystem.Models.EntityModels.Interfaces;

namespace LeisureTimeSystem.Models.EntityModels.AbstractClasses
{
    public class NameableObject : INameableObject
    {
        public string Name { get; set; }
    }
}
