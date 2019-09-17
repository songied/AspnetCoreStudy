using System.ComponentModel.DataAnnotations;

namespace AspnetCoreStudy.ViewModel
{
    public class LoginViewModel
    {   
        [Required(ErrorMessage ="사용자 ID를 입력하세요")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        public string UserPw { get; set; }
    }

}
