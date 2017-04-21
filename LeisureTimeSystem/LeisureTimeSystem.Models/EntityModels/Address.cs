using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Village { get; set; }

        public string District { get; set; }

        public string BlockNumber { get; set; }

        public string Entrance { get; set; }

        public string AppartmentNumber { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

    }
}
