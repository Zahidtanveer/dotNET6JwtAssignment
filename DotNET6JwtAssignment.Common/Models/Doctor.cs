using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Models
{
    public class Doctor : BaseEntity
    {
        public Doctor()
        {
            this.Patients=new List<Patient>();
        }

        public string? Name { get; set; }
        public string? Contact { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }
    }
}
