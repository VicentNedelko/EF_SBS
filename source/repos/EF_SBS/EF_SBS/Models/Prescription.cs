using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SBS.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public string Cure { get; set; }
        public int Period { get; set; }
        public int QuantPerDay { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }

        // Visit FK
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
