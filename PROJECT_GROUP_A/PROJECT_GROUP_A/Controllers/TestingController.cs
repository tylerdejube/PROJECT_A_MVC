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
        public JsonResult TestGetUser()
        {
            //The database
            UserEntities db = new UserEntities();

            //Saving all the users ids and usernames in a json format
            var users = db.USERS.Select(a => new
            {
                User_id = a.user_id,
                Username = a.username,
                Email = a.email
            }).ToList();

            //Sending the json data to the screen
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestCreateUser()
        {
            //The database
            UserEntities db = new UserEntities();

            //Making a test user and adding them to the db
            USER testUser = new USER()
            {
                username = "Jack",
                email = "JackGMess1@Outlook.com"
            };
            db.USERS.Add(testUser);
            db.SaveChanges();

            //Sending the json data to the screen
            return RedirectToAction("TestGetUser");
        }

        public ActionResult TestUpdateUser()
        {
            //The database
            UserEntities db = new UserEntities();

            //Getting the testUser and modifing it
            USER u = db.USERS.Single(i => i.username == "Jack");
            u.email = "ModifiedEmail";
            db.SaveChanges();

            //Sending the json data to the screen
            return RedirectToAction("TestGetUser");
        }

        public ActionResult TestDeleteUser()
        {
            //The database
            UserEntities db = new UserEntities();

            //Getting the testUser and deleting it
            USER u = db.USERS.Single(i => i.username == "Jack");
            db.USERS.Remove(u);
            db.SaveChanges();

            //Sending the json data to the screen
            return RedirectToAction("TestGetUser");
        }
    }
}