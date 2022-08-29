using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Models
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            this.Doctors = new HashSet<Doctor>();
        }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Visit>? Visits { get; set; }
    }
}
