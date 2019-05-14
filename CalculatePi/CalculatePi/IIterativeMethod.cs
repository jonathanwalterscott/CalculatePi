
namespace CalculatePi.Library
{
    public interface IIterativeMethod
    {
        int NumberOfIterations { get; set; }
        int StartIteration { get; set; }
        void Iterations(int start, int numberOfIterations);

        double Calculate();
    }
}
