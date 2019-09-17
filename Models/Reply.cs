using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreStudy.Models
{
    public class Reply
    {   [Key]
        public int ReplyNum { get; set; }

        [Required]
        public string ReplyContent { get; set; }

        [Required]
        public DateTime ReplyReg { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Member User { get; set; }
    }
}
