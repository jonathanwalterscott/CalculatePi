
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
                double result = 0.0;
                for (int i = StartIteration; i < NumberOfIterations; i++)
                {
                    result += ((4.0 / ((2.0 + i) * (3.0 + i) * (4.0 + i))) - (4.0 / ((4.0 + i) * (5.0 + i) * (6.0 + i))));
                }
                return result;
            }
        }
    }
}
