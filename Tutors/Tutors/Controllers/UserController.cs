﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tutors.Data;




namespace Tutors.Controllers
{
    [Authorize]
    public class UserController : ApplicationController
    {
        [AllowAnonymous]
        // GET: Tutor
        public ActionResult Index()
        {
            return View("Index", _tutorService.GetUsers());
        }

        // GET: Tutor/Details/5
        public ActionResult Details(int id)
        {
            return View(_tutorService.GetUser(id));
        }

        // GET: Tutor/Create/add 

        public ActionResult Create()
        {

            return View();
        }

        // POST: Tutor/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                _tutorService.AddUser(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View();
        }

        // GET: Tutor/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_tutorService.GetUser((id)));
        }

        // POST: Tutor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _tutorService.EditUser(user);

                return RedirectToAction("Index", new { id = user.UserID, controller = "User" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // GET: Tutor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_tutorService.GetUser(id));
        }

        // POST: Tutor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User u)
        {
            try
            {
                u = _tutorService.GetUser(id);
                _tutorService.DeleteUser(u);
                return RedirectToAction("Index",
                 new { controller = "User", id = u.UserID });
            }

            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              throw;
                
            }


        }


    }
}



        
