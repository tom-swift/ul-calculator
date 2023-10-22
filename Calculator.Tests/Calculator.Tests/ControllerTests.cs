namespace Calculator.Tests;

public class EvaluateControllerTests
{
    private readonly AutoMocker _mocker = new();

    [Theory]
    [InlineData("", 0)]
    public void EmptyInputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
    
    [Theory]
    [InlineData("1", 1)]
    [InlineData("25", 25)]
    public void SingleNumberInputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
    
    [Theory]
    [InlineData("1+1", 2)]
    [InlineData("1+1+1", 3)]
    [InlineData("2-1", 1)]
    [InlineData("1-1", 0)]
    public void SingleOperatorTypeInputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
    
    [Theory]
    [InlineData("2-1+1", 2)]
    public void MultipleOperatorTypeInputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
}