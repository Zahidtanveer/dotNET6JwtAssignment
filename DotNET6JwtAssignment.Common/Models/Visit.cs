using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Models
{
    public class Visit : BaseEntity
    {
        public DateTime VisitDate { get; set; }
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
