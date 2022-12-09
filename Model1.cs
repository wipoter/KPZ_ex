using System;
using System.Data.Entity;
using System.Linq;
using VeterinaryClinic.Models;

namespace VeterinaryClinic
{
    public class VeterinaryClinic : DbContext
    {
        public VeterinaryClinic()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}