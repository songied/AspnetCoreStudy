using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreStudy.DataContext;
using AspnetCoreStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreStudy.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            using (var db = new AspnetCoreStudyDbContext())
            {
                //var list = db.Posts.ToList();
                var list = db.Posts.Include(u => u.Member).ToList(); //EntityFrameworkCore의 Include를 이용한 테이블 조인
               
                //테이블 Join을 통해 UserId 추출
                /*var list1 = from ps in db.Posts
                             join mb in db.Members on ps.UserNo equals mb.UserNo
                            select new { UserId = mb.UserId };*/
                //, ps.PostContent, ps.PostGroup, ps.PostViews, ps.PostTittle, ps.PostNo, ps.PostReg
                //var list3 = db.Posts.Join(db.Members, ps => ps.PostNo, mb => mb.UserNo, (ps, mb) => new { Post = ps, Member = mb });
                return View(list);
            }
        }

        public IActionResult PostDetail(int postNo) //게시물 상세보기
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            using (var db = new AspnetCoreStudyDbContext())
            {
                //var post = db.Posts.FirstOrDefault(n => n.PostNo.Equals(postNo)); //postNo의 정보를 받는거
                var post = db.Posts.Include(u => u.Member).Where(c => c.PostNo.Equals(postNo)).ToList();
                return View(post);
            }
        }

        public IActionResult PostAdd()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }

        [HttpPost]
        public IActionResult PostAdd(Post model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            if (ModelState.IsValid)
            {
                using (var db = new AspnetCoreStudyDbContext())
                {
                    db.Posts.Add(model);
                    if (db.SaveChanges() > 0)
                    {
                        //return RedirectToAction("Index", "Home"); //다른 Controller의 view로 이동
                        return Redirect("Index"); //동일한 Controller내에서 처리
                    }
                }
                ModelState.AddModelError(string.Empty, "게시물을 저장 할 수 없습니다.");
            }
            return View(model);
        }

        public IActionResult PostEdit(int postNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            using (var db = new AspnetCoreStudyDbContext())
            {
                var post = db.Posts.FirstOrDefault(n => n.PostNo.Equals(postNo)); //postNo의 정보를 받는거
                return View(post);
            }
        }

        [HttpPost]
        public IActionResult PostEdit(Post model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
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
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "변경 사항을 저장 할 수 없습니다.");
            }

            return View(model);
        }

        public IActionResult PostDelete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }
    }
}