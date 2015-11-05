using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for ushorts.
    /// </summary>
    internal sealed class UShortVector3 : Vector3<ushort>
    {
        public override Vector3<ushort> AsUnitVector
        {
            get
            {
                var length = Length;

                return new UShortVector3(X / length, Y / length, Z / length);
            }
        }

        public override ushort Length
        {
            get { return (ushort)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public UShortVector3(ushort x, ushort y, ushort z)
            : base(x, y, z)
        { }

        private UShortVector3(int x, int y, int z)
            : this((ushort)x, (ushort)y, (ushort)z)
        { }

        #region MathOperations

        public override Vector3<ushort> CrossProduct(Vector3<ushort> other)
        {
            return new UShortVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override ushort DotProduct(Vector3<ushort> other)
        {
            return (ushort)((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        protected override Vector3<ushort> Add(Vector3<ushort> other)
        {
            return new UShortVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<ushort> Invert()
        {
            throw new NotSupportedException("Can't invert unsigned numbers.");
        }

        protected override Vector3<ushort> Multiply(ushort other)
        {
            return new UShortVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<ushort> Subtract(Vector3<ushort> right)
        {
            return new UShortVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}