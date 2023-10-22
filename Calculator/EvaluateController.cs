using System.Text.RegularExpressions;
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

        var operators = new[] { "+", "-", "*", "/" };
        var elementStrings = Regex.Split(inputExpression, @"([+\-*/])").ToArray();

        var output = Calculate(elementStrings, operators);

        return output;
    }

    private static double Calculate(string[] elementStrings, string[] operators)
    {
        var output = Convert.ToDouble(elementStrings[0]);
        var currentOperator = "";

        for (var i = 1; i < elementStrings.Length;)
        {
            var currentElement = elementStrings[i];
            if (operators.Contains(currentElement))
            {
                currentOperator = currentElement;
            }
            else
            {
                output = ApplyOperator(currentElement, currentOperator, output);
            }

            i++;
        }

        return output;
    }

    private static double ApplyOperator(string elementString, string currentOperator, double output)
    {
        var number = double.Parse(elementString);
        switch (currentOperator)
        {
            case "+":
                output += number;
                break;
            case "-":
                output -= number;
                break;
            case "*":
                output *= number;
                break;
            case "/":
                output /= number;
                break;
        }

        return output;
    }
}