using System;
using Xunit;

namespace AreaLib.Tests
{
    public class CircumferenceTest
    {
        [Fact]
        public void ZeroRadiusTest()
        {
            Assert.Throws<ArgumentException>(() => new Circumference(0.0));
        }

        [Fact]
        public void NegativeRadiusTest()
        {
            Assert.Throws<ArgumentException>(() => new Circumference(-1.0));
        }

        [Fact]
        public void CalculationTest1()
        {
            Circumference circumference = new Circumference(1);
            // Math.PI * radius * radius, where radius = 1
            Assert.True(Math.PI == circumference.Area);
        }

        [Fact]
        public void CalculationTest2()
        {
            double radius = 5.2582;
            Circumference circumference = new Circumference(radius);
            double area = Math.PI * radius * radius;
            Assert.True(area == circumference.Area);
        }
    }
}