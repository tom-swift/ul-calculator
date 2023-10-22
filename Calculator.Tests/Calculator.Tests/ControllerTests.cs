namespace Calculator.Tests;

public class EvaluateControllerTests
{
    private readonly Fixture _fixture = new();
    private readonly AutoMocker _mocker = new();

    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("25", 25)]
    public void BlankString_Returns_Zero(string input, double expectedOutput)
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get(input);

        // Assert
        result.Should().Be(expectedOutput);
    }
}