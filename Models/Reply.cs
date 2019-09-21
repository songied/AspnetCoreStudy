using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreStudy.Models
{
    public class Reply
    {   [Key]
        public int ReplyNo { get; set; }

        [Required]
        public string ReplyContent { get; set; }

        [Required]
        public DateTime ReplyReg { get; set; }

        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        //public virtual Member User { get; set; }

        public Member Member { get; set; }
    }
}
