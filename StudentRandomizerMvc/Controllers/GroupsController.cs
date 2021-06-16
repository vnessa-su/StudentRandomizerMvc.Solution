using Microsoft.AspNetCore.Mvc;
using StudentRandomizerMvc.Models;

namespace StudentRandomizerMvc.Controllers
{
  public class GroupsController : Controller
  {
    public IActionResult Index(int studentId)
    {
      if (studentId != 0)
      {
        var allStudenGroups = Group.GetAllDatabaseGroupsForStudent(studentId);
        return View(allStudenGroups);
      }
      var allGroups = Group.GetAllDatabaseGroups();
      return View(allGroups);
    }

    [HttpPost]
    public IActionResult Index(Group group)
    {
      Group.Post(group);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      Group group = Group.GetDetails(id);
      return View(group);
    }

    public IActionResult Edit(int id)
    {
      Group group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost]
    public IActionResult Details(int id, Group group)
    {
      group.GroupId = id;
      Group.Put(group);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Group.Delete(id);
      return RedirectToAction("Index");
    }
  }
}