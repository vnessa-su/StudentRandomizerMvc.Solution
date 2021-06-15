using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRandomizerMvc.Models
{
  public class Match : IEquatable<Match>
  {
    public int MatchId { get; set; }
    public int Score { get; set; }

    public bool Equals(Match matchToCompare)
    {
      if (matchToCompare is null)
      {
        return false;
      }

      if (this.MatchId == matchToCompare.MatchId && this.Score == matchToCompare.Score)
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
  }
}