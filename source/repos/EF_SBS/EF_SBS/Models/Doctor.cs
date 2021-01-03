using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_SBS.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Category { get; set; }
        public string HiredDate { get; set; }
        public string RetiredDate { get; set; }

        // Department FK
        [ForeignKey("DepartmentId")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        // Area FK
        public Guid? AreaId { get; set; }
        public Area Area { get; set; }

        // Visit
        public List<Visit> Visits { get; set; }
    }
}
