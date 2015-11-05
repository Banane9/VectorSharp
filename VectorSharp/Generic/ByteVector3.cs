using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for bytes.
    /// </summary>
    internal sealed class ByteVector3 : Vector3<byte>
    {
        public override Vector3<byte> AsUnitVector
        {
            get
            {
                var length = Length;

                return new ByteVector3(X / length, Y / length, Z / length);
            }
        }

        public override byte Length
        {
            get { return (byte)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public ByteVector3(byte x, byte y, byte z)
            : base(x, y, z)
        { }

        private ByteVector3(int x, int y, int z)
            : this((byte)x, (byte)y, (byte)z)
        { }

        #region MathOperations

        public override Vector3<byte> CrossProduct(Vector3<byte> other)
        {
            return new ByteVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override byte DotProduct(Vector3<byte> other)
        {
            return (byte)((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        protected override Vector3<byte> Add(Vector3<byte> other)
        {
            return new ByteVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<byte> Invert()
        {
            return new ByteVector3(-X, -Y, -Z);
        }

        protected override Vector3<byte> Multiply(byte other)
        {
            return new ByteVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<byte> Subtract(Vector3<byte> right)
        {
            return new ByteVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}