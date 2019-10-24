using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDBLibrary.Models
{
    public class PatientModel
    {
        public int patientID { get; set; }
        public string firstName{ get; set; }
        public string lastName { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public string contactNumber { get; set; }
        public string PostalAddress { get; set; }
        public int medicalAidNumber { get; set; }
    }
}
