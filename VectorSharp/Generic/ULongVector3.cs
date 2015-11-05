using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for ulongs.
    /// </summary>
    internal sealed class ULongVector3 : Vector3<ulong>
    {
        public override Vector3<ulong> AsUnitVector
        {
            get
            {
                var length = Length;

                return new ULongVector3(X / length, Y / length, Z / length);
            }
        }

        public override ulong Length
        {
            get { return (ulong)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public ULongVector3(ulong x, ulong y, ulong z)
            : base(x, y, z)
        { }

        #region MathOperations

        public override Vector3<ulong> CrossProduct(Vector3<ulong> other)
        {
            return new ULongVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override ulong DotProduct(Vector3<ulong> other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        protected override Vector3<ulong> Add(Vector3<ulong> other)
        {
            return new ULongVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<ulong> Invert()
        {
            throw new NotSupportedException("Can't invert unsigned numbers.");
        }

        protected override Vector3<ulong> Multiply(ulong other)
        {
            return new ULongVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<ulong> Subtract(Vector3<ulong> right)
        {
            return new ULongVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}