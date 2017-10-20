using System;
using System.Collections.Generic;
using System.Linq;

namespace Review2C.Models
{
  public class RepeatCounter
  {
    private string _primary; //this is the string being searched
    private string _target;  //this is the string being looked for
    private int    _matchesFound;

    public RepeatCounter(string p="", string t="")
    {
      SetPrimary(p);
      SetTarget(t);
      SetMatchesFound(0);
    }

    public string GetPrimary()            {return _primary;}
    public void   SetPrimary(string p)    {_primary = p;}

    public string GetTarget()             {return _target;}
    public void   SetTarget(string t)     {_target = t;}

    public int    GetMatchesFound()       {return _matchesFound;}
    public void   SetMatchesFound(int mf) {_matchesFound = mf;}

    public int CountRepeats()
    {
      bool currentMatch = false;

      this.SetPrimary(this.GetPrimary().ToLower());
      this.SetTarget(this.GetTarget().ToLower());

      for (int i = 0 ; i <= this.GetPrimary().Length-this.GetTarget().Length ; i++)
      {
        if (this.GetPrimary()[i] == this.GetTarget()[0])
        {
          for(int n = 0 ; n < this.GetTarget().Length ; n++)
          {
            if (this.GetPrimary()[i+n] != this.GetTarget()[n])
            { currentMatch = false; break; }
            currentMatch = true;
          }
          if (currentMatch)
          { matchesFound+=1; }
        }
      }
    }
  }
}
