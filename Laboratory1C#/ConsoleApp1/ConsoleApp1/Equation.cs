using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    public class Equation
    {
        private double[][] coefficients;
        private double[] constants;
        public Equation()
        {
            coefficients = new double[2][]
            {
                new double[2],
                new double[2]
            };
            constants = new double[2];
        }

        public double this[int equation, int coefficient]
        {
            get
            {
                if (coefficient < 2 && coefficient >= 0)
                {
                    return coefficients[equation][coefficient];
                }
                else if (coefficient == 2) 
                {
                    return constants[equation];
                }
                else
                {
                    throw new IndexOutOfRangeException("Wrond index buddy");
                }
            }
            set
            {
                if(coefficient < 2 && coefficient>=0)
                {
                    coefficients[equation][coefficient] = value;
                }
                else if(coefficient == 2)
                {
                    constants[equation] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Wrond index bud");
                }
            }
        }

        public void InputData()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Input coefficients for equation {i + 1} (a, b, c):");

                for (int j = 0; j < 3; j++)
                {
                    while (true)
                    {
                        Console.Write($"Enter value for {(j == 0 ? "a" : j == 1 ? "b" : "c")}: ");

                        string input = Console.ReadLine();

                        if (double.TryParse(input, out double value))
                        {
                            this[i, j] = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                    }
                }
            }
        }


        public void OutputData()
        {
            for (int i = 0; i < 2;i++)
            {
                Console.WriteLine($"{this[i, 0]}x + {this[i, 1]}y = {this[i, 2]}");
            }
        }

        public (double x, double y)? SolveEquation()
        {
            double determinant = this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];

            if (determinant == 0)
            {
                return null;
            }

            double determinantOne = this[0, 2] * this[1, 1] - this[0, 1] * this[1, 2];
            double determinantTwo = this[0, 0] * this[1, 2] - this[0, 2] * this[1, 0];

            return (determinantOne/determinant, determinantTwo/determinant);
        }

        public bool IsSoultion(double x, double y)
        {
            const double epsilon = 1e-9; // похибка

            Console.WriteLine($"{this[0, 0]} * {x} + {this[0, 1]} * {y} = {this[0, 0] * x + this[0, 1] * y}");
            Console.WriteLine($"{this[1, 0]} * {x} + {this[1, 1]} * {y} = {this[1, 0] * x + this[1, 1] * y}");

            return Math.Abs((this[0, 0] * x + this[0, 1] * y) - this[0, 2]) < epsilon &&
                Math.Abs((this[1, 0] * x + this[1, 1] * y) - this[1, 2]) < epsilon;
        }
    }
}
