using LeisureTimeSystem.Models.EntityModels.Interfaces;

namespace LeisureTimeSystem.Models.EntityModels.AbstractClasses
{
    public class ContactableObject : NameableObject, IContactableObject
    {
        public string Website { get; set; }
        public string Emails { get; set; }
        public string Telephones { get; set; }
        public Address Address { get; set; }
    }
}
