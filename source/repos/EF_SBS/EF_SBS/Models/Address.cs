using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SBS.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
        public string Phone { get; set; }

        // Patient FK
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
