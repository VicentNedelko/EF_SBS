using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SBS.Models
{
    public class Visit
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Diagnosis { get; set; }

        // Patient FK
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        // Doctor FK
        public Guid? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        // Prescription
        public Prescription Prescription { get; set; }


    }
}
