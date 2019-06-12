
namespace CalculatePi
{
    namespace Library
    {
        public class Nilikantha : IterativeMethod
        {
            public Nilikantha()
            {

            }

            public override double Calculate()
            {
                // TODO The formula below could be simplified a bit more to make it even faster
                double result = 3.0;
                for (int i = StartIteration; i < NumberOfIterations; i++)
                {
                    result += ((4.0 / ((4.0 * i + 2.0) * (4.0 * i + 3.0) * (4.0 * i + 4.0))) - (4.0 / ((4.0 * i + 4.0) * (4.0 * i + 5.0) * (4.0 * i + 6.0))));
                }
                return result;
            }
        }
    }
}
