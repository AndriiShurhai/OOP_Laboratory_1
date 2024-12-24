using System;
using Xunit;

namespace Laboratory1.Tests
{
    public class TCircleTests
    {
        [Fact]
        public void Constructor_DefaultConstructor_ShouldSetRadiusToZero()
        {
            var circle = new TCircle();

            Assert.Equal(0, circle.Radius);
        }

        [Fact]
        public void Constructor_WithRadius_ShouldSetRadiusCorrectly()
        {
            double radius = 5;

            var circle = new TCircle(radius);

            Assert.Equal(radius, circle.Radius);
        }

        [Fact]
        public void Constructor_WithNegativeRadius_ShouldThrowArgumentException()
        {
            double radius = -5;

            Assert.Throws<ArgumentException>(() => new TCircle(radius));
        }

        [Fact]
        public void Constructor_CopyConstructor_ShouldCopyRadiusCorrectly()
        {
            var originalCircle = new TCircle(5);

            var newCircle = new TCircle(originalCircle);

            Assert.Equal(originalCircle.Radius, newCircle.Radius);
        }

        [Fact]
        public void Radius_SetValidRadius_ShouldUpdateRadius()
        {
            var circle = new TCircle();
            double newRadius = 10;

            circle.Radius = newRadius;

            Assert.Equal(newRadius, circle.Radius);
        }

        [Fact]
        public void Radius_SetNegativeRadius_ShouldThrowArgumentException()
        {
            var circle = new TCircle();

            Assert.Throws<ArgumentException>(() => circle.Radius = -10);
        }

        [Fact]
        public void CalculateArea_ShouldReturnCorrectArea()
        {
            double radius = 5;
            var circle = new TCircle(radius);
            double expectedArea = Math.PI * radius * radius;

            double area = circle.CalculateArea();

            Assert.Equal(expectedArea, area, precision: 5);
        }

        [Fact]
        public void CalculateSectorArea_ShouldReturnCorrectSectorArea()
        {
            double radius = 5;
            double angle = 90;
            var circle = new TCircle(radius);
            double expectedSectorArea = (angle / 360.0) * Math.PI * radius * radius;

            double sectorArea = circle.CalculateSectorArea(angle);

            Assert.Equal(expectedSectorArea, sectorArea, precision: 5);
        }

        [Fact]
        public void CalculateCircleLength_ShouldReturnCorrectLength()
        {
            double radius = 5;
            var circle = new TCircle(radius);
            double expectedLength = 2 * Math.PI * radius;

            double length = circle.CalculateCircleLength();

            Assert.Equal(expectedLength, length, precision: 5);
        }

        [Fact]
        public void CompareTo_ShouldCompareCirclesCorrectly()
        {
            var circle = new TCircle(10);
            var circle2 = new TCircle(10);
            Assert.Equal(0, circle.CompareTo(circle2));
        }

        [Fact]
        public void Operator_Add_ShouldReturnCircleWithCombinedRadius()
        {
            var circle1 = new TCircle(5);
            var circle2 = new TCircle(3);
            double expectedRadius = 8;

            var result = circle1 + circle2;

            Assert.Equal(expectedRadius, result.Radius);
        }

        [Fact]
        public void Operator_Subtract_ShouldReturnCircleWithDifferenceOfRadius()
        {
            var circle1 = new TCircle(5);
            var circle2 = new TCircle(3);
            double expectedRadius = 2;

            var result = circle1 - circle2;

            Assert.Equal(expectedRadius, result.Radius);
        }

        [Fact]
        public void Operator_Multiply_ShouldReturnCircleWithMultipliedRadius()
        {
            var circle = new TCircle(5);
            double multiplier = 2;
            double expectedRadius = 10;

            var result = circle * multiplier;

            Assert.Equal(expectedRadius, result.Radius);
        }

        [Fact]
        public void Operator_MultiplyByDouble_ShouldReturnCircleWithMultipliedRadius()
        {
            var circle = new TCircle(5);
            double multiplier = 3;
            double expectedRadius = 15;

            var result = multiplier * circle;

            Assert.Equal(expectedRadius, result.Radius);
        }
    }
}
