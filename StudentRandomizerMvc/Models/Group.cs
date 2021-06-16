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

    public static List<Group> GetAllDatabaseGroups()
    {
      var apiCallTask = ApiHelper.GetAll(_route);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static List<Group> GetAllDatabaseGroupsForStudent(int studentId)
    {
      string extendedRoute = _route + "ADD_EXTENSION_HERE?studentId=";
      var apiCallTask = ApiHelper.GetAllByForeignKey(extendedRoute, studentId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static Group GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(_route, id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

      return group;
    }

    public static void Post(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.Post(_route, jsonGroup);
    }

    public static void Put(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.Put(_route, group.GroupId, jsonGroup);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(_route, id);
    }

    public static List<Student> GetGroupStudents(int id)
    {
      string extendedRoute = _route + "ADD_EXTENSION_HERE";
      var apiCallTask = ApiHelper.GetJoin(extendedRoute, id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<GroupStudent> joinList = JsonConvert.DeserializeObject<List<GroupStudent>>(jsonResponse.ToString());

      List<Student> studentList = new List<Student>();
      string studentRoute = "students";
      foreach (GroupStudent join in joinList)
      {
        var apiStudentCallTask = ApiHelper.Get(studentRoute, join.StudentId);
        var studentResult = apiStudentCallTask.Result;

        JObject jsonStudentResponse = JsonConvert.DeserializeObject<JObject>(studentResult);
        Student student = JsonConvert.DeserializeObject<Student>(jsonStudentResponse.ToString());

        studentList.Add(student);
      }
      return studentList;
    }

    public static void AddGroupStudent(int id, Student student)
    {
      string extendedRoute = _route + "ADD_EXTENSION_HERE";
      string jsonStudent = JsonConvert.SerializeObject(student);
      var apiCallTask = ApiHelper.PostJoin(extendedRoute, id, jsonStudent);
    }

    public static void DeleteGroupStudent(int id, int studentId)
    {
      string extendedRoute = _route + "ADD_EXTENSION_HERE";
      string studentRoute = "student";
      var apiCallTask = ApiHelper.DeleteJoin(extendedRoute, id, studentRoute, studentId);
    }
  }
}