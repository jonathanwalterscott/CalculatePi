
namespace CalculatePi
{
    namespace Pi
    {
        public class Gregory_Leibniz
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

            public Gregory_Leibniz()
            {

            }

            public double Calculate()
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
