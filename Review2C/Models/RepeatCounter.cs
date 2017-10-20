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
    private int    _error = 0; //used to get error information

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

    public int    GetError()       {return _error;}
    public void   SetError(int e) {_error += e;}

    public int CountRepeats()
    {
      bool currentMatch = false;
      SetPrimary(_primary.ToLower());
      SetTarget(_target.ToLower());

      if (ErroneousInput()>0)
      { SetMatchesFound(0); return 0;}
      for (int i = 0 ; i <= GetPrimary().Length-GetTarget().Length ; i++)
      {
        if (GetPrimary()[i] == GetTarget()[0])
        {
          for(int n = 0 ; n < GetTarget().Length ; n++)
          {
            if (GetPrimary()[i+n] != GetTarget()[n])
            { currentMatch = false; break; }
            currentMatch = true;
          }
          if (currentMatch)
          { _matchesFound+=1; }
        }
      }

      return GetMatchesFound();
    }

    public int ErroneousInput()
    {
      if (_primary.Length<=0)
      { SetPrimary("ERR: NO STRING GIVEN"); SetError(_error++); }
      if (_target.Length<=0)
      { SetTarget("ERR: NO STRING GIVEN"); SetError(_error++); }

      return GetError();
    }
  }
}
