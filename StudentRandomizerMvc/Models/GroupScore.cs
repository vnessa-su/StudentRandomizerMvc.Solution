using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentRandomizerMvc.Models
{
  public class GroupScore
  {
    public static int GetGroupScore(Group group)
    {
      int currentGroupScore = 0;
      List<Student> groupStudents = group.DevTeamStudents;
      for (int j = 0; j < groupStudents.Count; j++)
      {
        for (int k = j + 1; k < groupStudents.Count; k++)
        {
          Match commonMatch = Match.FindCommonMatch(groupStudents[j].StudentMatchList, groupStudents[k].StudentMatchList);
          currentGroupScore += commonMatch.MatchScore;
        }
      }
      return currentGroupScore;
    }

    public static List<Group> SetAllGroupScores(List<Group> allGeneratedGroups)
    {
      for (int i = 0; i < allGeneratedGroups.Count; i++)
      {
        int currentGroupScore = GetGroupScore(allGeneratedGroups[i]);
        allGeneratedGroups[i].GroupScore = currentGroupScore;
      }

      return allGeneratedGroups;
    }
  }
}


// we'll have 39 Id pairs for each student
// the 39 Id's will have amount of times they were paired
// 
