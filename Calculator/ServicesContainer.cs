namespace Calculator;

public static class ServicesContainer
{
    public static void AddCalculatorServices(this IServiceCollection services)
    {
        services.AddTransient<ICalculationService, CalculationService>();
    }
}