using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    public class TSphere: TCircle
    {
        public TSphere(double radius): base(radius) {}

        public TSphere() : base() { }
        
        public TSphere(TSphere a) : base(a.radius) { }

        public double CalculateVolume()
        {
            return (4 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }

        public new  double CalculateArea()
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }



        public static TSphere operator +(TSphere a, TSphere b)
        {
            return new TSphere(a.radius + b.radius);
        }

        public static TSphere operator -(TSphere a, TSphere b)
        {
            return new TSphere(a.radius - b.radius);
        }

        public static TSphere operator *(TSphere circle, double number)
        {
            return new TSphere(circle.radius * number);
        }

        public static TSphere operator *(double number, TSphere circle)
        {
            return new TSphere(number * circle.radius);
        }

        public override string ToString()
        {
            return $"Sphere with radius {radius}";
        }
    }
}
