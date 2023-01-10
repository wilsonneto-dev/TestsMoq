using FluentAssertions;
using Moq;

namespace TestMoq;

public class UnitTest1
{
    [Fact]
    public void TestParamsGeneric()
    {
        var mock = new Mock<IMyService>();
        mock.Setup(x => x.GetMyValue(It.IsAny<object[]>())).Returns("Hello World");

        var msg = mock.Object.GetMyValue("", "1", "2" );

        msg.Should().Be("Hello World");
        mock.Verify(x => x.GetMyValue(It.IsAny<object[]>()));
        mock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void TestParamsWithValues()
    {
        var mock = new Mock<IMyService>();
        mock.Setup(x => x.GetMyValue(new object[] { "", "1", "2" })).Returns("Hello World");

        var msg = mock.Object.GetMyValue("", "1", "2");

        msg.Should().Be("Hello World");
        mock.Verify(x => x.GetMyValue(It.IsAny<string>(), "1", "2" ));
        mock.VerifyNoOtherCalls();
    }
}

public interface IMyService
{
    public string GetMyValue(params object[] args);
}