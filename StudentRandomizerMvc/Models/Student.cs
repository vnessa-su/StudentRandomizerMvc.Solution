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

  }
}