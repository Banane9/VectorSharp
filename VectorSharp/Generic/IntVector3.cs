using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for ints.
    /// </summary>
    internal sealed class IntVector3 : Vector3<int>
    {
        public override Vector3<int> AsUnitVector
        {
            get
            {
                var length = Length;

                return new IntVector3(X / length, Y / length, Z / length);
            }
        }

        public override int Length
        {
            get { return (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public IntVector3(int x, int y, int z)
            : base(x, y, z)
        { }

        #region MathOperations

        public override Vector3<int> CrossProduct(Vector3<int> other)
        {
            return new IntVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override int DotProduct(Vector3<int> other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        protected override Vector3<int> Add(Vector3<int> other)
        {
            return new IntVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<int> Invert()
        {
            return new IntVector3(-X, -Y, -Z);
        }

        protected override Vector3<int> Multiply(int other)
        {
            return new IntVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<int> Subtract(Vector3<int> right)
        {
            return new IntVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}