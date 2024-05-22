using Microsoft.VisualStudio.TestTools.UnitTesting;
using SweatStats_Logic;
using Moq;
using SweatStats_Logic.Interfaces;

namespace SweatStats_Tests;

[TestClass]
public class TrainingTests
{
    [TestMethod]
    public void AddTraining()
    {
        // Arrange
        var mockDal = new Mock<ITrainingDAL>();
        mockDal.Setup(x => x.AddTraining(It.IsAny<string>())).Returns(true);
        var training = new Training(mockDal.Object);

        // Act
        var result = training.AddTraining("Test");

        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void GetAllTrainings()
    {
        // Arrange
        var mockDal = new Mock<ITrainingDAL>();
        mockDal.Setup(x => x.GetAllTrainings(It.IsAny<int>())).Returns(new List<Training>());
        var training = new Training(mockDal.Object);

        // Act
        var result = training.GetAllTrainings();

        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public void DeleteTraining()
    {
        // Arrange
        var mockDal = new Mock<ITrainingDAL>();
        mockDal.Setup(x => x.DeleteTraining(It.IsAny<int>())).Returns(true);
        var training = new Training(mockDal.Object);

        // Act
        var result = training.DeleteTraining(1);

        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void GetTraining()
    {
        // Arrange
        var mockDal = new Mock<ITrainingDAL>();
        mockDal.Setup(x => x.GetTraining(It.IsAny<int>())).Returns(new Training(mockDal.Object));
        var training = new Training(mockDal.Object);

        // Act
        var result = training.GetTraining(1);

        Assert.IsNotNull(result);
    }

}