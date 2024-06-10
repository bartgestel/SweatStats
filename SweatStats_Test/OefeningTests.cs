using SweatStats_Logic;
using Moq;
using SweatStats_Logic.Interfaces;

namespace SweatStats_Tests;

[TestClass]
public class OefeningTests
{
    [TestMethod]
    public void GetAllOefeningenTest()
    {
        var mockDal = new Mock<IOefeningDAL>();
        var oefening = new Oefening(mockDal.Object);
        var ExpectedOefeningen = new List<Oefening>{new Oefening(mockDal.Object)};
        mockDal.Setup(x => x.getOefeningen()).Returns(ExpectedOefeningen);
        
        var result = oefening.GetAllOefeningen();
        
        Assert.AreEqual(ExpectedOefeningen, result);
        mockDal.Verify(x => x.getOefeningen(), Times.Once);
    }

    [TestMethod]
    public void AddOefeningTest()
    {
        var mockDal = new Mock<IOefeningDAL>();
        var oefening = new Oefening(mockDal.Object);
        
        oefening.AddOefening("Test", 1, 1, 1, 1, 1);
        
        mockDal.Verify(x => x.AddOefening("Test", 1, 1, 1, 1, 1), Times.Once);
    }
    
    [TestMethod]
    public void DeleteOefeningTest()
    {
        var mockDal = new Mock<IOefeningDAL>();
        var oefening = new Oefening(mockDal.Object);
        
        oefening.DeleteOefening(1);
        
        mockDal.Verify(x => x.DeleteOefening(1), Times.Once);
    }

    [TestMethod]
    public void GetOefeningTest()
    {
        var mockDal = new Mock<IOefeningDAL>();
        var oefening = new Oefening(mockDal.Object);
        
        var result = oefening.GetOefening(1);
        
        mockDal.Verify(x => x.GetOefening(1), Times.Once);
    }
    
    [TestMethod]
    public void UpdateOefeningTest()
    {
        var mockDal = new Mock<IOefeningDAL>();
        var oefening = new Oefening(mockDal.Object);
        
        oefening.UpdateOefening(1, 1, 1, 1, 1);
        
        mockDal.Verify(x => x.UpdateOefening(1, 1, 1, 1, 1), Times.Once);
    }
}