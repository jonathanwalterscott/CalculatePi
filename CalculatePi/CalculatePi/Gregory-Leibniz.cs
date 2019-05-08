
namespace CalculatePi
{
    namespace Pi
    {
        public class Gregory_Leibniz
        {
            #region
            public int Iterations { get; set; }
            #endregion

            public Gregory_Leibniz()
            {

            }

            public double Calculate()
            {
                double result = 0.0;
                for (int i = 0; i < Iterations; i++)
                {
                    result += ((4.0 / (1.0 + i * 4.0)) - (4.0 / (3.0 + i * 4.0)));
                }
                return result;
            }
        }
    }
}
