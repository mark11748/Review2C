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
    public void CountRepeats_FindInstancesOfWord_CounterTest()
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

          for(int n = 0 ; n < myCounter.GetTarget().Length ; n++)
          // ^^ search for the rest of the phrase before moving on ^^
          {
            if (myCounter.GetPrimary()[i+n] != myCounter.GetTarget()[n]) //if the selected index in the primary string + target_offset ever mismatches target[offset] case is not a match
            { currentMatch = false; break; }
            currentMatch = true;
          }
          if (currentMatch) //if the target's length is looped through and all letters match increment matchesFound
          {
            Console.WriteLine("Match found at index: "+i);
            matchesFound++;
          }
        }
      }
      Assert.AreEqual(true, matchesFound == 2);
    }

    [TestMethod]
    public void CountRepeats_FindInstancesOfWord_LoopRangeCheck()
    {
      RepeatCounter myCounter = new RepeatCounter("ThIs String contains two instances of the word STRIN","string");
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

          for(int n = 0 ; n < myCounter.GetTarget().Length ; n++)
          // ^^ search for the rest of the phrase before moving on ^^
          {
            if (myCounter.GetPrimary()[i+n] != myCounter.GetTarget()[n]) //if the selected index in the primary string + target_offset ever mismatches target[offset] case is not a match
            { currentMatch = false; break; }
            currentMatch = true;
          }
          if (currentMatch) //if the target's length is looped through and all letters match increment matchesFound
          {
            Console.WriteLine("Match found at index: "+i);
            matchesFound++;
          }
        }
      }
      Assert.AreEqual(true, matchesFound == 1);
    }

    [TestMethod]
    public void ErrorTest_MissingStrings_FalseCase()
    {
      RepeatCounter myCounter = new RepeatCounter("","");
      if (myCounter.GetPrimary().Length<=0)
      { myCounter.SetPrimary("ERR: NO STRING GIVEN"); myCounter.SetError(1); }
      if (myCounter.GetTarget().Length<=0)
      { myCounter.SetTarget("ERR: NO STRING GIVEN"); myCounter.SetError(1); }

      Assert.AreEqual(false, myCounter.GetError() == 0 );

    }
    [TestMethod]
    public void ErrorTest_MissingStrings_TrueCase()
    {
      RepeatCounter myCounter = new RepeatCounter("","");
      if (myCounter.GetPrimary().Length<=0)
      { myCounter.SetPrimary("ERR: NO STRING GIVEN"); myCounter.SetError(1); }
      if (myCounter.GetTarget().Length<=0)
      { myCounter.SetTarget("ERR: NO STRING GIVEN"); myCounter.SetError(1); }

      Assert.AreEqual(true, myCounter.GetError() == 2 );

    }
  }
}
