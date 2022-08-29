using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Dtos
{
    public class VisitsDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime VisitDate { get; set; }
    }

    public class VisitsAddUpdateDto
    {
        [Required(ErrorMessage = "Patient is Required!")]
        public Guid PatientId { get; set; }
        [Required(ErrorMessage ="Visit Date is Required!")]
        public DateTime VisitDate { get; set; }
    }

}
