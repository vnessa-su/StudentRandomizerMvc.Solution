using System.Collections.Generic;
using System.Linq;

namespace StudentRandomizerMvc.Models
{
  public class GroupGenerator
  {
    public static List<Group> GenerateAllPossibleGroups(List<Student> studentList, int groupSize)
    {
      List<Group> allGeneratedGroups = new List<Group>();
      Stack<Student> studentStack = new Stack<Student>();
      allGeneratedGroups = RecursiveCombinationGenerator(allGeneratedGroups, studentStack, studentList, 0, groupSize);

      return allGeneratedGroups;
    }

    private static List<Group> RecursiveCombinationGenerator(List<Group> groupList, Stack<Student> tempStudentStack, List<Student> inputStudentList, int startIndex, int groupSize)
    {
      if (groupSize == 0)
      {
        List<Student> tempStudentList = new List<Student>(tempStudentStack.ToArray().ToList());
        Group newGroup = new Group();
        newGroup.DevTeamStudents = tempStudentList;
        groupList.Add(newGroup);
        return groupList;
      }

      for (int i = startIndex; i < inputStudentList.Count; i++)
      {
        tempStudentStack.Push(inputStudentList[i]);
        RecursiveCombinationGenerator(groupList, tempStudentStack, inputStudentList, i + 1, groupSize - 1);
        tempStudentStack.Pop();
      }

      return groupList;
    }
  }
}