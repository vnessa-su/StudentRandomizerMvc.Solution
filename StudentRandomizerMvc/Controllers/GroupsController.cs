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
      int numberOfGroups = (int)Math.Floor((decimal)allStudents.Count / groupSize);
      List<Group> allGeneratedGroups = GroupGenerator.GenerateAllPossibleGroups(allStudents, groupSize);
      allGeneratedGroups = GroupScore.SetAllGroupScores(allGeneratedGroups);
      List<Group> optimalGroups = GroupSelection.SelectBestGroups(allGeneratedGroups, numberOfGroups, allStudents);
      return View(optimalGroups);
    }

    [HttpPost, ActionName("DisplayGenerated")]
    public IActionResult AddGeneratedToDatabase(int[] groupSizes, int[] groupScores, int[] studentIds)
    {
      int currentIndex = 0;
      for (int groupIndex = 0; groupIndex < groupSizes.Length; groupIndex++)
      {
        Group newGroup = new Group { GroupScore = groupScores[groupIndex] };
        newGroup = Group.Post(newGroup);

        List<Student> studentsInGroup = new List<Student>();
        int groupLimit = currentIndex + groupSizes[groupIndex];
        for (int i = currentIndex; i < groupLimit; i++)
        {
          Student student = Student.GetDetails(studentIds[currentIndex]);
          student.StudentMatchList = Match.GetAllMatchesForStudent(student.StudentId);
          Group.AddGroupStudent(newGroup.GroupId, student);
          studentsInGroup.Add(student);
          currentIndex++;
        }

        for (int i = 0; i < studentsInGroup.Count; i++)
        {
          Student student = studentsInGroup[i];
          for (int j = i + 1; j < studentsInGroup.Count; j++)
          {
            Student matchStudent = studentsInGroup[j];
            Match match = Match.FindCommonMatch(student.StudentMatchList, matchStudent.StudentMatchList);
            Match.IncrementMatch(match);
          }
        }
      }
      return RedirectToAction("Index");
    }
  }
}