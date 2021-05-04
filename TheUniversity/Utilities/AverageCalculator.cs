using System;
using System.Collections.Generic;
using System.Linq;

namespace TheUniversity.Utilities
{
    public class AverageCalculator : ICalculator
    {
        private List<double> _inputList = new List<double>();
        public AverageCalculator(List<double> input)
        {
            _inputList = input;
        }

        public double Calculate()
        {
            double sum = _inputList.Sum();
            double output = Math.Round((sum / _inputList.Count), 3);

            return output;
        }
    }
}