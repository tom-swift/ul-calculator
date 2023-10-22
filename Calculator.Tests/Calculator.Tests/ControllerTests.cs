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
    [InlineData("1*1", 1)]
    [InlineData("1*2", 2)]
    [InlineData("1/1", 1)]
    [InlineData("2/1", 2)]
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
    [InlineData("3+1/2", 3.5)]
    [InlineData("3+1/2/2", 3.25)]
    public void MultipleOperatorTypeInputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
    
    [Theory]
    [InlineData("4+5*2", 14)]
    [InlineData("4+5/2", 6.5)]
    [InlineData("4+5/2-1", 5.5)]
    public void Example_Tests(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
}