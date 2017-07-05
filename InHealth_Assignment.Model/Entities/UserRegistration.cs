using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InHealth_Assignment.Model.Entities
{
    public class UserRegistration
    {
        [Key]
        public long Id { get; set; }
        [Required][MaxLength(50)]
        public string fName { get; set; }
        [Required][MaxLength(50)]
        public string lName { get; set; }
        [Required][MaxLength(30)]
        public string emailId { get; set; }
        [Required] [MaxLength(100)]
        public string password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int roleId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("roleId")]
        public virtual UserRole UserRole { get; set; }
    }
}
