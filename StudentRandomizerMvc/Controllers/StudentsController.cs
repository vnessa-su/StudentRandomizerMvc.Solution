using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentRandomizerMvc.Models;

namespace StudentRandomizerMvc.Controllers
{
  public class StudentsController : Controller
  {
    public IActionResult Index()
    {
      var allStudents = Student.GetAllStudents();
      return View(allStudents);
    }

    [HttpPost]
    public IActionResult Index(Student student)
    {
      Student.Post(student);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var student = Student.GetDetails(id);
      return View(student);
    }

    public IActionResult Edit(int id)
    {
      var student = Student.GetDetails(id);
      return View(student);
    }

    [HttpPost]
    public IActionResult Details(int id, Student student)
    {
      student.StudentId = id;
      Student.Put(student);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Student.Delete(id);
      return RedirectToAction("Index");
    }
  }
}