using Microsoft.AspNetCore.Mvc;
using StudentRandomizerMvc.Models;
using System;
using System.Collections.Generic;

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
      List<Student> groupStudents = Student.GetGroupStudents(id);
      group.DevTeamStudents = groupStudents;
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

    public IActionResult DisplayGenerated(int groupSize = 5)
    {
      List<Student> allStudents = Student.GetAllStudents();
      foreach (Student student in allStudents)
      {
        student.StudentMatchList = Match.GetAllMatchesForStudent(student.StudentId);
      }
      // int numberOfGroups = (int)Math.Floor((decimal)allStudents.Count / groupSize);
      int numberOfGroups = 5;
      List<Group> allGeneratedGroups = GroupGenerator.GenerateAllPossibleGroups(allStudents, groupSize);
      allGeneratedGroups = GroupScore.SetAllGroupScores(allGeneratedGroups);
      List<Group> optimalGroups = GroupSelection.SelectBestGroups(allGeneratedGroups, numberOfGroups, allStudents);
      return View(optimalGroups);
    }

    [HttpPost, ActionName("DisplayGenerated")]
    public IActionResult AddGeneratedToDatabase(int groupSize = 5)
    {
      List<Student> allStudents = Student.GetAllStudents();
      foreach (Student student in allStudents)
      {
        student.StudentMatchList = Match.GetAllMatchesForStudent(student.StudentId);
      }
      // int numberOfGroups = (int)Math.Floor((decimal)allStudents.Count / groupSize);
      int numberOfGroups = 5;
      List<Group> allGeneratedGroups = GroupGenerator.GenerateAllPossibleGroups(allStudents, groupSize);
      allGeneratedGroups = GroupScore.SetAllGroupScores(allGeneratedGroups);
      List<Group> optimalGroups = GroupSelection.SelectBestGroups(allGeneratedGroups, numberOfGroups, allStudents);
      foreach (Group group in optimalGroups)
      {
        Group newGroup = Group.Post(group);
        for (int i = 0; i < group.DevTeamStudents.Count; i++)
        {
          Student student = group.DevTeamStudents[i];
          Group.AddGroupStudent(newGroup.GroupId, student);
          for (int j = i + 1; j < group.DevTeamStudents.Count; j++)
          {
            Student matchStudent = group.DevTeamStudents[j];
            Match match = Match.FindCommonMatch(student.StudentMatchList, matchStudent.StudentMatchList);
            Match.IncrementMatch(match);
          }
        }
      }
      return RedirectToAction("Index");
    }
  }
}