using System;
using Xunit;
using Xunit.Abstractions;

namespace AreaLib.Tests
{
    public class TriangleTest
    {
        [Fact]
        public void ZeroTriangleSideTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(0, 2, 3));
        }
        
        [Fact]
        public void NegativeTriangleSideTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1, 2, 3));
        }
        
        [Fact]
        public void NaNTriangleSideTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(double.NaN, 2, 3));
        }

        [Fact]
        public void InfinityTriangleSideTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(double.PositiveInfinity, 2, 3));
            Assert.Throws<ArgumentException>(() => new Triangle(double.NegativeInfinity, 2, 3));
        }

        [Fact]
        public void EpsilonTriangleSideTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(double.Epsilon, 2, 3));
        }
        
        [Fact]
        public void NonExistentTriangleTest()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
        }

        [Fact]
        public void RightTriangleTest()
        {
            Assert.True(new Triangle(3, 5, 4).IsRight);
        }

        [Fact]
        public void CalculationTest1()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            double area = 0.5 * 3 * 4;
            Assert.True(triangle.Area == area);
        }

        [Fact]
        public void CalculationTest2()
        {
            Triangle triangle = new Triangle(5, 5, 5);

            double semiPerimeter = (5.0 + 5.0 + 5.0) / 2.0;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - 5.0) * (semiPerimeter - 5.0) * (semiPerimeter - 5.0));
            
            Assert.True(area == triangle.Area);
        }
    }
}