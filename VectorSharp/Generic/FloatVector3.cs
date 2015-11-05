using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorSharp.Generic
{
    /// <summary>
    /// Represents a <see cref="Vector3&lt;TCoordinate&gt;"/> for floats.
    /// </summary>
    internal sealed class FloatVector3 : Vector3<float>
    {
        public override Vector3<float> AsUnitVector
        {
            get
            {
                var length = Length;

                return new FloatVector3(X / length, Y / length, Z / length);
            }
        }

        public override float Length
        {
            get { return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public FloatVector3(float x, float y, float z)
            : base(x, y, z)
        { }

        #region MathOperations

        public override Vector3<float> CrossProduct(Vector3<float> other)
        {
            return new FloatVector3(
                x: (Y * other.Z) - (other.Y * Z),
                y: (other.X * Z) - (X * other.Z),
                z: (X * other.Y) - (other.X * Y));
        }

        public override float DotProduct(Vector3<float> other)
        {
            return (X * other.X) + (Y * other.Y) + (Z * other.Z);
        }

        protected override Vector3<float> Add(Vector3<float> other)
        {
            return new FloatVector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        protected override Vector3<float> Invert()
        {
            return new FloatVector3(-X, -Y, -Z);
        }

        protected override Vector3<float> Multiply(float other)
        {
            return new FloatVector3(X * other, Y * other, Z * other);
        }

        protected override Vector3<float> Subtract(Vector3<float> right)
        {
            return new FloatVector3(X - right.X, Y - right.Y, Z - right.Z);
        }

        #endregion MathOperations
    }
}