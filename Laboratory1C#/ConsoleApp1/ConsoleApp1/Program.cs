using System;
using System.Xml.Serialization;

namespace Laboratory1
{
    class Program
    {
        static void Main(string[] args)
        {

            string choice;

            do
            {
                Console.WriteLine("Which program to execute?\n1 - Equation\n2 - TCircle");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ExecuteFirst();
                        break;

                    case "2":
                        ExecuteSecond();
                        break;

                    case "0":
                        Console.WriteLine("Leaving the program...");
                        break;

                    default:
                        Console.WriteLine("Wrong input try again somehow.");
                        break;
                }
            } while (choice != "0");
        }

        static void ExecuteFirst()
        {
            Equation equation = new Equation();
            equation.InputData();
            equation.OutputData();

            var solution = equation.SolveEquation();
            if (solution.HasValue)
            {
                Console.WriteLine($"Solution: x = {solution.Value.x}; y = {solution.Value.y}");
                Console.WriteLine(equation.IsSoultion(solution.Value.x, solution.Value.y));
            }
            else
            {
                Console.WriteLine("Equation has no solutions or equation has an infinite amount of solutions.");
            }
            Console.WriteLine();
        }
        static void ExecuteSecond()
        {
            Console.WriteLine("=== TCircle Examples ===");



            TCircle circle1 = new TCircle(5);
            TCircle circle2 = new TCircle(3);

            Console.WriteLine($"Circle 1: {circle1}");
            Console.WriteLine($"Circle 2: {circle2}");

            Console.WriteLine($"Circle 1 Area: {circle1.CalculateArea()}");
            Console.WriteLine($"Circle 1 Length: {circle1.CalculateCircleLength()}");

            TCircle circleSum = circle1 + circle2;
            Console.WriteLine($"Sum of Circle 1 and Circle 2 (radius): {circleSum}");

            TCircle circleDiff = circle1 - circle2;
            Console.WriteLine($"Difference of Circle 1 and Circle 2 (radius): {circleDiff}");

            TCircle circleScaled = circle1 * 2;
            Console.WriteLine($"Circle 1 scaled by 2 (radius): {circleScaled}");

            int comparisonResult = circle1.CompareTo(circle2);
            string comparisonMessage = comparisonResult > 0 ? "greater than" :
                                        comparisonResult < 0 ? "smaller than" :
                                        "equal to";
            Console.WriteLine($"Circle 1 is {comparisonMessage} Circle 2.");

            Console.WriteLine("\n=== TSphere Examples ===");
            TSphere sphere = new TSphere();
            Console.WriteLine(sphere.Radius);

            TSphere lol = new TSphere(new TSphere(10));
            Console.WriteLine(lol.Radius);

            TSphere sphere1 = new TSphere(5);
            TSphere sphere2 = new TSphere(3);

            Console.WriteLine($"Sphere 1: {sphere1}");
            Console.WriteLine($"Sphere 2: {sphere2}");

            Console.WriteLine($"Sphere 1 Volume: {sphere1.CalculateVolume()}");
            Console.WriteLine($"Sphere 1 Area: {sphere1.CalculateArea()}");

            TSphere sphereSum = sphere1 + sphere2;
            Console.WriteLine($"Sum of Sphere 1 and Sphere 2 (radius): {sphereSum}");

            TSphere sphereDiff = sphere1 - sphere2;
            Console.WriteLine($"Difference of Sphere 1 and Sphere 2 (radius): {sphereDiff}");

            TSphere sphereScaled = sphere1 * 2;
            Console.WriteLine($"Sphere 1 scaled by 2 (radius): {sphereScaled}");

            comparisonResult = sphere1.CompareTo(sphere2);
            comparisonMessage = comparisonResult > 0 ? "greater than" :
                                        comparisonResult < 0 ? "smaller than" :
                                        "equal to";
            Console.WriteLine($"Sphere 1 is {comparisonMessage} Sphere 2.");
        }
    }
}