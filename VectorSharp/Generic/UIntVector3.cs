using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for uints.
    /// </summary>
    internal sealed class UIntVector3 : Vector3<uint>
    {
        public override Vector3<uint> AsUnitVector
        {
            get
            {
                var length = Length;

                return new UIntVector3(X / length, Y / length, Z / length);
            }
        }

        public override uint Length
        {
            get { return (uint)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public UIntVector3(uint x, uint y, uint z)
            : base(x, y, z)
        { }

        private UIntVector3(int x, int y, int z)
            : this((uint)x, (uint)y, (uint)z)
        { }

        #region MathOperations

        public override Vector3<uint> CrossProduct(Vector3<uint> other)
        {
            return new UIntVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override uint DotProduct(Vector3<uint> other)
        {
            return (uint)((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        protected override Vector3<uint> Add(Vector3<uint> other)
        {
            return new UIntVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<uint> Invert()
        {
            throw new NotSupportedException("Can't invert unsigned numbers.");
        }

        protected override Vector3<uint> Multiply(uint other)
        {
            return new UIntVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<uint> Subtract(Vector3<uint> right)
        {
            return new UIntVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}