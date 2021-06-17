using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRandomizerMvc.Models
{
  public class GroupSelection
  {
    public static List<Group> SelectBestGroups(List<Group> allGroups, int numberOfGroups, List<Student> allStudents)
    {
      Random rnd = new Random();
      List<Group> shuffledGroups = allGroups.OrderBy(x => rnd.Next()).ToList();
      List<Group> sortedGroupsByScore = shuffledGroups.OrderBy(group => group.GroupScore).ToList();
      List<Group> selectedGroups = new List<Group>();
      List<Student> studentsInSelectedGroups = new List<Student>();

      for (int index = 0; index < sortedGroupsByScore.Count; index++)
      {
        Group currentGroup = sortedGroupsByScore[index];
        List<Student> currentGroupStudents = currentGroup.DevTeamStudents;
        List<Student> commonStudents = studentsInSelectedGroups.Intersect(currentGroupStudents).ToList();

        if (commonStudents.Count == 0)
        {
          selectedGroups.Add(currentGroup);
          studentsInSelectedGroups.AddRange(currentGroupStudents);
        }

        if (selectedGroups.Count == numberOfGroups)
        {
          break;
        }
      }

      List<Student> leftoverStudents = Student.FindStudentsNotIncluded(allStudents, studentsInSelectedGroups);
      List<Group> leftoversAddedGroups = AddExtraStudents(selectedGroups, leftoverStudents);
      return leftoversAddedGroups;
    }

    public static List<Group> AddExtraStudents(List<Group> groups, List<Student> leftoverStudents)
    {
      int groupCount = groups.Count;
      int groupIndex = 0;

      foreach (Student student in leftoverStudents)
      {
        groups[groupIndex].DevTeamStudents.Add(student);
        groups[groupIndex].GroupScore = GroupScore.GetGroupScore(groups[groupIndex]);
        groupIndex++;
        if (groupIndex >= groupCount)
        {
          groupIndex = 0;
        }
      }

      return groups;
    }
  }
}