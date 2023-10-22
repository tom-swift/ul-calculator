using System.Globalization;

namespace Calculator;

public class CalculationService : ICalculationService
{
    public double Calculate(List<string> elementStrings, string[] operators)
    {
        EvaluateDivideMultiples(elementStrings);
        return elementStrings.Count == 1 ? Convert.ToDouble(elementStrings[0]) : EvaluatePlusMinus(elementStrings, operators);
    }
    
    private static double EvaluatePlusMinus(List<string> elementStrings, string[] operators)
    {
        var currentOperator = "";
        var output = Convert.ToDouble(elementStrings[0]);

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

    private static void EvaluateDivideMultiples(List<string> elementStrings)
    {
        for (var i = 1; i < elementStrings.Count; i++)
        {
            var currentElement = elementStrings[i];
            switch (currentElement)
            {
                case "/":
                {
                    var evaluatedValue = Convert.ToDouble(elementStrings[i - 1]) / Convert.ToDouble(elementStrings[i + 1]);
                    ReplaceCalculatedElements(elementStrings, i, evaluatedValue);
                    i--;
                    break;
                }
                case "*":
                {
                    var evaluatedValue = Convert.ToDouble(elementStrings[i - 1]) * Convert.ToDouble(elementStrings[i + 1]);
                    ReplaceCalculatedElements(elementStrings, i, evaluatedValue);
                    i--;
                    break;
                }
            }
        }
    }

    private static void ReplaceCalculatedElements(List<string> elementStrings, int i, double evaluatedValue)
    {
        // Removes the number before the operator
        elementStrings.RemoveAt(i - 1);
        // Removes the operator
        elementStrings.RemoveAt(i - 1);
        // Removes the number after the operator
        elementStrings.RemoveAt(i - 1);
        // Inserts the new value back into the array where the previous part of the expression stood
        elementStrings.Insert(i - 1, evaluatedValue.ToString(CultureInfo.InvariantCulture));
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