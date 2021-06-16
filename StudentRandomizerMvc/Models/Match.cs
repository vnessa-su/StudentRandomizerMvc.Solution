using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRandomizerMvc.Models
{
  public class Match : IEquatable<Match>
  {
    public int MatchId { get; set; }
    public int Score { get; set; }

    private static string _route = "matches";

    public bool Equals(Match matchToCompare)
    {
      if (matchToCompare is null)
      {
        return false;
      }

      if (MatchId == matchToCompare.MatchId && Score == matchToCompare.Score)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public override bool Equals(object obj) => Equals(obj as Match);
    public override int GetHashCode() => (MatchId, Score).GetHashCode();

    public static Match FindCommonMatch(List<Match> studentMatches1, List<Match> studentMatches2)
    {
      IEnumerable<Match> commonMatchList = studentMatches1.Intersect(studentMatches2);
      if (commonMatchList.Count() > 1)
      {
        throw new Exception("More than one match found");
      }

      return commonMatchList.ElementAt(0);
    }

    public static List<Match> GetAllMatches()
    {
      var apiCallTask = ApiHelper.GetAll(_route);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Match> matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());

      return matchList;
    }

    public static List<Match> GetAllMatchesForStudent(int studentId)
    {
      string extendedRoute = _route + "/GetStudent";
      var apiCallTask = ApiHelper.GetAllByForeignKey(extendedRoute, studentId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Match> matchList = JsonConvert.DeserializeObject<List<Match>>(jsonResponse.ToString());

      return matchList;
    }

    public static Match GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(_route, id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Match match = JsonConvert.DeserializeObject<Match>(jsonResponse.ToString());

      return match;
    }

    public static void Post(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiHelper.Post(_route, jsonMatch);
    }

    public static void Put(Match match)
    {
      string jsonMatch = JsonConvert.SerializeObject(match);
      var apiCallTask = ApiHelper.Put(_route, match.MatchId, jsonMatch);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(_route, id);
    }

    public static void AddMatchStudent(int id, Student student)
    {
      string extendedRoute = _route + "/AddStudent";
      string jsonStudent = JsonConvert.SerializeObject(student);
      var apiCallTask = ApiHelper.PostJoin(extendedRoute, id, jsonStudent);
    }

    public static void DeleteMatchStudent(int id, int studentId)
    {
      string extendedRoute = "/Student";
      var apiCallTask = ApiHelper.DeleteJoin(_route, id, extendedRoute, studentId);
    }
  }
}