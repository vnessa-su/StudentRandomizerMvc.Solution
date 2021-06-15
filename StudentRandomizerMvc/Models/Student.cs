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

    public static List<Match> GetMatchList()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Match> matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());
      return matchList;
    }

    public Student(string name)
    {
      this.Name = name;
    }

  }
}