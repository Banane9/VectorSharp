using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for shorts.
    /// </summary>
    internal sealed class ShortVector3 : Vector3<short>
    {
        public override Vector3<short> AsUnitVector
        {
            get
            {
                var length = Length;

                return new ShortVector3(X / length, Y / length, Z / length);
            }
        }

        public override short Length
        {
            get { return (short)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public ShortVector3(short x, short y, short z)
            : base(x, y, z)
        { }

        private ShortVector3(int x, int y, int z)
            : this((short)x, (short)y, (short)z)
        { }

        #region MathOperations

        public override Vector3<short> CrossProduct(Vector3<short> other)
        {
            return new ShortVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override short DotProduct(Vector3<short> other)
        {
            return (short)((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        protected override Vector3<short> Add(Vector3<short> other)
        {
            return new ShortVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<short> Invert()
        {
            return new ShortVector3(-X, -Y, -Z);
        }

        protected override Vector3<short> Multiply(short other)
        {
            return new ShortVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<short> Subtract(Vector3<short> right)
        {
            return new ShortVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}