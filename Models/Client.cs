using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.Models
{
    public class Client
    {
        [Key]
        public int Client_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TypeOfAnimal { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Diagnosis { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
