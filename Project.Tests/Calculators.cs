using NUnit.Framework;
using System.Collections.Generic;
using TheUniversity.Utilities;

namespace Project.Tests
{
    [TestFixture]
    public class Calculators
    {
        public List<double> Make_GradesList()
        {
            List<double> grades = new List<double>();
            grades.Add(100);
            grades.Add(97);
            grades.Add(100);
            grades.Add(97);
            grades.Add(100);
            grades.Add(99);
            grades.Add(94);
            grades.Add(95);
            return grades;
        }

        public List<double> Make_GpaList()
        {
            List<double> gpas = new List<double>();
            gpas.Add(4.0);
            gpas.Add(4.0);
            gpas.Add(3.7);
            gpas.Add(3.3);

            return gpas;
        }

        [Test]
        public void AverageCalculator_Calculate_ReturnsCorrectAverage()
        {
            List<double> grades = Make_GradesList();
            ICalculator calculator = new AverageCalculator(grades);

            double result = calculator.Calculate();

            Assert.AreEqual(97.750d, result);
        }

        [Test]
        [TestCase(97.3, 4.0)]
        [TestCase(91.6, 3.7)]
        [TestCase(80.7, 2.7)]
        public void GradePointAverageCalculator_Calculate_ReturnsCorrectGpa(double average, double gpa)
        {
            ICalculator gpaCalculator = new GradePointAverageCalculator(average);
            double result = gpaCalculator.Calculate();

            Assert.AreEqual(gpa, result);
        }

        [Test]
        public void CumulativeGpaCalculator_Calculate_ReturnsCorrectCumulativeGpaAverage()
        {
            List<double> gpas = Make_GpaList();

            ICalculator calculator = new AverageCalculator(gpas);

            double result = calculator.Calculate();

            Assert.AreEqual(3.75, result);
        }
    }
}