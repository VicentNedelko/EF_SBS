using EF_SBS.Models;
using System;
using System.Linq;

namespace EF_SBS
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext db = new AppContext();

            // create new instances
            Department department_1 = new Department
            {
                Name = "Common",
                Category = 1,
            };
            Area area1 = new Area
            {
                Name = "area 1",
                RoomNumber = 316,
            };
            Area area2 = new Area
            {
                Name = "area 2",
                RoomNumber = 319,
            };
            Doctor doctor = new Doctor
            {
                Age = 48,
                FName = "Tommy",
                LName = "Breadly",
                Position = "Head",
                Category = 1,
                HiredDate = (new DateTime(2015, 7, 20)).ToString("yyyy-MM-dd"),
                RetiredDate = String.Empty,
                Department = department_1,
                Area = area1,
            };
            Doctor doctor_2 = new Doctor
            {
                Age = 40,
                FName = "Steve",
                LName = "McQueen",
                Position = "Doctor",
                Category = 0,
                HiredDate = (new DateTime(2010, 5, 5)).ToString("yyyy-MM-dd"),
                RetiredDate = String.Empty,
                Department = department_1,
                Area = area2,
            };
            Patient patient1 = new Patient
            {
                FName = "Billy",
                LName = "Johnson",
                BDate = (new DateTime(2010, 02, 03)).ToString("yyyy-MM-dd"),
                Status = null,
                Area = area1,
                Age = 0,
            };
            patient1.Age = Patient.GetPatientAge(patient1);
            patient1.Status = Patient.GetPatientStatus(patient1);
            patient1.Address = new Address
            {
                City = "Minsk",
                Street = "Surganova",
                HouseNo = 88,
                Phone = "+375-29-101-66-66",
            };
            Visit visit1 = new Visit
            {
                Description = "visit description",
                Date = (DateTime.Now).ToString("yyyy-MM-dd"),
                Diagnosis = "diagnosis description",
            };

            // add data to DB
            db.Departments.Add(department_1);
            db.Areas.Add(area1);
            db.Areas.Add(area2);
            db.Doctors.Add(doctor);
            db.Doctors.Add(doctor_2);
            db.Patients.Add(patient1);
            visit1.Patient = patient1;
            visit1.Doctor = doctor_2;
            db.Visits.Add(visit1);
            db.SaveChanges();
            var vis = db.Visits.ToList();
            foreach(Visit v in vis)
            {
                Console.WriteLine($"visit : {v.DoctorId}");
            }
            db.Doctors.Remove(doctor_2);
            db.SaveChanges();
            foreach (Visit v in vis)
            {
                Console.WriteLine($"visit : {v.DoctorId}");
            }
        }
    }
}
