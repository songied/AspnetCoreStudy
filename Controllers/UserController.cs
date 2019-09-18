using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;
using AspnetCoreStudy.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreStudy.Controllers
{
    public class UserController : Controller
    {

        public IActionResult UserActivity()
        {
            return View();
        }

        public IActionResult UserJoin()
        {
            return View();
        }

        [HttpPost]//회원가입 전송
        public IActionResult UserJoin(Member model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspnetCoreStudyDbContext())
                {
                    _ = db.Members.Add(model);
                    _ = db.SaveChanges();//commit
                }
                return RedirectToAction("Index","Home");//HomeController 의 Index Action을 실행 -> 페이지 이동
            }
            return View(model);
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]//로그인 전송
        public IActionResult UserLogin(LoginViewModel model)
        {
            //Id,Pw 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetCoreStudyDbContext())
                {
                    //Linq - 메서드 체이닝
                    // => : A to go B
                    var user = db.Members.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPw.Equals(model.UserPw));
                    if (user != null)
                    {
                        //로그인 성공했을때
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        return RedirectToAction("LoginSuccess", "Home"); // 로그인 성공 페이지로 이동
                    }
                }
                //로그인 실패했을때
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult UserLogout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserLeave()
        {
            return View();
        }

        public IActionResult UserModify()
        {
            return View();
        }
    }
}