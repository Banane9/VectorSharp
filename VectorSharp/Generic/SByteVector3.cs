using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for sbytes.
    /// </summary>
    internal sealed class SByteVector3 : Vector3<sbyte>
    {
        public override Vector3<sbyte> AsUnitVector
        {
            get
            {
                var length = Length;

                return new SByteVector3(X / length, Y / length, Z / length);
            }
        }

        public override sbyte Length
        {
            get { return (sbyte)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public SByteVector3(sbyte x, sbyte y, sbyte z)
            : base(x, y, z)
        { }

        private SByteVector3(int x, int y, int z)
            : this((sbyte)x, (sbyte)y, (sbyte)z)
        { }

        #region MathOperations

        public override Vector3<sbyte> CrossProduct(Vector3<sbyte> other)
        {
            return new SByteVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override sbyte DotProduct(Vector3<sbyte> other)
        {
            return (sbyte)((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        protected override Vector3<sbyte> Add(Vector3<sbyte> other)
        {
            return new SByteVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<sbyte> Invert()
        {
            return new SByteVector3(-X, -Y, -Z);
        }

        protected override Vector3<sbyte> Multiply(sbyte other)
        {
            return new SByteVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<sbyte> Subtract(Vector3<sbyte> right)
        {
            return new SByteVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}