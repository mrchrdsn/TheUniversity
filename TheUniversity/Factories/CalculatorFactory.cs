using TheUniversity.Utilities;

namespace TheUniversity.Factories
{
    public class CalculatorFactory
    {
        public static ICalculator Create<T>() where T : ICalculator, new()
        {
            return new T();
        }
    }
}
