using System;
using System.Collections.Generic;
using System.Linq;

namespace Review2C.Models
{
  public class RepeatCounter
  {
    private string _primary; //this is the string being searched
    private string _target;  //this is the string being looked for
    private int    _wordCount;

    public RepeatCounter(string p="", string t="")
    {
      SetPrimary(p);
      SetTarget(t);
    }

    public string  GetPrimary(){return _primary;}
    public void    SetPrimary(string p){_primary = p;}

    public string   GetTarget(){return _target;}
    public void     SetTarget(string t){_target = t;}

    public int   GetWordCount(){return _wordCount;}
    public void  SetWordCount(){}

    // public int CountRepeats()
    // {
    //
    // }
  }
}
