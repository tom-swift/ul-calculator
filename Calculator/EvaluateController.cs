using System.Globalization;
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
        var elementStrings = Regex.Split(inputExpression, @"([+\-*/])").ToList();
        
        var output = Calculate(elementStrings, operators);

        return output;
    }

    private static double Calculate(List<string> elementStrings, string[] operators)
    {
        var output = Convert.ToDouble(elementStrings[0]);
        var currentOperator = "";

        // evaluate division first
        for (var i = 1; i < elementStrings.Count;)
        {
            var currentElement = elementStrings[i];
            if(currentElement == "/")
            {
                var evaluatedValue = Convert.ToDouble(elementStrings[i-1])/Convert.ToDouble(elementStrings[i+1]);
                elementStrings.RemoveAt(i-1);
                elementStrings.RemoveAt(i-1);
                elementStrings.RemoveAt(i-1);
                elementStrings.Insert(i-1, evaluatedValue.ToString(CultureInfo.InvariantCulture));
                i--;
            }

            i++;
        }
        
        // evaluate multiplications
        for (var i = 1; i < elementStrings.Count;)
        {
            var currentElement = elementStrings[i];
            if(currentElement == "*")
            {
                var evaluatedValue = Convert.ToDouble(elementStrings[i-1])*Convert.ToDouble(elementStrings[i+1]);
                elementStrings.RemoveAt(i-1);
                elementStrings.RemoveAt(i-1);
                elementStrings.RemoveAt(i-1);
                elementStrings.Insert(i-1, evaluatedValue.ToString(CultureInfo.InvariantCulture));
                i--;
            }

            i++;
        }

        if (elementStrings.Count == 1) return Convert.ToDouble(elementStrings[0]);
        
        // evaluate +-
        for (var i = 1; i < elementStrings.Count;)
        {
            var currentElement = elementStrings[i];
            if (operators.Contains(currentElement))
            {
                currentOperator = currentElement;
            }
            else
            {
                output = ApplyBasicOperator(currentElement, currentOperator, output);
            }

            i++;
        }

        return output;
    }

    private static double ApplyBasicOperator(string elementString, string currentOperator, double output)
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
        }

        return output;
    }
}