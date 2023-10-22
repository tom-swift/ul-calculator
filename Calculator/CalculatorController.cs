using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Calculator;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase    
{
    private readonly ICalculationService _calculationService;

    public CalculatorController(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }
    
    [HttpGet]
    public double Get(string inputExpression)
    {
        // I would probably also log the occurrences of this to determine the value
        // of future development around the issue
        if (inputExpression == "") return 0;

        var operators = new[] { "+", "-", "*", "/" };
        var elementStrings = Regex.Split(inputExpression, @"([+\-*/])").ToList();
        
        var output = _calculationService.Calculate(elementStrings, operators);

        return output;
    }
}