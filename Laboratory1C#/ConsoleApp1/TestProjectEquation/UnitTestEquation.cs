using Xunit;
using Laboratory1;
using System;

namespace Laboratory1.Tests
{
    public class EquationTests
    {
        [Fact]
        public void Indexer_GetAndSet_ShouldWorkCorrectly()
        {
            var equation = new Equation();

            equation[0, 0] = 2;
            equation[0, 1] = 3;
            equation[0, 2] = 4;

            Assert.Equal(2, equation[0, 0]);
            Assert.Equal(3, equation[0, 1]);
            Assert.Equal(4, equation[0, 2]);
        }

        [Fact]
        public void Indexer_ShouldThrowIndexOutOfRangeException_ForInvalidIndex()
        {
            var equation = new Equation();

            Assert.Throws<IndexOutOfRangeException>(() => equation[-2, 3] = 5);
            Assert.Throws<IndexOutOfRangeException>(() => equation[0, 3] = 5);
            Assert.Throws<IndexOutOfRangeException>(() => equation[2, 0] = 5);
        }

        [Fact]
        public void SolveEquation_ShouldReturnCorrectSolution()
        {
            var equation = new Equation();
            equation[0, 0] = 2;
            equation[0, 1] = 1;
            equation[0, 2] = 5;  // 2x + y = 5

            equation[1, 0] = 1;
            equation[1, 1] = -1;
            equation[1, 2] = 1;  // x - y = 1

            var solution = equation.SolveEquation();

            Assert.NotNull(solution);
            Assert.Equal(2, solution.Value.x, precision: 9); // Expected x = 2
            Assert.Equal(1, solution.Value.y, precision: 9); // Expected y = 1
        }

        [Fact]
        public void SolveEquation_ShouldReturnNull_ForNoSolution()
        {
            var equation = new Equation();
            equation[0, 0] = 1;
            equation[0, 1] = 2;
            equation[0, 2] = 3;

            equation[1, 0] = 2;
            equation[1, 1] = 4;
            equation[1, 2] = 6; 

            var solution = equation.SolveEquation();

            Assert.Null(solution);
        }

        [Fact]
        public void IsSolution_ShouldReturnTrue_ForCorrectSolution()
        {
            var equation = new Equation();
            equation[0, 0] = 2;
            equation[0, 1] = 1;
            equation[0, 2] = 5;  // 2x + y = 5

            equation[1, 0] = 1;
            equation[1, 1] = -1;
            equation[1, 2] = 1;  // x - y = 1

            var isValid = equation.IsSoultion(2, 1);

            Assert.True(isValid);  // 2x + 1y = 5, x - y = 1 should be true for (x, y) = (2, 1)
        }

        [Fact]
        public void IsSolution_ShouldReturnFalse_ForIncorrectSolution()
        {
            var equation = new Equation();
            equation[0, 0] = 2;
            equation[0, 1] = 1;
            equation[0, 2] = 5;  // 2x + y = 5

            equation[1, 0] = 1;
            equation[1, 1] = -1;
            equation[1, 2] = 1;  // x - y = 1

            var isValid = equation.IsSoultion(0, 0);  // Wrong solution

            Assert.False(isValid);
        }
    }
}
