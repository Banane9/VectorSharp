using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for doubles.
    /// </summary>
    internal sealed class DoubleVector3 : Vector3<double>
    {
        public override Vector3<double> AsUnitVector
        {
            get
            {
                var length = Length;

                return new DoubleVector3(X / length, Y / length, Z / length);
            }
        }

        public override double Length
        {
            get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public DoubleVector3(double x, double y, double z)
            : base(x, y, z)
        { }

        #region MathOperations

        public override Vector3<double> CrossProduct(Vector3<double> other)
        {
            return new DoubleVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override double DotProduct(Vector3<double> other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        protected override Vector3<double> Add(Vector3<double> other)
        {
            return new DoubleVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<double> Invert()
        {
            return new DoubleVector3(-X, -Y, -Z);
        }

        protected override Vector3<double> Multiply(double other)
        {
            return new DoubleVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<double> Subtract(Vector3<double> right)
        {
            return new DoubleVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}