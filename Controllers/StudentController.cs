﻿using Microsoft.AspNetCore.Mvc;
using Student_Info.Data;
using Student_Info.Models;

namespace Student_Info.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students;
            return View(objStudentList);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Students added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        public IActionResult Edit(int? id)
        {
            
             if(id==null || id==0)
            {
                return NotFound();
            }
            var StudentFromDb = _db.Students.Find(id);
            if(StudentFromDb==null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Students edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var StudentFromDb = _db.Students.Find(id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Students.Find(id);

            if (obj==null)
            {
                return NotFound();
            }
                _db.Students.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Students deleted successfully";
                return RedirectToAction("Index");
            }
            
        }
    }
