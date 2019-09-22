using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;
using AspnetCoreStudy.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreStudy.Controllers
{
    public class UserController : Controller
    {

        public IActionResult UserActivity(int userNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 일 경우 로그인페이지로
                return RedirectToAction("UserLogin", "User");
            }
            using (var db = new AspnetCoreStudyDbContext())
            {
                //var user = db.Members.FirstOrDefault(n => n.UserNo.Equals(userNo)); //userNo의 정보를 받는거
                var user = db.Posts.Include(u => u.Member).Where(c => c.UserNo.Equals(HttpContext.Session.GetInt32("USER_LOGIN_KEY"))).ToList();

                //사용자의 게시물이 하나도 없을경우 사용자의 기본 정보만 보내준다
                if (user.Count == 0)
                {
                    var user1 = db.Members.FirstOrDefault(n => n.UserNo.Equals(userNo));
                    return View(user1);
                }
                return View(user);
            }
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

        public IActionResult UserModify(int userNo) //update로 db 에 save
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 일 경우 로그인페이지로
                return RedirectToAction("UserLogin", "User");
            }
            using (var db = new AspnetCoreStudyDbContext())
            {
                var user = db.Members.FirstOrDefault(n => n.UserNo.Equals(userNo)); //userNo의 정보를 받는거
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult UserModify(Member model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 일 경우 로그인페이지로
                return RedirectToAction("UserLogin", "User");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            if (ModelState.IsValid)
            {

                using (var db = new AspnetCoreStudyDbContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "변경 사항을 저장 할 수 없습니다.");
            }
            return View(model);
        }
    }
}