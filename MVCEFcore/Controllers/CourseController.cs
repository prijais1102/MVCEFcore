using Microsoft.AspNetCore.Mvc;
using MVCEFcore.Context;
using MVCEFcore.Models;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCEFcore.Controllers
{
    public class CourseController : Controller
    {
        CourseDbContext _context;
        public CourseController(CourseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Courses.ToList();
            if (list.Count == 0)
            {
                ViewBag.msg = "No rec";
                return View();
            }
            else
            {
                return View(_context.Courses.ToList());
            }
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Course course)
        {

            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            return View(_context.Courses.Where(c => c.Id == id).FirstOrDefault());
        }

        public IActionResult Edit(int? id)
        {
            return View(_context.Courses.Where(c => c.Id == id).FirstOrDefault());

        }
        [HttpPost]
        public IActionResult Edit(Course course,int id)
        {
            var item = _context.Courses.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (item != null)
            {
               
                    item.Name = course.Name;
                    item.Duration = course.Duration;
                    item.Topic= course.Topic;
                    item.StartDate = course.StartDate;
                    _context.Courses.Update(item);
                    _context.SaveChanges();

                }
            

           




           return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            return View(_context.Courses.Where(c => c.Id == id).FirstOrDefault());

        }
        [HttpPost]
        public IActionResult Delete(Course course)
        {
            if(course != null)
            {
                _context.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}

