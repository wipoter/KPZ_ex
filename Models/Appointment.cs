using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.Models
{
    public class Appointment
    {
        [Key]
        public int Appointment_Id { get; set; }
        public Nullable<DateTime> DateOfAppointment { get; set; }

        public Client Client { get; set; }

    }
}
