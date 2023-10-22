using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Calculator;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class EvaluateController : ControllerBase    
{
    public double Get(string inputExpression)
    {
        // I would probably also log the occurrences of this to determine the value
        // of future development around the issue
        if (inputExpression == "") return 0;

        var operators = new[] { "+", "-" };
        var elementStrings = Regex.Split(inputExpression, @"([+\-*/])").ToArray();

        var output = Convert.ToDouble(elementStrings[0]);
        var currentOperator = "";

        for (var i = 1; i < elementStrings.Length;)
        {
            if (operators.Contains(elementStrings[i]))
            {
                currentOperator = elementStrings[i];
            }
            else
            {
                double number = double.Parse(elementStrings[i]);
                switch (currentOperator)
                {
                    case "+":
                        output += number;
                        break;
                    case "-":
                        output -= number;
                        break;
                }
            }

            i++;
        }
        
        return output;
    }
}