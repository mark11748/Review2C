using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Review2C.Models;

namespace Review2C.Tests
{
  [TestClass]
  public class Review2CTest
  {
    [TestMethod]
    public void RepeatCounter_BuildCounter_()
    {
      try
      {
        RepeatCounter myCounter = new RepeatCounter();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Message = {0}", ex.Message);
        Console.WriteLine("Source = {0}", ex.Source);
        Console.WriteLine("StackTrace = {0}", ex.StackTrace);
      }
    }
    [TestMethod]
    public void CountRepeats_PlayerEntersPrimaryString_NoTarget()
    {
      RepeatCounter myCounter = new RepeatCounter("word","");
      Console.WriteLine(myCounter.GetPrimary());
      Assert.AreEqual(true, (myCounter.GetPrimary().Length)>(myCounter.GetTarget().Length));
    }
    [TestMethod]
    public void CountRepeats_PlayerEntersTargetString_NoPrimary()
    {
      RepeatCounter myCounter = new RepeatCounter("","word");
      Console.WriteLine(myCounter.GetTarget());
      Assert.AreEqual(true, (myCounter.GetPrimary().Length)<(myCounter.GetTarget().Length));
    }
    [TestMethod]
    public void CountRepeats_SetPrimaryAndTarget()
    {
      RepeatCounter myCounter = new RepeatCounter("word","word");
      Console.WriteLine(myCounter.GetPrimary() +" : "+ myCounter.GetTarget());
      Assert.AreEqual(true, myCounter.GetPrimary() == myCounter.GetTarget());
    }


    [TestMethod]
    public void CountRepeats_FindInstancesOfWord()
    {
      RepeatCounter myCounter = new RepeatCounter("ThIs String contains two instances of the word STRING","string");
      int matchesFound = 0;
      bool currentMatch = false;

      Console.WriteLine(myCounter.GetPrimary() +" : "+ myCounter.GetTarget());

      myCounter.SetPrimary(myCounter.GetPrimary().ToLower());
      myCounter.SetTarget(myCounter.GetTarget().ToLower());

      Console.WriteLine(myCounter.GetPrimary() +" : "+ myCounter.GetTarget());

      for (int i = 0 ; i <= myCounter.GetPrimary().Length-myCounter.GetTarget().Length ; i++)
      // ^^ itterates through the main string. ^^
      //    don't bother continuing to look if there's not enough space to complete search term
      {
        if (myCounter.GetPrimary()[i] == myCounter.GetTarget()[0])
        // ^^ If you find an instance of the first letter of the search word ^^
        {
          Console.WriteLine("Possible Match found at index: "+i);

          for(int n = 1 ; n < myCounter.GetTarget().Length ; n++)
          // ^^ search for the rest of the phrase before moving on ^^
          {
            if (myCounter.GetPrimary()[i+n] != myCounter.GetTarget()[n])
            { currentMatch = false; break; }
            currentMatch = true;
          }
          if (currentMatch)
          { matchesFound++; }
        }
      }
      Assert.AreEqual(true, matchesFound == 2);
    }
  }
}
