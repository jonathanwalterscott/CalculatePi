
namespace CalculatePi.Library
{
    public abstract class IterativeMethod : IIterativeMethod
    {
        #region Properties
        public int NumberOfIterations { get; set; }
        public int StartIteration { get; set; }
        public void Iterations(int start, int numberOfIterations)
        {
            StartIteration = start;
            NumberOfIterations = numberOfIterations;
        }
        #endregion

        public abstract double Calculate();
    }
}
