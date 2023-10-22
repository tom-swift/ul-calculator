namespace Calculator.Tests;

public class EvaluateControllerTests
{
    private readonly Fixture _fixture = new();
    private readonly AutoMocker _mocker = new();
    [Fact]
    public void Get_Returns_Integer()
    {
        // Arrange
        var subject = _mocker.CreateInstance<EvaluateController>();

        // Act
        var result = subject.Get();

        // Assert
        result.Should().BeOfType(typeof(int));

    }
}