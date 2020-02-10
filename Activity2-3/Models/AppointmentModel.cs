using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Activity2_3.Models
{
    public class AppointmentModel
    {
        [Required]
        [DisplayName("Patient's Full Name")]
        [StringLength(20, MinimumLength = 4)]
        public string patientName { get; set; }

        [Required]
        [DisplayName("Appointment Request Date")]
        [DataType(DataType.Date)]
        public DateTime dateTime { get; set; }

        [Required]
        [DisplayName("Patient's Approximate Net Worth")]
        [DataType(DataType.Currency)]
        public decimal patientNetWorth { get; set; }

        [Required]
        [DisplayName("Primary Doctor's Last Name")]
        public string doctorName { get; set; }

        [Required]
        [Range(1,10)]
        [DisplayName("Patient's perceived level of pain (1 low to 10 high)")]
        public int painLevel { get; set; }

        public AppointmentModel(string patientName, DateTime dateTime, decimal patientNetWorth, string doctorName, int painLevel)
        {
            this.patientName = patientName;
            this.dateTime = dateTime;
            this.patientNetWorth = patientNetWorth;
            this.doctorName = doctorName;
            this.painLevel = painLevel;
        }

        public AppointmentModel() { }
    }
}