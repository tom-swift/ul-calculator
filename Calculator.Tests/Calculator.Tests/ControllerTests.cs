namespace Calculator.Tests;

public class EvaluateControllerTests
{
    private readonly Fixture _fixture = new();
    private readonly AutoMocker _mocker = new();

    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("25", 25)]
    [InlineData("1+1", 2)]
    [InlineData("1+1+1", 3)]
    [InlineData("2-1", 1)]
    public void InputString_Returns_ExpectedOutput(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
}