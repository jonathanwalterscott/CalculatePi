
namespace CalculatePi
{
    namespace Library
    {
        public class Gregory_Leibniz : IterativeMethod
        {
            public Gregory_Leibniz()
            {

            }

            public override double Calculate()
            {
                double result = 0.0;
                for (int i = StartIteration; i < NumberOfIterations; i++)
                {
                    result += ((4.0 / (1.0 + i * 4.0)) - (4.0 / (3.0 + i * 4.0)));
                }
                return result;
            }
        }
    }
}
