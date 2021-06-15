using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentRandomizerMvc.Models
{
  public class GroupScore
  {
    public int MatchFrequency(int StudentId, int MatchStudentId)
    {
      Stack<int> TempScore = new Stack<int>();
      for (int i = 0; i < Student.Match.Count; i++)
      {
        if (StudentId == MatchStudentId)
        {
          TempScore.Push(Match);
        }
      }
      return TempScore;
    }

    public static void SetAllGroupScores(List<Group> allGeneratedGroups)
    {
      for (int i = 0; i < allGeneratedGroups.Count; i++)
      {
        int currentGroupScore = 0;
        List<Student> groupStudents = allGeneratedGroups[i].DevTeamStudents;
        for (int j = 0; j < groupStudents.Count; j++)
        {
          for (int k = j + 1; k < groupStudents.Count; k++)
          {
            Match commonMatch = Match.FindCommonMatch(groupStudents[j].StudentMatchList, groupStudents[k].StudentMatchList);
            currentGroupScore += commonMatch.Score;
          }
        }
        allGeneratedGroups[i].GroupScore = currentGroupScore;
      }
    }
  }
}


// we'll have 39 Id pairs for each student
// the 39 Id's will have amount of times they were paired
// 
