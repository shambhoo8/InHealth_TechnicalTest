using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InHealth_Assignment.Model.Entities
{
    public class UserRole
    {
        [Key]
        public int roleId { get; set; }
        [Required][MaxLength(50)]
        public string RoleName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
