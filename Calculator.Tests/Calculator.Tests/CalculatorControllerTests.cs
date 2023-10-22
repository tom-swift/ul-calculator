using Microsoft.AspNetCore.Mvc;

namespace Calculator.Tests;

public class CalculatorControllerTests
{
    private readonly Fixture _fixture = new();
    private readonly AutoMocker _mocker = new();
    
    [Fact]
    public void GetAction_ShouldHaveHttpGetAttribute()
    {
        // Arrange
        var controllerType = typeof(CalculatorController);
        var methodInfo = controllerType.GetMethod("Get");

        // Act & Assert
        methodInfo.Should().BeDecoratedWith<HttpGetAttribute>();
    }

    [Fact]
    public void GetAction_ReturnsExpected_FromCalculationService()
    {
        // Arrange
        var subject = _mocker.CreateInstance<CalculatorController>();
        var input = "1+2+3-4*7/5";
        var inputArray = new List<string> { "1", "+", "2", "+", "3", "-", "4", "*", "7", "/", "5" };
        var response = _fixture.Create<double>();

        _mocker.GetMock<ICalculationService>()
            .Setup(cs => cs.Calculate(inputArray, new[] { "+", "-", "*", "/" }))
            .Returns(response);

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(response);
        
    }
}