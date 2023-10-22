using Microsoft.AspNetCore.Mvc;

namespace Calculator;

[ApiController]
[Route("[controller]")]
public class EvaluateController : ControllerBase    
{
    public double Get(string inputExpression)
    {
        // I would probably also log the occurrences of this to determine the value
        // of future development around the issue
        if (inputExpression == "") return 0;

        var operators = new[] { '+' };
        var numberStrings = inputExpression.Split(operators);

        var numbers = numberStrings.Select(Convert.ToDouble);

        return numbers.Sum();
    }
}