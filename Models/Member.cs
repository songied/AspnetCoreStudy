using System;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreStudy.Models
{
    public class Member
    {   [Key] //PK 설정
        public string UserId { get; set; }

        [Required(ErrorMessage ="비밀번호를 입력하세요")]//NOT NULL 설정
        public string UserPw { get; set; }

        [Required(ErrorMessage ="이메일을 입력하세요")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage ="성별을 선택해주세요")]
        public string UserGender { get; set; }

        [Required(ErrorMessage ="이름을 입력하세요")]
        public string UserNm { get; set; }

        public string UserPhoto { get; set; }

        [Required]
        public DateTime UserReg { get; set; }

    }
}
