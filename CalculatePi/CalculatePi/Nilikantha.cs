
namespace CalculatePi
{
    namespace Pi
    {
        public class Nilikantha
        {
            #region
            public int NumberOfIterations { get; set; }
            public int StartIteration { get; set; }
            public void Iterations(int start, int numberOfIterations)
            {
                StartIteration = start;
                NumberOfIterations = numberOfIterations;
            }
            #endregion

            public Nilikantha()
            {

            }

            public double Calculate()
            {
                // TODO The formula below could be simplified a bit more to make it even faster
                double result = 0.0;
                for (int i = StartIteration; i < NumberOfIterations; i++)
                {
                    result += ((4.0 / ((4.0 * i + 2.0) * (4.0 * i + 3.0) * (4.0 * i + 4.0))) - (4.0 / ((4.0 * i + 4.0) * (4.0 * i + 5.0) * (4.0 * i + 6.0))));
                }
                return result;
            }
        }
    }
}
