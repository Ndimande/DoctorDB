using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDBLibrary.Models
{
    public class RecordsModel
    {
        public int recordID { get; set; }
        public int patientID { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string reasonForVisit { get; set; }

    }
}
