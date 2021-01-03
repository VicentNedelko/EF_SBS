using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SBS.Models
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
