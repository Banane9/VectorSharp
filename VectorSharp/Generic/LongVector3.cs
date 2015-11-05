using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for longs.
    /// </summary>
    internal sealed class LongVector3 : Vector3<long>
    {
        public override Vector3<long> AsUnitVector
        {
            get
            {
                var length = Length;

                return new LongVector3(X / length, Y / length, Z / length);
            }
        }

        public override long Length
        {
            get { return (long)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public LongVector3(long x, long y, long z)
            : base(x, y, z)
        { }

        #region MathOperations

        public override Vector3<long> CrossProduct(Vector3<long> other)
        {
            return new LongVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override long DotProduct(Vector3<long> other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        protected override Vector3<long> Add(Vector3<long> other)
        {
            return new LongVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<long> Invert()
        {
            return new LongVector3(-X, -Y, -Z);
        }

        protected override Vector3<long> Multiply(long other)
        {
            return new LongVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<long> Subtract(Vector3<long> right)
        {
            return new LongVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}