﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreStudy.Models;
using AspnetCoreStudy.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace AspnetCoreStudy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new AspnetCoreStudyDbContext())
            {
                string ConnectString = @"Server=localhost;Database=AspnetCoreStudyDb;User Id=sa;Password = 1234; "; //연결할 DB문
                DataTable dt = new DataTable(); // Select문 일경우
                SqlConnection conn = new SqlConnection(ConnectString); //연결문을 통해 DB 연결
                SqlCommand cmd = new SqlCommand(); //SQL커맨드 선언
                conn.Open(); //DB를 여는 코드
                cmd.CommandType = CommandType.StoredProcedure; //SQLCommand에서 사용할 커멘드 타입 형식 지정
                cmd.CommandText = "POST_LIST"; //불러올 프로시저명 지정
                cmd.Parameters.Add("@PostGroup", SqlDbType.Int);        //프로시저에서 선언한 변수명과 데이터형 지정
                cmd.Parameters["@PostGroup"].Value = 0;                 // 프로시저 변수에 입력할 값 혹은 변수 지정
                cmd.Connection = conn; //SQL커맨드가 앞에서 선언한 DB로 연결
                SqlDataAdapter da = new SqlDataAdapter(); // Select문 일경우에는 이렇게 연결
                da.SelectCommand = cmd;
                da.Fill(dt);
                //DataTable형식을 Ienumerable로 변환
                var posts = new List<Post>();
                foreach (DataRow dr in dt.Rows)
                {
                    var post = new Post
                    {
                        PostNo = Convert.ToInt32(dr["PostNo"]),
                        PostContent = Convert.ToString(dr["PostContent"]),
                        PostGroup = Convert.ToInt32(dr["PostGroup"]),
                        PostReg = Convert.ToDateTime(dr["PostReg"]),
                        PostTittle = Convert.ToString(dr["PostTittle"]),
                        PostViews = Convert.ToInt32(dr["PostViews"])
                    };

                    posts.Add(post);
                    var list = db.Posts.ToList();
                    //var list = db.Posts.Include(u => u.Member).ToList(); //EntityFrameworkCore의 Include를 이용한 테이블 조인

                }
                    return View(posts.AsEnumerable());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
