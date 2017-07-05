using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InHealth_Assignment.Model.Entities
{
    public class BlogPost
    {
        [Key]
        public long Id { get; set; }
        [Required] [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public string PostContent { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual UserRegistration UserRegistration { get; set; }
    }
}
