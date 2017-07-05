using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InHealth_Assignment.Model.Entities
{
    public class BlogPostComments
    {
        [Key]
        public long blogPostCommentId { get; set; }
        public long blogPostId { get; set; }
        [Required] [MaxLength(500)]
        public string commentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("blogPostId")]
        public virtual BlogPost BlogPost { get; set; }
    }
}
