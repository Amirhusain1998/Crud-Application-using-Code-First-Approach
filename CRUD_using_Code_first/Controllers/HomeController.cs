using CRUD_using_Code_first.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_using_Code_first.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentContext db=new StudentContext();
        public ActionResult Index()
        {
            var data=db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid==true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //TempData["insert"] = "<script>alert('Data Inserted')</script>";
                    TempData["insert"] = "Data Inserted Successfully";
                   
                    return RedirectToAction("Index");              
                }
                else
                {
                    ViewBag.insert = "<script>alert('Data not Inserted')</script>";
                }
            }
           
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
           if(ModelState.IsValid ==true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["update"] = "Data Updated Successfully";

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.update = "<script>alert('Data not Updated')</script>";
                }
            }


            return View();
        }
        public ActionResult Delete(int id)
        {
            var StudentIdrow = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(StudentIdrow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if(ModelState.IsValid ==true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["delete"] = "Data Deleted Successfully";

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.delete = "<script>alert('Data not Deleted')</script>";
                }
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var DetailsIdrow = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(DetailsIdrow);
        }
    }
}