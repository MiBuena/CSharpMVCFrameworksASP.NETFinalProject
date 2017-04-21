using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels.Interfaces
{
    public interface IContactableObject
    {
        string Website { get; set; }

        string DisplayEmail { get; set; }

        string Telephones { get; set; }

        Address Address { get; set; }
    }
}
