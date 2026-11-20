using Newtonsoft.Json;
using PROJECT_GROUP_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT_GROUP_A.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public JsonResult TestUser()
        {
            //The database
            UserEntities db = new UserEntities();

            //Making a test user and added them
            USER testUser = new USER()
            {
                username = "Jack",
                email = "JackGMess1@Outlook.com"
            };
            db.USERS.Add(testUser);
            db.SaveChanges();

            //Saving all the users ids and usernames in a json format
            var users = db.USERS.Select(a => new
            {
                User_id = a.user_id,
                Username = a.username
            }).ToList();

            //Sending the json data to the screen
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}