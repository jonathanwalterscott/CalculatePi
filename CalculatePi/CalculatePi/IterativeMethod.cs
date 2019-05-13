using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatePi.Library
{
    public class IterativeMethod
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
    }
}
