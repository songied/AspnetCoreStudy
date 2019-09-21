using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreStudy.Models
{
    public class Post
    {   [Key]
        public int PostNo { get; set; }

        [Required(ErrorMessage ="제목을 입력하세요.")]
        public string PostTittle { get; set; }

        [Required(ErrorMessage = "내용을 입력하세요.")]
        public string PostContent { get; set; }

        public int PostViews { get; set; }

        public int PostGroup { get; set; }

        [Required]
        public DateTime PostReg { get; set; }

        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        //public virtual Member User { get; set; }

        public Member Member { get; set; }
    }
}
