using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Dtos
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
    }
    public class DoctorAddUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Contact is required")]
        public string? Contact { get; set; }
    }
}
