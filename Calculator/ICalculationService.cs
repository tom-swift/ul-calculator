namespace Calculator;

public interface ICalculationService
{
    public double Calculate(List<string> elementStrings, string[] operators);
}