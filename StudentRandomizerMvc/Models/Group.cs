using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentRandomizerMvc.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public int GroupScore { get; set; }
    public List<Student> DevTeamStudents { get; set; }

    private static string _route = "groups";

    public static List<Group> GetAllStoredGroups()
    {
      var apiCallTask = ApiHelper.GetAll(_route);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static List<Group> GetAllStoredGroupsForStudent(int studentId)
    {
      var apiCallTask = ApiHelper.GetAll(_route, studentId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());
    }
  }
}