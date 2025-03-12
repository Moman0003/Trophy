using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Trophy.Tests;

[TestClass]
[TestSubject(typeof(Trophy))]
public class TrophyTest
{
    [TestMethod]
    public void Valid_Trophy_Creation_ReturnsCorrectValues()
    {
        
        var trophy = new Trophy();

        trophy.Id = 1;
        trophy.Competition = "World Cup";
        trophy.Year = 2020;

        Assert.AreEqual(1, trophy.Id);
        Assert.AreEqual("World Cup", trophy.Competition);
        Assert.AreEqual(2020, trophy.Year);
        Assert.AreEqual("Id: 1, Competition: World Cup, Year: 2020", trophy.ToString());
    }
    
    [TestMethod]
    public void Setting_Competition_Null_ThrowsArgumentNullException()
    {
        var trophy = new Trophy();
        Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
    }

    [TestMethod]
    public void Setting_Competition_WithLessThanThreeCharacters_ThrowsArgumentException()
    {
        var trophy = new Trophy();
        Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "AB");
    }

    [TestMethod]
    public void Setting_Year_LessThan1970_ThrowsArgumentOutOfRangeException()
    {
        var trophy = new Trophy();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);
    }

    [TestMethod]
    public void Setting_Year_GreaterThan2025_ThrowsArgumentOutOfRangeException()
    {
        var trophy = new Trophy();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 2026);
    }
    
    
}