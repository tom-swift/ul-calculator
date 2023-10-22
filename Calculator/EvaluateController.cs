using Microsoft.AspNetCore.Mvc;

namespace Calculator;

[ApiController]
[Route("[controller]")]
public class EvaluateController : ControllerBase    
{
    public double Get(string inputExpression)
    {
        return 0;
    }
}