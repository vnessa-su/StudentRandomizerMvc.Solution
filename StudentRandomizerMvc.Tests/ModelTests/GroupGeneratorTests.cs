using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRandomizerMvc.Models;
using System;
using System.Collections.Generic;

namespace StudentRandomizerMvc.Tests
{
  [TestClass]
  public class GroupGeneratorTests
  {
    [TestMethod]
    public void GenerateAllPossibleGroups_StudentList_GroupList()
    {
      int numberOfStudents = 11;
      int groupSize = 3;
      List<Student> listOfStudents = new List<Student>();
      List<Match> listOfMatches = new List<Match>();

      var rand = new Random();
      for (int num = 1; num < numberOfStudents; num++)
      {
        Match randomMatch = new Match();
        randomMatch.MatchId = num;
        randomMatch.Score = rand.Next(4);
        listOfMatches.Add(randomMatch);
      }
      for (int i = 1; i <= numberOfStudents; i++)
      {
        Student newStudent = new Student("Student" + i.ToString());
        newStudent.StudentMatchList = listOfMatches;
        listOfStudents.Add(newStudent);
      }
      List<Group> allGroups = GroupGenerator.GenerateAllPossibleGroups(listOfStudents, groupSize);
      GroupScore.SetAllGroupScores(allGroups);

      Console.WriteLine("\n**** Generated Groups ****");
      int groupNum = 0;
      foreach (Group group in allGroups)
      {
        groupNum++;
        Console.WriteLine("\nGroup {0} - {1}", groupNum, group.GroupScore);
        foreach (Student student in group.DevTeamStudents)
        {
          Console.WriteLine(student.Name);
        }
      }

      List<Group> bestGroups = GroupSelection.SelectBestGroups(allGroups, (int)Math.Floor((decimal)(numberOfStudents / groupSize)), listOfStudents);
      Console.WriteLine("\n**** Selected Groups ****");
      foreach (Group selectedGroup in bestGroups)
      {
        Console.WriteLine("\nGroup - {0}", selectedGroup.GroupScore);
        foreach (Student student in selectedGroup.DevTeamStudents)
        {
          Console.WriteLine(student.Name);
        }
      }

      Assert.IsNull(allGroups);
    }

    // private static List<List<Match>> GenerateMatches(int numOfStudents)
    // {
    //   List<List<Match>> listOfMatchLists = new List<List<Match>>();
    //   for (int i = 0; i < numOfStudents; i++)
    //   {

    //   }
    // }
  }
}
