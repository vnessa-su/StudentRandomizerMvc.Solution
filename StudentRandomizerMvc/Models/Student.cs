using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentRandomizerMvc.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    public string Name { get; set; }

    public List<Match> StudentMatchList { get; set; }
    public List<Group> StudentGroupList { get; set; }

    private static string _route = "students";

    public static List<Student> GetAllStudents()
    {
      var apiCallTask = ApiHelper.GetAll(_route);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(jsonResponse.ToString());
      return studentList;
    }

    public static Student GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(_route, id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Student student = JsonConvert.DeserializeObject<Student>(jsonResponse.ToString());
      return student;
    }

    public static void Post(Student student)
    {
      string jsonStudent = JsonConvert.SerializeObject(student);
      var apiCallTask = ApiHelper.Post(_route, jsonStudent);
    }

    public static void Put(Student student)
    {
      string jsonStudent = JsonConvert.SerializeObject(student);
      var apiCallTask = ApiHelper.Put(_route, student.StudentId, jsonStudent);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(_route, id);
    }

    public Student(string name)
    {
      this.Name = name;
    }

    public static List<Student> GetMatchStudents(int id)
    {
      string extendedRoute = _route + "/Match";
      var apiCallTask = ApiHelper.GetJoin(extendedRoute, id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<MatchStudent> joinList = JsonConvert.DeserializeObject<List<MatchStudent>>(jsonResponse.ToString());

      List<Student> studentList = new List<Student>();
      foreach (MatchStudent join in joinList)
      {
        var apiStudentCallTask = ApiHelper.Get(_route, join.StudentId);
        var studentResult = apiStudentCallTask.Result;

        JObject jsonStudentResponse = JsonConvert.DeserializeObject<JObject>(studentResult);
        Student student = JsonConvert.DeserializeObject<Student>(jsonStudentResponse.ToString());

        studentList.Add(student);
      }
      return studentList;
    }

    public static List<Student> GetGroupStudents(int id)
    {
      string extendedRoute = _route + "/Group";
      var apiCallTask = ApiHelper.GetJoin(extendedRoute, id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<GroupStudent> joinList = JsonConvert.DeserializeObject<List<GroupStudent>>(jsonResponse.ToString());

      List<Student> studentList = new List<Student>();
      foreach (GroupStudent join in joinList)
      {
        var apiStudentCallTask = ApiHelper.Get(_route, join.StudentId);
        var studentResult = apiStudentCallTask.Result;

        JObject jsonStudentResponse = JsonConvert.DeserializeObject<JObject>(studentResult);
        Student student = JsonConvert.DeserializeObject<Student>(jsonStudentResponse.ToString());

        studentList.Add(student);
      }
      return studentList;
    }
  }
}