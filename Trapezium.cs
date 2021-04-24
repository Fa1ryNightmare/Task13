using System;

namespace Task13
{
    class Trapezium : IComparable<Trapezium>
    {
        //a < b - основания, c и d - боковые стороны трапеции
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double D { get; private set; }

        public Trapezium(double A, double B, double C, double D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }

        public double S
        {
            private set
            {
                S = ((A + B) / 4 * (B - A)) * Math.Sqrt((A + C + D - B) * (A + D - B - C) * (A + C - B - D) * (B + C + D - A));
            }
            get
            {
                return ((A + B) / 4 * (B - A)) * Math.Sqrt((A + C + D - B) * (A + D - B - C) * (A + C - B - D) * (B + C + D - A));
            }
        }
        public double P
        {
            private set
            {
                P = A + B + C + D;
            }
            get
            {
                return A + B + C + D;
            }
        }

        public bool IsExist()
        {
            if (A < B && A != 0 && B != 0 && C != 0 && D != 0 && S != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Trapezium other)
        {
            if (this.S > other.S)
            {
                return 1;
            }
            if (this.S < other.S)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
