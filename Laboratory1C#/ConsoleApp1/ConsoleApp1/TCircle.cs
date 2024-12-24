using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    public class TCircle
    {
        protected double radius;

        public TCircle()
        {
            this.radius = 0;
        }

        public TCircle(double radius)
        {
            ValidateInput(radius);
            this.radius = radius;
        }

        public TCircle(TCircle otherCircle)
        {
            this.radius = otherCircle.radius;
        }


        public double Radius
        {
            get { return this.radius; }
            set
            {
                ValidateInput(value);
                this.radius = value;
            }
        }
        public override string ToString()
        {
            return $"Circle with radius {radius}";
        }

        public void Input()
        {
            Console.Write("Please enter radius: ");
            string input = Console.ReadLine();

            while(!(double.TryParse(input, out double value)) || value < 0){
                Console.WriteLine("Wrong input buddy, value must a number and also must be greate than or equal to zero. Try again.");

                Console.Write("Please enter radius: ");
                input = Console.ReadLine();
            }

            this.radius = double.Parse(input);
        }

        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public double CalculateSectorArea(double angle)
        {
            return (angle/360.0) * CalculateArea();
        }

        public double CalculateCircleLength()
        {
            return 2 * Math.PI * radius;
        }

        public int CompareTo(TCircle b)
        {
            if (radius > b.radius) return 1;
            else if (radius < b.radius) return -1;
            else return 0;
        }


        public static TCircle operator +(TCircle a, TCircle b)
        {
            return new TCircle(a.radius + b.radius);
        }

        public static TCircle operator -(TCircle a, TCircle b)
        {
            return new TCircle(Math.Abs(a.radius - b.radius));
        }

        public static TCircle operator *(TCircle circle, double radius)
        {
            return new TCircle(circle.radius * radius);
        }

        public static TCircle operator *(double radius, TCircle circle)
        {
            return new TCircle(radius * circle.radius);
        }

        private static void ValidateInput(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Radius must greater than or equal to zero.");
            }
        }
    }
}
