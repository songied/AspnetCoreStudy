using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreStudy.Models
{
    public class Post
    {   [Key]
        public int PostNum { get; set; }

        [Required]
        public string PostTittle { get; set; }

        [Required]
        public string PostContent { get; set; }

        public int PostViews { get; set; }

        public int PostGroup { get; set; }

        [Required]
        public DateTime PostReg { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Member User { get; set; }
    }
}
