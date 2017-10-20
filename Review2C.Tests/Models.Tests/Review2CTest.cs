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
      Assert.AreEqual(true, (myCounter.GetPrimary().Length)>(myCounter.GetTarget().Length));
    }
    [TestMethod]
    public void CountRepeats_PlayerEntersTargetString_NoPrimary()
    {
      RepeatCounter myCounter = new RepeatCounter("","word");
      Assert.AreEqual(true, (myCounter.GetPrimary().Length)<(myCounter.GetTarget().Length));
    }
  }
}
