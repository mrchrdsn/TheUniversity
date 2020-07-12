namespace TheUniversity.Utilities
{
    public class GradePointAverageCalculator : ICalculator
    {
        private double _average;

        public GradePointAverageCalculator(double average)
        {
            _average = average;
        }

        public double Calculate()
        {
            double gpa = ConvertToGpa(_average);
            return gpa;
        }

        private double ConvertToGpa(double average)
        {
            double gpa = 0.0;

            switch (average)
            {
                case double n when (n >= 93.000):
                    gpa = 4.0;
                    break;
                case double n when (n >= 90.000 && n <= 92.999):
                    gpa = 3.7;
                    break;
                case double n when (n >= 87.000 && n <= 89.999):
                    gpa = 3.3;
                    break;
                case double n when (n >= 83.000 && n <= 86.999):
                    gpa = 3.0;
                    break;
                case double n when (n >= 80.000 && n <= 82.999):
                    gpa = 2.7;
                    break;
                case double n when (n >= 77.000 && n <= 79.999):
                    gpa = 2.3;
                    break;
                case double n when (n >= 73.000 && n <= 76.999):
                    gpa = 2.0;
                    break;
                case double n when (n >= 70.000 && n <= 72.999):
                    gpa = 1.7;
                    break;
                case double n when (n >= 67.000 && n <= 69.999):
                    gpa = 1.3;
                    break;
                case double n when (n >= 65.000 && n <= 66.999):
                    gpa = 1.0;
                    break;
                case double n when (n <= 65.000):
                    gpa = 0.0;
                    break;
            }

            return gpa;
        }
    }
}