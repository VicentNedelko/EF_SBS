using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_SBS.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string BDate { get; set; }
        public string Status { get; set; }

        // Area FK
        public Guid AreaId { get; set; }
        public Area Area { get; set; }

        // Address FK
        public Address Address { get; set; }

        // Visits
        public List<Visit> Visits { get; set; }


        public static int GetPatientAge(Patient patient)
        {
            return (int)(DateTime.Now - DateTime.Parse(patient.BDate)).TotalDays / 365;
        }
        public static string GetPatientStatus(Patient patient)
        {
            if (patient.Age < 2)
            {
                return "newborn";
            }
            else if (patient.Age >= 2 && patient.Age < 6)
            {
                return "young";
            }
            else if (patient.Age >= 6 && patient.Age < 14)
            {
                return "pupil";
            }
            else if (patient.Age >= 14 && patient.Age < 17)
            {
                return "teenage";
            }
            else return "unknown";
        }
    }
}
